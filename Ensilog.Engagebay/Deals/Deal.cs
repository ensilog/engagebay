using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Json;
using Ensilog.Engagebay.Tags;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Deals
{
    public class Deal : PageableObject
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("unique_id")]
        public int UniqueId { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("track_id")]
        public int TrackId { get; set; }

        [JsonPropertyName("amount")]
        public float Amount { get; set; }

        [JsonPropertyName("currency_type")]
        public string Currency { get; set; }

        [JsonPropertyName("closed_date")]
        [JsonConverter(typeof(UnixEpochDateTimeConverter))]
        public DateTime ClosedDate { get; set; }

        [JsonPropertyName("owner_id")]
        public string OwnerId { get; set; }
    }
}
