using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using RestSharp;
using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Contacts.Exceptions;
using Ensilog.Engagebay.Tags.Exceptions;

namespace Ensilog.Engagebay.Tags
{
    public class DeleteTagsToContactsByEmail : EngageBayCommand<string>
    {
        public override string Uri => "/dev/api/panel/subscribers/email/tags/delete";

        public override string Body => $"email={_email}&tags={JsonSerializer.Serialize(_tags.Select(t => t.TagValue))}";

        public override string ContentType => "application/x-www-form-urlencoded";

        public override Method Method => Method.Post;

        private string _email;
        private IEnumerable<Tag> _tags;

        public DeleteTagsToContactsByEmail(string email, params string[] tags)
        {
            if (string.IsNullOrEmpty(email))
                throw new ContactEmailNullException();

            if (tags == null || tags.Length == 0)
                throw new NoTagHasBeenProvidedException();

            _tags = tags.Select(tName => new Tag(tName));
            _email = email;
        }
    }
}
