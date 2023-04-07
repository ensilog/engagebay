using System;

namespace Ensilog.Engagebay.Contacts.Exceptions
{
    public class ContactEmailNullException : Exception
    {
        public ContactEmailNullException()
            : base("The contact email must be set")
        {

        }
    }
}
