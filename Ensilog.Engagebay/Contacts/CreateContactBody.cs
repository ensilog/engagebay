using Ensilog.Engagebay.Properties;
using Ensilog.Engagebay.Tags;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Contacts
{
    public class CreateContactBody
    {
        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonPropertyName("properties")]
        public IEnumerable<Property> Properties { get; set; }

        [JsonPropertyName("tags")]
        public IEnumerable<Tag> Tags { get; set; }

        public IEnumerable<long> CompanyIds { get; set; }
    }
}
