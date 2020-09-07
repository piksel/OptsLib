using SettingsEditor.Serializers;
using System;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LibSettings.Serialization.Json.Core
{
    internal class JsonPointConverter : JsonConverter<Point?>
    {

        public override Point? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                if (PointSerializer.TryParse(reader.GetString(), out Point? value, out string? reason))
                {
                    return value;
                }
                else
                {
                    throw new JsonException(reason);
                }
            }
            else
            {
                reader.Skip();
                return null;
            }
        }

        public override void Write(Utf8JsonWriter writer, Point? value, JsonSerializerOptions options)
        {
            if (value.HasValue) 
            {
                writer.WriteStringValue(PointSerializer.WriteValue(value));
            } 
            else
            {
                writer.WriteNullValue();
            }
        }
    }
}