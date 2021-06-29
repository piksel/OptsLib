using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace OptsLib.Examples.SettingsEditor.WinForms
{
    public partial class ExampleMainForm : Form, ILogEventSink
    {
        private readonly OptionsManager<AppSettings> optionsManager;
        private readonly ILoggerFactory loggerFactory;

        private AppSettings Settings => optionsManager.Options.Result;

        public ExampleMainForm()
        {
            InitializeComponent();

            Log.Logger = new LoggerConfiguration()
                .Enrich.WithProperty("SourceContext", "Root")
                .Enrich.FromLogContext()
                .MinimumLevel.Debug()
                .WriteTo.Sink(this)
                .CreateLogger();

            loggerFactory = LoggerFactory.Create(c => c.AddSerilog(Log.Logger));

            OptionsLogger.Factory = loggerFactory;

            optionsManager = OptionsManager
                .From<AppSettings>()
                .WithJsonSerializer(r => r.UseSimpleAppOptions<ExampleMainForm>())
                .Build();

            

            settingsEditorControl ??= new OptsLib.WinForms.SettingsEditorControl();

            scSettingsLog.SuspendLayout();
            settingsEditorControl.Dock = DockStyle.Fill;
            settingsEditorControl.OptionsManager = optionsManager;
            settingsEditorControl.SettingsValueChanged += SettingsValueChanged;
            scSettingsLog.Panel1.Controls.Add(settingsEditorControl);
            wbFile.Dock = DockStyle.Fill;
            pFile.Controls.Add(wbFile);

            scSettingsLog.ResumeLayout(true);

            bLoad.Click += async (_, __) =>
            {

                await optionsManager.Load();
            };
        }

        private async void SettingsValueChanged(object? sender, Editor.EditorValueChangedEventArgs e)
        {

            if (e.SettingKey == nameof(AppSettings.Position) && e.Value is Point position)
            {
                Location = position;
            }

            if (e.SettingKey == nameof(AppSettings.Size) && e.Value is Point size)
            {
                Size = new Size(size);
            }

            if (e.SettingKey == nameof(AppSettings.Title) && e.Value is string title)
            {
                Text = title;
            }

            await UpdateConfigPreview();
        }

        private async Task UpdateConfigPreview()
        {
            var tempPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            try
            {
                var sm = OptionsManager
                    .From<AppSettings>()
                    .WithJsonSerializer(r => r.UseFileSystem(tempPath), new System.Text.Json.JsonSerializerOptions()
                    {
                        WriteIndented = true,
                    })
                    .WithInitial(await optionsManager.Options)
                    .Build();

                await sm.Save();

                string conf;
                using (var sw = new StreamReader(await sm.Store.OpenReadStream()))
                {
                    conf = pFile.Text = sw.ReadToEnd();
                }

                var html = SyntaxHighlightResources.Html;
                var script = SyntaxHighlightResources.Script;
                //var style = SyntaxHightlightResources.Style_MonokaiSublime;
                var style = SyntaxHighlightResources.Style_ColorBrewer;

                var doc = string.Format(html, script, style, "", conf);
                wbFile.DocumentText = doc;
            }
            finally
            {
                var di = new DirectoryInfo(tempPath);
                if (di.Exists) di.Delete(true);
            }

        }

        private async void ExampleMainForm_Load(object sender, System.EventArgs e)
        {
            var settings = await optionsManager.Options;
            if (settings.Position.HasValue)
            {
                Location = settings.Position.Value;
            }

            if(settings.Size.HasValue)
            {
                Size = new Size(settings.Size.Value);
            }

            if(settings.Title != null)
            {
                Text = settings.Title;
            }
        }

        private async void BSave_Click(object sender, System.EventArgs e)
        {
            Settings.Position = Location;
            Settings.Size = new Point(Size);
            Settings.Title = Text;

            await optionsManager.Save();
        }

        public void Emit(LogEvent logEvent)
        {
            Debug.WriteLine(logEvent.RenderMessage());

            //var props = string.Join(", ", logEvent.Properties.Select(p => $"{p.Key} => {p.Value}"));
            //logEvent.AddPropertyIfAbsent(new LogEventProperty("Source"))
            var ctx = logEvent.Properties["SourceContext"].ToString().Trim('"');

            tbConsole.AppendText($"[{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}][{logEvent.Level.ToString()[0]}] {ctx}: {logEvent.RenderMessage()}{Environment.NewLine}");
        }
    }
}
