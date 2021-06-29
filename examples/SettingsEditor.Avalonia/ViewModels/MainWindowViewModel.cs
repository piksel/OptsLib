using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Text;
using Avalonia;
using Microsoft.Extensions.Logging;
using OptsLib;
using OptsLib.Editor;
using ReactiveUI;
using OptsLib.Examples.AvaloniaOptsEditor.Util;

namespace OptsLib.Examples.AvaloniaOptsEditor.ViewModels
{
    public class MainWindowViewModel: ReactiveObject
    {
        private AppSettings options;

        public MainWindowViewModel()
        {
            var log = Logging.CreateLogger(nameof(MainWindowViewModel));

            OptionsManager = AvaloniaLocator.Current.GetService<OptionsManager<AppSettings>>();

            log.LogInformation("Loading options...");
            Sections = new MetaSettings(typeof(AppSettings)).Sections.Keys;
            

            LoadOptions = ReactiveCommand.CreateFromTask(async () =>
            {
                log.LogInformation("Loading options...");
                Options = await OptionsManager.Load();
            });
            
            SaveOptions = ReactiveCommand.CreateFromTask(async () =>
            {
                log.LogInformation("Saving options...");
                await OptionsManager.Save();
            });
            
            // TODO: Fix async loading
            options = OptionsManager.Options.Result;
        }

        public ReactiveCommand<Unit, Unit> LoadOptions { get; } 
        public ReactiveCommand<Unit, Unit> SaveOptions { get; } 
        
        public IEnumerable<string> Sections { get; }

        public SimpleLoggerProvider Logging => Program.Logging;

        public OptionsManager<AppSettings> OptionsManager { get; }
        
        public AppSettings Options
        {
            get => options;
            set => this.RaiseAndSetIfChanged(ref options, value, nameof(Options));
        }
    }
}
