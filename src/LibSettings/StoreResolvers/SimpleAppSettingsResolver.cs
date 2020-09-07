using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LibSettings.StoreResolvers
{
    public class SimpleAppSettingsResolver : FileSystemStoreResolver
    {
        private ILogger logger = SettingsLogger.GetLogger(nameof(SimpleAppSettingsResolver));
        static string LocalAppData => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public SimpleAppSettingsResolver(ISettingsSerializer serializer, string organization, string appName) 
            : base(serializer, new DirectoryInfo(Path.Combine(LocalAppData, CleanedPathName(organization), CleanedPathName(appName)))) 
        {

            logger.LogInformation("Resolved organization {Organization}, and app name {AppName} to {DataPath}", organization, appName, storeRoot.FullName);
        }

        private static string CleanedPathName(string organization)
        {
            var invalidChars = Path.GetInvalidFileNameChars();
            return new string(organization.Where(c => !invalidChars.Contains(c)).ToArray());
        }

        public override string DefaultToken { get => base.DefaultToken; set => base.DefaultToken = value; }
    }
}
