using Ensilog.Engagebay.Addresses;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Json
{
    public sealed class AddressStringToAddressDataConverter : JsonConverter<Address>
    {
        public override Address Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var stringAddress = reader.GetString();
            if (!string.IsNullOrEmpty(stringAddress))
            {
                return JsonSerializer.Deserialize<Address>(stringAddress);
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, Address value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(JsonSerializer.Serialize(value));
        }
    }
}
