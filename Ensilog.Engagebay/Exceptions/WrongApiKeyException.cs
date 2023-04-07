using System;

namespace Ensilog.Engagebay.Exceptions
{
    public sealed class WrongApiKeyException : Exception
    {
        public WrongApiKeyException()
        {

        }

        public WrongApiKeyException(string message)
            : base(message)
        {

        }
    }
}
