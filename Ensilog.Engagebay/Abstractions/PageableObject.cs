using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Abstractions
{
    public abstract class PageableObject : EngagebayObject
    {
        [JsonPropertyName("cursor")]
        public string Cursor { get; set; }
    }
}
