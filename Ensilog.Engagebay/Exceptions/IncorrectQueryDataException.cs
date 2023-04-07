using System;

namespace Ensilog.Engagebay.Exceptions
{
    public sealed class IncorrectQueryDataException : Exception
    {
        public IncorrectQueryDataException()
        {

        }

        public IncorrectQueryDataException(string message)
            : base(message)
        {

        }
    }
}
