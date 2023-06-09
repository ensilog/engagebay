using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Properties;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Tickets
{
    public class Ticket : PageableObject
    {
        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [JsonPropertyName("type")]
        public int? Type { get; set; }

        [JsonPropertyName("priority")]
        public int? Priority { get; set; }

        [JsonPropertyName("status")]
        public int? Status { get; set; }

        [JsonPropertyName("group_id")]
        public int? GroupId { get; set; }

        [JsonPropertyName("assignee_id")]
        public int? AssigneeId { get; set; }

        [JsonPropertyName("html_body")]
        public string HtmlBody { get; set; }

        public override IEnumerable<Property> ExtractAllProperties()
        {
            foreach (var baseProp in base.ExtractAllProperties())
            {
                yield return baseProp;
            }

            if (Subject != null)
                yield return TicketKnownProperties.Subject.WithValue(Subject);

            if (Type != null)
                yield return TicketKnownProperties.Type.WithValue(Type.Value);

            if (Priority != null)
                yield return TicketKnownProperties.Priority.WithValue(Priority.Value);

            if (Status != null)
                yield return TicketKnownProperties.Status.WithValue(Status.Value);

            if (GroupId != null)
                yield return TicketKnownProperties.GroupId.WithValue(GroupId.Value);

            if (AssigneeId != null)
                yield return TicketKnownProperties.AssigneeId.WithValue(AssigneeId.Value);

            if (HtmlBody != null)
                yield return TicketKnownProperties.HtmlBody.WithValue(HtmlBody);
        }

    }
}
