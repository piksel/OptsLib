using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibSettings.StoreResolvers
{
    public interface IStoreResolver
    {
        public Task<Stream> OpenReadStream(string? storeToken = null, CancellationToken? cancellationToken = null);
        
        public Task<Stream> OpenWriteStream(string? storeToken = null, CancellationToken? cancellationToken = null);

        public Task<bool> ItemExists(string? storeToken = null, CancellationToken? cancellationToken = null);
    }
}
