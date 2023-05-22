using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Json;
using Ensilog.Engagebay.Properties;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Notes
{
    public class Note : PageableObject
    {
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

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("createFollowUpTask")]
        public bool CreateFollowUpTask { get; set; }

        public override IEnumerable<Property> ExtractAllProperties()
        {
            throw new NotImplementedException();
        }
    }
}
