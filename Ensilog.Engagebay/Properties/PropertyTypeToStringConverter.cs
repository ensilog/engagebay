using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Properties
{
    public class PropertyTypeToStringConverter : JsonConverter<PropertyType>
    {
        public override PropertyType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var fieldString = reader.GetString();

            switch (fieldString)
            {
                case "SYSTEM":
                    return PropertyType.SYSTEM;
                case "CUSTOM":
                    return PropertyType.CUSTOM;
                default:
                    return PropertyType.UNKNOWN;
            }
        }

        public override void Write(Utf8JsonWriter writer, PropertyType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Type);
        }
    }
}
