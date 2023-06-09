using System;

namespace Ensilog.Engagebay.Contacts.Exceptions
{
    public class ContactNullException : ArgumentNullException
    {
        public ContactNullException()
            : base("contact", "Contact object cannot be null")
        {

        }
    }
}
