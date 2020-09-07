using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using LibSettings.Editor;

namespace LibSettings.WinForms
{
    public partial class SettingsEditorControl : UserControl
    {
        private ILoggerFactory loggerFactory = NullLoggerFactory.Instance;
        private ILogger log = NullLogger.Instance;

        private AutoBool showSections = AutoBool.Auto;
        private ISettingsManager settingsManager;
        private MetaSettings meta = MetaSettings.Empty;

        string? SelectedSection { get; set; }

        Dictionary<string, Dictionary<string, SettingEditor>> settingEditors 
            = new Dictionary<string, Dictionary<string, SettingEditor>>();

        Dictionary<SettingEditor, Label> editorStatuses = new Dictionary<SettingEditor, Label>();

        public event EventHandler? SettingsManagerChanged;
        public event EventHandler<EditorValueChangedEventArgs>? SettingsValueChanged;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public ISettingsManager SettingsManager
        {
            get => settingsManager;
            set
            {
                if (value is ISettingsManager && value != settingsManager)
                {
                    settingsManager = value;
                    SettingsManagerOnChanged();
                }
            }
        }

        private void SettingsManagerOnChanged()
        {
            meta = new MetaSettings(settingsManager.SettingsType);

            Debug.WriteLine(meta.Sections.Count);

            UpdateSections();

            //UpdateVisible();
            SettingsManagerChanged?.Invoke(this, EventArgs.Empty);
        }

        public ILoggerFactory LoggerFactory
        {
            get => SettingsLogger.Factory;
            set {
                SettingsLogger.Factory = value;
                log = SettingsLogger.GetLogger(nameof(SettingsEditorControl));
            }
        }

        public SettingsEditorControl()
        {
            InitializeComponent();
            ToolTip = new ToolTip();
            settingsManager = LibSettings.SettingsManager.Empty;
            SettingsManagerChanged += settingsManagerChanged;
        }

        private async void settingsManagerChanged(object? sender, EventArgs e)
        {
            UpdateValues(await settingsManager.GetSettings());
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            await Task.CompletedTask;
            //UpdateValues(await settingsManager.GetSettings());
        }

        private void UpdateSections()
        {
            tvSections.Nodes.Clear();
            settingEditors.Clear();

            foreach (var section in meta.Sections)
            {
                var showSection = meta.Sections.Count == 1 || SelectedSection == section.Key;

                if (!settingEditors.ContainsKey(section.Key))
                {
                    settingEditors.Add(section.Key, new Dictionary<string, SettingEditor>(section.Value.Count));
                    tvSections.Nodes.Add(section.Key);
                }

                tableLayoutPanel1.SuspendLayout();
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.RowStyles.Clear();

                int row = 0;
                foreach (var setting in section.Value)
                {
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));

                    var editor = GetEditorForSetting(setting.Value);
                    //editor.Visible = showSection;
                    //editor.Width = flpSettings.DisplayRectangle.Width - (flpSettings.Padding.Horizontal + flpSettings.AutoScrollMargin.Width + 24);
                    //editor.Dock = DockStyle.Top;
                    settingEditors[section.Key].Add(setting.Key, editor);


                    if (!editor.IncludesLabel)
                    {
                        var label = new Label();
                        label.Dock = DockStyle.Fill;
                        label.Text = setting.Value.Name;
                        label.TextAlign = ContentAlignment.MiddleLeft;
                        label.AutoSize = true;
                        tableLayoutPanel1.Controls.Add(label, 0, row);
                        tableLayoutPanel1.Controls.Add(editor, 1, row);
                    }
                    else
                    {
                        tableLayoutPanel1.Controls.Add(editor, 0, row);
                        tableLayoutPanel1.SetColumnSpan(editor, 2);

                    }

                    editor.Dock = DockStyle.Fill;


                    var stat = new Label
                    {
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    tableLayoutPanel1.Controls.Add(stat, 2, row);

                    UpdateEditorStatus(editor.EditorStatus, stat);
                    editorStatuses.Add(editor, stat);

                    editor.EditorStatusChanged += EditorStatusChanged;
                    editor.ValueChanged += EditorValueChanged;


                    var description = setting.Value.Description;

                    if (!string.IsNullOrEmpty(description))
                    {
                        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
                        row++;

                        var desc = new Label()
                        {
                            Dock = DockStyle.Fill,
                            Text = description,
                        };

                        tableLayoutPanel1.Controls.Add(desc, editor.IncludesLabel ? 0 : 1, row);
                        tableLayoutPanel1.SetColumnSpan(desc, editor.IncludesLabel ? 3 : 2);
                    }

                    row++;
                }

                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
                tableLayoutPanel1.Controls.Add(new Panel()
                {
                    AutoSize = true,
                }, 0, row+1);
                tableLayoutPanel1.ResumeLayout(true);
            }

