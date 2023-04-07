using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Json;
using Ensilog.Engagebay.Tags.Exceptions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Ensilog.Engagebay.Tags
{
    public class Tag : ValueObject
    {
        [JsonPropertyName("tag")]
        public string TagValue { get; set; }

        [JsonPropertyName("assigned_time")]
        [JsonConverter(typeof(UnixEpochDateTimeConverter))]
        public DateTime AssignedTime { get; set; }

        // Tag can only start with alpha char and can only contains underscore as special characters
        private Regex _validTagRegex = new Regex("^[a-zA-Z][a-zA-Z0-9_ ]*$");

        public Tag() { }

        public Tag(string tag)
        {
            if (!_validTagRegex.IsMatch(tag))
                throw new TagNameInvalidFormatException();

            TagValue = tag;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return TagValue;
        }

        public override string ToString()
        {
            return TagValue;
        }
    }
}
