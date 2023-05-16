using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Tags;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Tickets
{
    public class Ticket : PageableObject
    {
        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("priority")]
        public int Priority { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("group_id")]
        public int GroupId { get; set; }

        [JsonPropertyName("assignee_id")]
        public int AssigneeId { get; set; }

        [JsonPropertyName("html_body")]
        public string HtmlBody { get; set; }
    }
}
