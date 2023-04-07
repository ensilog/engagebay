using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Json;
using System;
using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Notes
{
    public class Note : PageableObject
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("parentId")]
        public long ParentId { get; set; }

        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("force")]
        public bool Force { get; set; }

        [JsonPropertyName("syncIds")]
        public long[] SyncIds { get; set; }

        [JsonPropertyName("owner_id")]
        public long OwnerId { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("created_time")]
        [JsonConverter(typeof(UnixEpochDateTimeConverter))]
        public DateTime CreatedTime { get; set; }

        [JsonPropertyName("updated_time")]
        [JsonConverter(typeof(UnixEpochDateTimeConverter))]
        public DateTime UpdatedTime { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("createFollowUpTask")]
        public bool CreateFollowUpTask { get; set; }
    }
}
