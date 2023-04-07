using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Contacts.Exceptions;

namespace Ensilog.Engagebay.Contacts
{
    public class CreateContact : EngageBayCommand<CreateContactBody>
    {
        public override string Uri => "/dev/api/panel/subscribers/subscriber";

        public override CreateContactBody Body => _body;

        private CreateContactBody _body;

        public CreateContact(Contact contactToCreate)
        {
            if (contactToCreate == null)
                throw new ContactNullException();


            _body = new CreateContactBody();

            if (string.IsNullOrEmpty(contactToCreate.FirstName))
            {
                throw new ContactFirstNameNullException();
            }

            _body.Properties = contactToCreate.ExtractAllProperties();
            _body.Tags = contactToCreate.Tags;
            _body.CompanyIds = contactToCreate.CompanyIds;
        }
    }
}
