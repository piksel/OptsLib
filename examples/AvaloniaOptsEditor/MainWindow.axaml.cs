using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using OptsLib;

namespace OptsLib.Examples.AvaloniaOptsEditor
{
    public class MainWindow : Window
    {
        public OptionsManager<AppSettings> OptionsManager { get; }
        
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            
            // OptionsManager = OptsLib.OptionsManager
            //     .From<AppSettings>()
            //     .WithJsonSerializer(b => b.UseSimpleAppOptions<MainWindow>())
            //     .Build();
            //
            // if (this.FindControl<OptsLib.Avalonia.SettingsEditor>("SettingsEditor") is { } se)
            // {
            //     se.OptionsManager = OptionsManager;
            // }
            // settingsEditor.OptionsManager = OptionsManager;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            


        }
    }
}
