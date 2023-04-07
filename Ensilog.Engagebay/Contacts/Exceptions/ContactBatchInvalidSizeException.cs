using System;

namespace Ensilog.Engagebay.Contacts.Exceptions
{
    public class ContactBatchInvalidSizeException : Exception
    {
        public ContactBatchInvalidSizeException()
            : base("Batch size should be between 1 and 100 contacts.")
        {

        }
    }
}
