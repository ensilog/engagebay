using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Companies.Exceptions;
using Ensilog.Engagebay.Contacts.Exceptions;
using RestSharp;

namespace Ensilog.Engagebay.Companies
{
    public class AddContactToCompany : EngageBayCommand
    {
        public override string Uri => $"/dev/api/panel/companies/{_companyId}/add-contact-by-contactId";
        public override Method Method => Method.Post;
        public override string ContentType => "application/x-www-form-urlencoded";

        public override string Body => $"companyId={_companyId}&contactId={_contactId}";

        private long _companyId;
        private long _contactId;

        public AddContactToCompany(long companyId, long contactId)
        {
            if (companyId < 0)
                throw new CompanyIdInvalidException();

            if (contactId < 0)
                throw new ContactIdInvalidException();

            _companyId = companyId;
            _contactId = contactId;
        }
    }

}
