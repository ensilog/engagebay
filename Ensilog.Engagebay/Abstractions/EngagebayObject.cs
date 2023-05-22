using Ensilog.Engagebay.Json;
using Ensilog.Engagebay.Properties;
using Ensilog.Engagebay.Tags;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Abstractions
{
    public abstract class EngagebayObject
    {
        [JsonPropertyName("id")]
        public ulong Id { get; set; }

        [JsonPropertyName("created_time")]
        [JsonConverter(typeof(UnixEpochDateTimeConverter))]
        public DateTime CreatedTime { get; set; }

        [JsonPropertyName("updated_time")]
        [JsonConverter(typeof(UnixEpochDateTimeConverter))]
        public DateTime UpdatedTime { get; set; }

        [JsonPropertyName("score")]
        public int? Score { get; set; }

        [JsonPropertyName("tags")]
        public IEnumerable<Tag> Tags { get; set; }

        [JsonPropertyName("properties")]
        public IEnumerable<Property> OtherProperties { get; set; }

        public virtual IEnumerable<Property> ExtractAllProperties()
        {
            if (Score.HasValue)
                yield return EngagebayKnownProperties.Score.WithValue(Score.Value);

            if (CreatedTime != default)
                yield return EngagebayKnownProperties.CreatedTime.WithValue(CreatedTime);

            if (UpdatedTime != default)
                yield return EngagebayKnownProperties.UpdatedTime.WithValue(UpdatedTime);

            if (OtherProperties != null)
                foreach (var property in OtherProperties)
                    yield return property;
        }
    }
}
