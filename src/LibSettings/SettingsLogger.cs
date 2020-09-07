using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibSettings
{
    public static class SettingsLogger
    {
        public static ILoggerFactory Factory { get; set; } = NullLoggerFactory.Instance;

        public static ILogger GetLogger(string categoryName) => Factory.CreateLogger(categoryName);
    }
}
