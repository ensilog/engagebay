using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Contacts.Exceptions;
using System.Collections.Generic;

namespace Ensilog.Engagebay.Contacts
{
    public class GetContactsByEmail : EngageBayQuery<IEnumerable<Contact>>
    {
        public override string Uri => $"/dev/api/panel/subscribers/contact-by-email/{_emailToSearch}";

        private string _emailToSearch;

        public GetContactsByEmail(string emailToSearch)
        {
            if (string.IsNullOrEmpty(emailToSearch))
            {
                throw new ContactEmailNullException();
            }

            _emailToSearch = emailToSearch;
        }
    }
}
