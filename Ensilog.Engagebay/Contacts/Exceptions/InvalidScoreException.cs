using System;

namespace Ensilog.Engagebay.Contacts.Exceptions
{
    public class InvalidScoreException : ArgumentOutOfRangeException
    {
        public InvalidScoreException() : base("Score must be between 0 and 100.")
        {
        }
    }
}
