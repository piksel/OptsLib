using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;

namespace OptsLib.StoreResolvers
{
    public class SimpleAppOptionsResolver : FileSystemStoreResolver
    {
        private readonly ILogger logger = OptionsLogger.GetLogger(nameof(SimpleAppOptionsResolver));
        static string LocalAppData => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public SimpleAppOptionsResolver(ISettingsSerializer serializer, string organization, string appName) 
            : base(serializer, new DirectoryInfo(Path.Combine(LocalAppData, CleanedPathName(organization), CleanedPathName(appName)))) 
        {

            logger.LogInformation("Resolved organization {Organization}, and app name {AppName} to {DataPath}", organization, appName, StoreRoot.FullName);
        }

        private static string CleanedPathName(string organization)
        {
            var invalidChars = Path.GetInvalidFileNameChars();
            return new string(organization.Where(c => !invalidChars.Contains(c)).ToArray());
        }
    }
}
