using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Contacts.Exceptions;
using System.Collections.Generic;

namespace Ensilog.Engagebay.Tags
{
    public class ListContactTagsById : EngageBayQuery<IEnumerable<Tag>>
    {
        public long ContactId { get; }

        public ListContactTagsById(long contactId)
        {
            if (contactId <= 0)
                throw new ContactIdInvalidException();

            ContactId = contactId;
        }

        public override string Uri => $"dev/api/panel/subscribers/get-tags-by-id/{ContactId}";
    }

}
