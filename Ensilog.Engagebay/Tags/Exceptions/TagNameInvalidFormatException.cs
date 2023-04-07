using System;

namespace Ensilog.Engagebay.Tags.Exceptions
{
    public class TagNameInvalidFormatException : Exception
    {
        public TagNameInvalidFormatException()
            : base("Tag name should start with an letter and cannot contain special characters other than underscore and space.")
        {

        }
    }
}
