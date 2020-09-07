using Microsoft.Extensions.Logging;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace LibSettings.Serialization.Json.Core
{
    public class JsonSettingsSerializer<TSettings>: ISettingsSerializer<TSettings> where TSettings: ISettings
    {
        ILogger log = SettingsLogger.GetLogger("JsonSettingsSerializerCore");
        public string? SuggestedFileExtension => "json";

        public JsonSettingsSerializer(JsonSerializerOptions? serializerOptions = null)
        {
            SerializerOptions = serializerOptions ?? new JsonSerializerOptions();
            SerializerOptions.Converters.Add(new JsonStringEnumConverter());
            SerializerOptions.Converters.Add(new JsonPointConverter());
        }

        public JsonSerializerOptions SerializerOptions { get; private set; }

        public async Task<TSettings> Load(Stream stream, CancellationToken cancellationToken = default) 
            => await JsonSerializer.DeserializeAsync<TSettings>(stream, SerializerOptions, cancellationToken);

        public async Task Save(Stream stream, TSettings settings, CancellationToken cancellationToken = default) 
            => await JsonSerializer.SerializeAsync(stream, settings, SerializerOptions, cancellationToken);
    }
}
