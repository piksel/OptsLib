using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace OptsLib.StoreResolvers
{
    public class FileSystemStoreResolver : IStoreResolver
    {
        private readonly ILogger logger = OptionsLogger.GetLogger(nameof(FileSystemStoreResolver));
        protected DirectoryInfo StoreRoot;

        private readonly string extension;

        public virtual string DefaultToken => $"settings.{extension}";



        public virtual FileInfo GetFile(string? storeToken)
            => new FileInfo(Path.Combine(StoreRoot.FullName, storeToken ?? DefaultToken));

        public FileSystemStoreResolver(ISettingsSerializer serializer, DirectoryInfo rootPath)
        {
            StoreRoot = rootPath;
            extension = serializer.SuggestedFileExtension ?? "store";
        }

        public virtual Task<bool> ItemExists(string? storeToken = null, CancellationToken? cancellationToken = null)
            => Task.FromResult(GetFile(storeToken).Exists);

        public virtual Task<Stream> OpenReadStream(string? storeToken = null, CancellationToken? cancellationToken = null)
            => Task.FromResult(GetFile(storeToken).Open(FileMode.Open, FileAccess.Read, FileShare.Read) as Stream);

        public virtual Task<Stream> OpenWriteStream(string? storeToken = null, CancellationToken? cancellationToken = null)
        {
            StoreRoot.Create();
            return Task.FromResult(GetFile(storeToken).Open(FileMode.Create, FileAccess.Write, FileShare.None) as Stream);
        }
    }
}
