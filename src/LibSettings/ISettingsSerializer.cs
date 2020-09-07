using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace LibSettings
{
    public interface ISettingsSerializer
    {
        public string? SuggestedFileExtension { get; }
    }

    public interface ISettingsSerializer<TSettings>: ISettingsSerializer
    {
        Task<TSettings> Load(Stream stream, CancellationToken cancellationToken = default);
        Task Save(Stream stream, TSettings settings, CancellationToken cancellationToken = default);
    }
}
