using System;

namespace Ensilog.Engagebay.Exceptions
{
    public sealed class PageSizeInvalidException : Exception
    {
        public PageSizeInvalidException()
             : base("The page size must be between 1 and 1000")
        {

        }
    }
}
