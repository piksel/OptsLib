using System;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace OptsLib.Examples.AvaloniaOptsEditor.Util
{
    public class SimpleLoggerProvider : ILoggerFactory, ILoggerProvider
    {
        private ConcurrentDictionary<string, ILogger> loggers = new();
        public ObservableCollection<LogMessage> Messages { get; } = new();
        public LogLevel LogLevel { get; set; } = LogLevel.Information;
        
        public void Dispose()
        {
            loggers.Clear();
            Messages.Clear();
        }

        public ILogger CreateLogger(string categoryName)
            => loggers.GetOrAdd(categoryName, category => new SimpleLogger(this, category));

        public void AddProvider(ILoggerProvider provider) 
            => throw new NotImplementedException();
    }
    
    public record LogMessage(LogLevel LogLevel, DateTime Time, string Category, string Message);
    public interface ILogMessage { LogLevel LogLevel { get; } DateTime Time { get; } string Category { get; } string Message { get; } }
    
    public class SimpleLogger : ILogger
    {
        public SimpleLogger(SimpleLoggerProvider provider, string category)
        {
            Category = category;
            Provider = provider;
        }

        public SimpleLoggerProvider Provider { get; }
        public string Category { get; }
            
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var time = DateTime.UtcNow;
            lock (Provider.Messages)
            {
                var message = formatter(state, exception);
                Provider.Messages.Add(new LogMessage(logLevel, time, Category, message));
                Debug.WriteLine($"LogMessages: {Provider.Messages.Count}");
                Debug.WriteLine(message, Category);
            }
        }

        public bool IsEnabled(LogLevel logLevel) => Provider.LogLevel >= logLevel;

        public IDisposable BeginScope<TState>(TState state) => default;
    }
}