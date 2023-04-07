using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Addresses
{
    public class Address
    {
        [JsonPropertyName("address")]
        public string AddressLine { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("zip")]
        public string Zip { get; set; }
    }
}
