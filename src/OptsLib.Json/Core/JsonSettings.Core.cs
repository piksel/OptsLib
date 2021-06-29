using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace OptsLib.Serialization.Json
{
    public class JsonSettingsSerializer<TOptions>: ISettingsSerializer<TOptions> where TOptions: class, IOptions
    {
        public string? SuggestedFileExtension => "json";

        public JsonSettingsSerializer(JsonSerializerOptions? serializerOptions = null)
        {
            SerializerOptions = serializerOptions ?? new JsonSerializerOptions();
            SerializerOptions.Converters.Add(new JsonStringEnumConverter());
            SerializerOptions.Converters.Add(new JsonPointConverter());
        }

        public JsonSerializerOptions SerializerOptions { get; private set; }

        public async Task<TOptions?> Load(Stream stream, CancellationToken cancellationToken = default) 
            => await JsonSerializer.DeserializeAsync<TOptions>(stream, SerializerOptions, cancellationToken);

        public async Task Save(Stream stream, TOptions settings, CancellationToken cancellationToken = default) 
            => await JsonSerializer.SerializeAsync(stream, settings, SerializerOptions, cancellationToken);
    }
}
