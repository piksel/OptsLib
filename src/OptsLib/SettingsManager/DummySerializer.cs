using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace OptsLib.Builders
{
    internal class DummySerializer<TOptions> : ISettingsSerializer<TOptions> where TOptions: class, IOptions, new()
    {
        public string? SuggestedFileExtension => null;

        public Task<TOptions?> Load(Stream stream, CancellationToken cancellationToken = default)
            => Task.FromResult<TOptions?>(new TOptions());

        public Task Save(Stream stream, TOptions settings, CancellationToken cancellationToken = default)
            => Task.CompletedTask;
    }
}