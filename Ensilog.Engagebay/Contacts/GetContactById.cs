using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Contacts.Exceptions;

namespace Ensilog.Engagebay.Contacts
{
    public class GetContactById : EngageBayQuery<Contact>
    {
        private ulong _idToRequest;

        public override string Uri => $"/dev/api/panel/subscribers/{_idToRequest}";

        public GetContactById(ulong id)
        {
            if (id <= 0)
            {
                throw new ContactIdInvalidException();
            }

            _idToRequest = id;
        }
    }
}
