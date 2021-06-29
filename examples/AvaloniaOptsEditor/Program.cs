using System;
using Avalonia;
using Avalonia.ReactiveUI;
using Microsoft.Extensions.Logging;
using OptsLib;
using OptsLib.Examples.AvaloniaOptsEditor.Util;

namespace OptsLib.Examples.AvaloniaOptsEditor
{
    public static class Program
    {
        internal static SimpleLoggerProvider Logging = new();
        
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args)
        {
            var log = Logging.CreateLogger("App");
            log.LogInformation("Building app");
            OptionsLogger.Factory = Logging;
            var app = BuildAvaloniaApp();
            log.LogInformation("Starting app");
            app.StartWithClassicDesktopLifetime(args);
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .UseOptions(() => OptionsManager.From<AppSettings>()
                    .WithJsonSerializer(r => r
                        .UseSimpleAppOptions<App>()))
                .UseReactiveUI()
                .LogToTrace();
    }
}
