using System;

namespace Ensilog.Engagebay.Contacts.Exceptions
{
    public class ContactIdInvalidException : Exception
    {
        public ContactIdInvalidException()
            : base("Contact Id must be above 0")
        {
        }
    }
}
