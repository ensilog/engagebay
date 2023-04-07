using System;

namespace Ensilog.Engagebay.Exceptions
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException() : base("The provided email is not valid.") { }
    }
}
