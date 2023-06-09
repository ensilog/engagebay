using Ensilog.Engagebay.Properties;
using static Ensilog.Engagebay.Properties.PropertyFactory;

namespace Ensilog.Engagebay.Tickets
{
    public static class TicketKnownProperties
    {
        public static Property Subject => CreateSystemProperty("subject");
        public static Property Type => CreateSystemProperty("type");
        public static Property Priority => CreateSystemProperty("priority");
        public static Property Status => CreateSystemProperty("status");
        public static Property GroupId => CreateSystemProperty("group_id");
        public static Property AssigneeId => CreateSystemProperty("assignee_id");
        public static Property HtmlBody => CreateSystemProperty("html_body");
    }

}
