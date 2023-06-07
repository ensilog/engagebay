using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Companies.Exceptions;
using Ensilog.Engagebay.Contacts.Exceptions;
using RestSharp;
using System.Text.RegularExpressions;

namespace Ensilog.Engagebay.Companies
{
    public class AddContactToCompanyByEmail : EngageBayCommand
    {
        public override string Uri => $"/dev/api/panel/companies/{_companyId}/add-contact-by-contactEmail";
        public override Method Method => Method.Post;
        public override string ContentType => "application/x-www-form-urlencoded";

        public override string Body => $"companyId={_companyId}&contactEmail={_contactEmail}";

        private long _companyId;
        private string _contactEmail;

        public AddContactToCompanyByEmail(long companyId, string contactEmail)
        {
            if (companyId < 0)
                throw new CompanyIdInvalidException();

            if (string.IsNullOrEmpty(contactEmail))
                throw new ContactEmailNullException();

            _companyId = companyId;
            _contactEmail = contactEmail;
        }
    }

}
