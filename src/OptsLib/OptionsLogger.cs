using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace OptsLib
{
    public static class OptionsLogger
    {
        public static ILoggerFactory Factory { get; set; } = NullLoggerFactory.Instance;

        public static ILogger GetLogger(string categoryName) => Factory.CreateLogger(categoryName);
    }
}
