using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibSettings.StoreResolvers
{
    public class FileSystemStoreResolver : IStoreResolver
    {
        private ILogger logger = SettingsLogger.GetLogger(nameof(FileSystemStoreResolver));
        protected DirectoryInfo storeRoot;

        public virtual string DefaultToken { get; set; }

        public virtual FileInfo GetFile(string? storeToken)
            => new FileInfo(Path.Combine(storeRoot.FullName, storeToken ?? DefaultToken));

        public FileSystemStoreResolver(ISettingsSerializer serializer, DirectoryInfo rootPath)
        {
            storeRoot = rootPath;
            if(!(serializer.SuggestedFileExtension is string ext))
            {
                ext = "store";
            }
            DefaultToken = $"settings.{ext}";
        }

        public virtual Task<bool> ItemExists(string? storeToken = null, CancellationToken? cancellationToken = null)
            => Task.FromResult(GetFile(storeToken).Exists);

        public virtual Task<Stream> OpenReadStream(string? storeToken = null, CancellationToken? cancellationToken = null)
            => Task.FromResult(GetFile(storeToken).Open(FileMode.Open, FileAccess.Read, FileShare.Read) as Stream);

        public virtual Task<Stream> OpenWriteStream(string? storeToken = null, CancellationToken? cancellationToken = null)
        {
            storeRoot.Create();
            return Task.FromResult(GetFile(storeToken).Open(FileMode.Create, FileAccess.Write, FileShare.None) as Stream);
        }
    }
}
