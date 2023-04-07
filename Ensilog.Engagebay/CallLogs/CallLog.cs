using Ensilog.Engagebay.Notes;
using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.CallLogs
{

    public class CallLog
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("created_time")]
        public long CreatedTime { get; set; }

        [JsonPropertyName("contact_id")]
        public long ContactId { get; set; }

        [JsonPropertyName("call_id")]
        public string CallId { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("status_legacy")]
        public string StatusLegacy { get; set; }

        [JsonPropertyName("to_number")]
        public string ToNumber { get; set; }

        [JsonPropertyName("from_number")]
        public string FromNumber { get; set; }

        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonPropertyName("caller_type")]
        public string CallerType { get; set; }

        [JsonPropertyName("started_at")]
        public long StartedAt { get; set; }

        [JsonPropertyName("recording_url")]
        public string RecordingUrl { get; set; }

        [JsonPropertyName("isManualEntry")]
        public bool IsManualEntry { get; set; }

        [JsonPropertyName("owner_id")]
        public long OwnerId { get; set; }

        [JsonPropertyName("notes")]
        public Note[] Notes { get; set; }

        [JsonPropertyName("note")]
        public Note Note { get; set; }

        [JsonPropertyName("addNote")]
        public bool AddNote { get; set; }

        [JsonPropertyName("forceUpdate")]
        public bool ForceUpdate { get; set; }

        [JsonPropertyName("sendNotificationsTo")]
        public object[] SendNotificationsTo { get; set; }

        [JsonPropertyName("isVoicemail")]
        public bool IsVoicemail { get; set; }

        [JsonPropertyName("callType")]
        public string CallType { get; set; }

        [JsonPropertyName("reflectStatus")]
        public bool ReflectStatus { get; set; }

        [JsonPropertyName("call_cost")]
        public float CallCost { get; set; }

        [JsonPropertyName("inActive")]
        public bool InActive { get; set; }
    }
}
