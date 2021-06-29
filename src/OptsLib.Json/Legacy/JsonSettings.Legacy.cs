using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace OptsLib.Serialization.Json
{
    public class JsonSettingsSerializer<TOptions>: ISettingsSerializer<TOptions> where TOptions: class, IOptions
    {
        JsonSerializer jsonSerializer;
        private readonly ILogger logger;
        private JsonSerializerSettings serializerSettings;

        public string? SuggestedFileExtension => "json";

        public JsonSettingsSerializer(JsonSerializerSettings? serializerSettings = null)
        {
            logger = OptionsLogger.GetLogger("JsonSettingsSerializerLegacy");
            this.serializerSettings = serializerSettings ?? new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver(),
                Formatting = Formatting.Indented,
            };

            this.serializerSettings.Converters.Add(new StringEnumConverter());

            //jsonSerializer = new JsonSerializer();
            
            
            jsonSerializer = JsonSerializer.CreateDefault(this.serializerSettings);
            logger.LogDebug("Created new Legacy (NewtonSoft) JSON serializer");
        }

        public JsonSerializerSettings SerializerSettings {
            get => serializerSettings;
            set
            {
                serializerSettings = value;
                jsonSerializer = JsonSerializer.CreateDefault(serializerSettings);
            }
        }

        public async Task<TOptions?> Load(Stream stream, CancellationToken cancellationToken = default)
        {
            logger.LogDebug("Loading JSON stream");

            using var ms = new MemoryStream();
            await stream.CopyToAsync(ms, 81920, cancellationToken);
            
            ms.Seek(0, SeekOrigin.Begin);

            using var sr = new StreamReader(ms);
            using var jr = new JsonTextReader(sr);

            logger.LogDebug("Read {BytesRead} byte(s)", ms.Length);

            var result = jsonSerializer.Deserialize<TOptions>(jr);

            return result;
        }

        public async Task Save(Stream stream, TOptions settings, CancellationToken cancellationToken = default)
        {
            //using var ms = new MemoryStream();
            using var sw = new StreamWriter(stream);
            var jw = new JsonTextWriter(sw)
            {
                Indentation = 2,
                IndentChar = ' ',
                Formatting = Formatting.Indented,
                
            };
            jsonSerializer.Serialize(jw, settings);

            //await ms.CopyToAsync(stream, 81920, cancellationToken);
            await stream.FlushAsync();
        }
    }
}
