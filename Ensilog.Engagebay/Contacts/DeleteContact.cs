using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Contacts.Exceptions;
using RestSharp;

namespace Ensilog.Engagebay.Contacts
{
    public class DeleteContact : EngageBayCommand
    {
        public override string Uri => $"dev/api/panel/subscribers/{_contactId}";

        public override Method Method => Method.Delete;

        private long _contactId;

        public DeleteContact(long contactId)
        {
            if (contactId <= 0)
                throw new ContactIdInvalidException();

            _contactId = contactId;
        }
    }
}
