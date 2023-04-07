using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Contacts.Exceptions;
using System.Collections.Generic;

namespace Ensilog.Engagebay.CallLogs
{
    public class GetContactCallLogs : EngageBayQuery<List<CallLog>>
    {
        public long ContactId { get; }

        public GetContactCallLogs(long contactId)
        {
            if (contactId <= 0)
                throw new ContactIdInvalidException();

            ContactId = contactId;
        }

        public override string Uri => $"/dev/api/panel/call-logs?contact_id={ContactId}";
    }

}
