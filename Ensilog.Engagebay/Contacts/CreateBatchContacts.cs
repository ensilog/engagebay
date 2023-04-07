using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Contacts.Exceptions;
using Ensilog.Engagebay.Tags;
using System.Collections.Generic;
using System.Linq;

namespace Ensilog.Engagebay.Contacts
{
    public class CreateBatchContacts : EngageBayCommand<CreateBatchContactsBody, EngageBayAsyncResponse>
    {
        public string CallbackUrl { get; }
        public Tag DefaultTag { get; }
        public IReadOnlyList<Contact> Contacts { get; }

        public CreateBatchContacts(IEnumerable<Contact> contacts, string defaultTag = "csharp_import", string callbackUrl = null)
        {
            if (contacts == null || contacts.Count() == 0 || contacts.Count() > 100)
            {
                throw new ContactBatchInvalidSizeException();
            }

            if (!string.IsNullOrWhiteSpace(defaultTag))
            {
                DefaultTag = new Tag(defaultTag);
            }

            Contacts = contacts.ToArray();
            CallbackUrl = callbackUrl;
        }

        public override string Uri => $"/dev/api/panel/subscribers/subscriber-batch";

        public override CreateBatchContactsBody Body => new CreateBatchContactsBody(Contacts, DefaultTag, CallbackUrl);
    }
}
