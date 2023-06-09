using Ensilog.Engagebay.Properties;
using Ensilog.Engagebay.Tags;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Companies
{
    public class CreateCompanyBody
    {
        [JsonPropertyName("properties")]
        public IEnumerable<Property> Properties { get; set; }

        [JsonPropertyName("tags")]
        public IEnumerable<Tag> Tags { get; set; }
    }
}
