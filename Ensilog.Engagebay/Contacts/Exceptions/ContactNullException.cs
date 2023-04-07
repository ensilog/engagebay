using System;

namespace Ensilog.Engagebay.Contacts.Exceptions
{
    public class ContactNullException : Exception
    {
        public ContactNullException()
            : base("Contact object cannot be null")
        {

        }
    }
}
