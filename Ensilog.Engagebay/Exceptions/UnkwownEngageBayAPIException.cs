using System;

namespace Ensilog.Engagebay.Exceptions
{
    public sealed class UnkwownEngageBayAPIException : Exception
    {
        public UnkwownEngageBayAPIException()
        {

        }

        public UnkwownEngageBayAPIException(string message)
            : base(message)
        {

        }
    }
}
