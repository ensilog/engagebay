using System;

namespace Ensilog.Engagebay.Exceptions
{
    public sealed class EngageBayInternalServerErrorException : Exception
    {
        public EngageBayInternalServerErrorException()
        {

        }

        public EngageBayInternalServerErrorException(string message)
            : base(message)
        {

        }
    }
}
