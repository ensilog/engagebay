using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Contacts.Exceptions;
using Ensilog.Engagebay.Tags.Exceptions;
using RestSharp;
using System.Collections.Generic;
using System.Text.Json;

namespace Ensilog.Engagebay.Tags
{
    public class AddTagsToContactById : EngageBayCommand
    {
        public long ContactId { get; }
        public List<Tag> Tags { get; }

        public AddTagsToContactById(long contactId, List<Tag> tags)
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

        public override string Uri => $"dev/api/panel/subscribers/contact/tags/add2/{ContactId}";
        public override Method Method => Method.Post;
        public override string ContentType => "application/json";
        public override string Body => JsonSerializer.Serialize(Tags);
    }
}
