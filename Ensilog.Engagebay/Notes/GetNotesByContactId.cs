using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Contacts.Exceptions;

namespace Ensilog.Engagebay.Notes
{
    public class GetNotesByContactId : PageableEngageBayQuery<Note>
    {
        public long ContactId { get; }

        public GetNotesByContactId(long contactId, int pageSize = 1000, string sortKey = "created_time", bool ascendingSort = true) :
            base(pageSize, sortKey, ascendingSort)
        {
            if (contactId <= 0)
                throw new ContactIdInvalidException();

            ContactId = contactId;
        }

        public override string Uri => $"/dev/api/panel/notes/{ContactId}?{GeneratePageConfigString()}";
    }
}