using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Contacts.Exceptions;
using Ensilog.Engagebay.Tags.Exceptions;
using RestSharp;
using System.Collections.Generic;

namespace Ensilog.Engagebay.Tags
{
    public class DeleteContactTagsById : EngageBayCommand<IEnumerable<Tag>>
    {
        public long ContactId { get; }
        public List<Tag> Tags { get; }

        public DeleteContactTagsById(long contactId, List<Tag> tags)
        {
            if (contactId <= 0)
            {
                throw new ContactIdInvalidException();
            }
            if (tags == null || tags.Count == 0)
            {
                throw new NoTagHasBeenProvidedException();
            }

            ContactId = contactId;
            Tags = tags;
        }

        public override string Uri => $"dev/api/panel/subscribers/contact/tags/delete/{ContactId}";

        public override Method Method => Method.Post;

        public override IEnumerable<Tag> Body => Tags;

        public override string ContentType => "application/json";
    }

}
