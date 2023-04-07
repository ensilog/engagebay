using Ensilog.Engagebay.Properties;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Contacts
{
    public class UpdatePartialContactBody
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("properties")]
        public IEnumerable<Property> Properties { get; set; }
    }
}
