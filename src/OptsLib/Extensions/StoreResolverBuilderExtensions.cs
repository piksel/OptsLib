using OptsLib.Builders;
using OptsLib.StoreResolvers;
using System.IO;
using System.Linq;
using System.Reflection;

namespace OptsLib
{
    public static class StoreResolverBuilderExtensions
    {
        public static SimpleAppOptionsResolver UseSimpleAppOptions(this IStoreResolverBuilder b, string organization, string appName)
            => new SimpleAppOptionsResolver(b.Serializer, organization, appName);

        public static SimpleAppOptionsResolver UseSimpleAppOptions<TApp>(this IStoreResolverBuilder b)
        {
            var type = typeof(TApp);
            var assembly = type.Assembly;

            if (!(type.Assembly.GetCustomAttribute<AssemblyCompanyAttribute>()?.Company is { } organization))
            {
                organization = typeof(TApp).Namespace;
            }

            if (!(type.Assembly.GetCustomAttribute<AssemblyProductAttribute>()?.Product is { } appName))
            {
                appName = assembly.GetName().Name.Split('.').Last();
            }

            return new SimpleAppOptionsResolver(b.Serializer, organization, appName);
        }

        public static FileSystemStoreResolver UseFileSystem(this IStoreResolverBuilder b, string rootPath)
            => new FileSystemStoreResolver(b.Serializer, new DirectoryInfo(rootPath));


    }
}
