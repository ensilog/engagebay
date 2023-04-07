using System;

namespace Ensilog.Engagebay.Contacts.Exceptions
{
    public class ContactFirstNameNullException : Exception
    {
        public ContactFirstNameNullException()
            : base("The first name of the contact must be set")
        {

        }
    }
}
