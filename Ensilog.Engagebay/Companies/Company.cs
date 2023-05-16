using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Json;
using Ensilog.Engagebay.Tags;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Companies
{
    public class Company : PageableObject
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("address")]
        [JsonConverter(typeof(AddressStringToAddressDataConverter))]
        public string Address { get; set; }

        [JsonPropertyName("owner_id")]
        public string OwnerId { get; set; }
    }
}
