using Ensilog.Engagebay.Properties;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Contacts
{
    public class BatchContact
    {
        [JsonPropertyName("score")]
        public int? Score { get; set; }

        [JsonPropertyName("properties")]
        public IEnumerable<Property> Properties { get; set; }

        [JsonPropertyName("tags")]
        public IEnumerable<string> Tags { get; set; }

        public BatchContact(IEnumerable<Property> properties, IEnumerable<string> tags = null, int? score = null)
        {
            Score = score;
            Properties = properties;
            Tags = tags;
        }
    }
}
