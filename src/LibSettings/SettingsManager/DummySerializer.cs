using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace LibSettings.Builders
{
    internal class DummySerializer<TSettings> : ISettingsSerializer<TSettings> where TSettings: ISettings, new()
    {
        public string? SuggestedFileExtension => null;

        public Task<TSettings> Load(Stream stream, CancellationToken cancellationToken = default)
            => Task.FromResult(new TSettings());

        public Task Save(Stream stream, TSettings settings, CancellationToken cancellationToken = default)
            => Task.CompletedTask;
    }
}