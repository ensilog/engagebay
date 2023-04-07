using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Abstractions
{
    public class EngageBayAsyncResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
