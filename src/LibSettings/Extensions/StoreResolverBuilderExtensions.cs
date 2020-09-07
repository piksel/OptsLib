using LibSettings.Builders;
using LibSettings.StoreResolvers;
using System.IO;
using System.Linq;
using System.Reflection;

namespace LibSettings
{
    public static partial class StoreResolverBuilderExtensions
    {
        public static SimpleAppSettingsResolver UseSimpleAppSettings(this IStoreResolverBuilder b, string organization, string appName)
            => new SimpleAppSettingsResolver(b.Serializer, organization, appName);

        public static SimpleAppSettingsResolver UseSimpleAppSettings<TApp>(this IStoreResolverBuilder b)
        {
            var type = typeof(TApp);
            var assembly = type.Assembly;
            var ca = type.Assembly.CustomAttributes;

            if (!(type.Assembly.GetCustomAttribute<AssemblyCompanyAttribute>()?.Company is string organization))
            {
                organization = typeof(TApp).Namespace;
            }

            if (!(type.Assembly.GetCustomAttribute<AssemblyProductAttribute>()?.Product is string appName))
            {
                appName = assembly.GetName().Name.Split('.').Last();
            }

            return new SimpleAppSettingsResolver(b.Serializer, organization, appName);
        }

        public static FileSystemStoreResolver UseFileSystem(this IStoreResolverBuilder b, string rootPath)
            => new FileSystemStoreResolver(b.Serializer, new DirectoryInfo(rootPath));


    }
}
