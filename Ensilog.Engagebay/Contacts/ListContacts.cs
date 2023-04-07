using Ensilog.Engagebay.Abstractions;
using RestSharp;

namespace Ensilog.Engagebay.Contacts
{
    public class ListContacts : PageableEngageBayQuery<Contact>
    {
        public override Method Method => Method.Post;

        public override string Uri => $"/dev/api/panel/subscribers";

        public override string Body => GeneratePageConfigString();

        public override string ContentType => "application/x-www-form-urlencoded";


        public ListContacts(int pageSize, string sortKey = "created_time", bool ascendingSort = true)
            : base(pageSize, sortKey, ascendingSort)
        {
        }
    }
}
