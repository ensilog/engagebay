using Ensilog.Engagebay.Contacts.Exceptions;
using Ensilog.Engagebay.Tags;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Contacts
{
    public class CreateBatchContactsBody
    {
        [JsonPropertyName("callbackURL")]
        public string CallbackUrl { get; set; }

        private List<BatchContact> _contacts;
        [JsonPropertyName("contacts")]
        public IEnumerable<BatchContact> Contacts { get { return _contacts.AsReadOnly(); } }

        private string[] _additionalTags;

        public CreateBatchContactsBody(IEnumerable<Contact> contacts, Tag tagForWholeBatch = null, string callBackUrl = null)
        {
            if (contacts == null || contacts.Count() == 0 || contacts.Count() > 100)
            {
                throw new ContactBatchInvalidSizeException();
            }

            _additionalTags = tagForWholeBatch == null ? new string[0] : new string[] { tagForWholeBatch.TagValue };

            CallbackUrl = callBackUrl;
            _contacts = contacts.Select(ToBatchContact).ToList();
        }

        private BatchContact ToBatchContact(Contact c)
        {
            return new BatchContact(c.ExtractAllProperties(), _additionalTags.Concat(c.Tags?.Select(t => t.TagValue) ?? new string[0]), c.Score);
        }
    }
}