            scSettings.Panel1Collapsed = showSections.Resolve(() => meta.Sections.Any());
            if (meta.Sections.Count == 1)
            {
                SelectedSection = meta.Sections.Keys.First();
            }

        }

        private async void EditorValueChanged(object? sender, EditorValueChangedEventArgs e)
        {
            var settings = await settingsManager.GetSettings();
            if(meta.Sections
                .SelectMany(s => s.Value.Where(ss => ss.Key == e.SettingKey))
                .Select(ss => ss.Value)
                .FirstOrDefault() is MetaSetting ms)
            {
                ms.SetValue(settings, e.Value);
            }
            SettingsValueChanged?.Invoke(sender, e);
        }

        private void EditorStatusChanged(object? sender, EditorStatus e)
        {
            if (sender is SettingEditor editor)
            {
                UpdateEditorStatus(e, editorStatuses[editor], editor.ValidationError);
                {
                    editor.BackColor = e == EditorStatus.Invalid ? Color.Red : Color.Transparent;
                }
            }
        }

        private void UpdateEditorStatus(EditorStatus editorStatus, Label statusLabel, string? validationError = null)
        {
            switch (editorStatus) { 
                case EditorStatus.Valid:
                    statusLabel.Text = "✔";
                    statusLabel.ForeColor = Color.Green;
                    ToolTip.SetToolTip(statusLabel, "Modified and valid");
                    break;

                case EditorStatus.Invalid:
                    statusLabel.Text = "❌";
                    statusLabel.ForeColor = Color.Red;
                    var invalidTooltip = $"Invalid: {validationError}";
                    ToolTip.SetToolTip(statusLabel, invalidTooltip);

                    break;


                case EditorStatus.Unchanged:
                default:
                    statusLabel.Text = "⭕";
                    statusLabel.ForeColor = Color.Blue;
                    ToolTip.SetToolTip(statusLabel, "Unmodified");
                    break;
            }
        }

        private void UpdateVisible()
        {

        }

        private void UpdateValues(ISettings result)
        {
            foreach (var section in settingEditors)
            {
                var metaSection = meta.Sections[section.Key];
                foreach (var setting in section.Value)
                {
                    var metaValue = metaSection[setting.Key];

                    var value = metaValue.GetValue(result);


                    Debug.WriteLine("Setting {0} to {1}", setting.Key, value);
                    log.LogDebug("Setting {Key} to {Value}", setting.Key, value);

                    setting.Value.Value = value;
                }
            }
        }

        private SettingEditor GetEditorForSetting(MetaSetting ms)
        {
            SettingEditor editor;
            switch (ms.SettingType)
            {
                case SettingType.Point:
                    editor = new PointSettingEditor(ms.Key);
                    break;

                case SettingType.Path:
                    editor = new PathSettingEditor(ms.Key, ms.SettingOptions<PathSettingOptions>());
                    break;

                case SettingType.Toggle:
                    editor = new ToggleSettingEditor(ms.Key, ms.Name);
                    break;

                case SettingType.Option:
                    editor = new OptionSettingEditor(ms.Key, ms.ValueType);
                    break;

                case SettingType.Integer:
                case SettingType.Decimal:
                    editor = new NumberSettingEditor(ms.Key, ms.ValueRange, ms.ValuePrecision);
                    break;

                case SettingType.Text:
                default:
                    editor = new TextSettingEditor(ms.Key);
                    break;
            }

            return editor;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoBool ShowSections
        {
            get => showSections;
            set
            {
                showSections = value;
                UpdateVisible();
            }
        }

        public ToolTip ToolTip { get; }

    }
}
