using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Abstractions
{
    public abstract class PageableObject
    {
        [JsonPropertyName("cursor")]
        public string Cursor { get; set; }
    }
}
