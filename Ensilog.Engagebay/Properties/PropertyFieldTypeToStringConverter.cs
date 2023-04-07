using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Properties
{
    public class PropertyFieldTypeToStringConverter : JsonConverter<PropertyFieldType>
    {
        public override PropertyFieldType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var fieldString = reader.GetString();

            switch (fieldString)
            {
                case "TEXT":
                    return PropertyFieldType.TEXT;
                case "DATE":
                    return PropertyFieldType.DATE;
                case "LIST":
                    return PropertyFieldType.LIST;
                case "CHECKBOX":
                    return PropertyFieldType.CHECKBOX;
                case "TEXTAREA":
                    return PropertyFieldType.TEXTAREA;
                case "NUMBER":
                    return PropertyFieldType.NUMBER;
                case "CURRENCY":
                    return PropertyFieldType.CURRENCY;
                case "MULTICHECKBOX":
                    return PropertyFieldType.MULTICHECKBOX;
                case "URL":
                    return PropertyFieldType.URL;
                case "PHONE":
                    return PropertyFieldType.PHONE;
                case "FILE":
                    return PropertyFieldType.FILE;
                default:
                    return PropertyFieldType.UNKNOWN;
            }
        }

        public override void Write(Utf8JsonWriter writer, PropertyFieldType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.FieldType);
        }
    }
}
