﻿using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace OptsLib.StoreResolvers
{
    public class DummyStore : IStoreResolver
    {
        public Task<bool> ItemExists(string? storeToken = null, CancellationToken? cancellationToken = null)
            => Task.FromResult(false);

        public Task<Stream> OpenReadStream(string? storeToken = null, CancellationToken? cancellationToken = null)
            => Task.FromResult(new MemoryStream() as Stream);

        public Task<Stream> OpenWriteStream(string? storeToken = null, CancellationToken? cancellationToken = null)
            => Task.FromResult(new MemoryStream() as Stream);
    }
}
