using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace OptsLib
{
    public interface ISettingsSerializer
    {
        public string? SuggestedFileExtension { get; }
    }

    public interface ISettingsSerializer<TOptions>: ISettingsSerializer where TOptions: class
    {
        Task<TOptions?> Load(Stream stream, CancellationToken cancellationToken = default);
        Task Save(Stream stream, TOptions settings, CancellationToken cancellationToken = default);
    }
}
