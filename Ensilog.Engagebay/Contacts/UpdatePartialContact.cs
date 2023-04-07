using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Contacts.Exceptions;

namespace Ensilog.Engagebay.Contacts
{
    public class UpdatePartialContact : EngageBayCommand<UpdatePartialContactBody>
    {
        public override string Uri => "dev/api/panel/subscribers/update-partial";

        public override UpdatePartialContactBody Body => _body;

        private UpdatePartialContactBody _body;

        public UpdatePartialContact(long contactIdToUpdate, Contact contactToUseAsReference)
        {
            if (contactIdToUpdate <= 0)
                throw new ContactIdInvalidException();
            if (contactToUseAsReference == null)
                throw new ContactNullException();

            _body = new UpdatePartialContactBody();

            _body.Id = contactIdToUpdate;
            _body.Properties = contactToUseAsReference.ExtractAllProperties();
        }
    }
}
