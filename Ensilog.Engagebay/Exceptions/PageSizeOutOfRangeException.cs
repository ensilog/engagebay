using System;

namespace Ensilog.Engagebay.Exceptions
{
    public class PageSizeOutOfRangeException : ArgumentOutOfRangeException
    {
        public PageSizeOutOfRangeException(string paramName) : base(paramName, "Page size must be a positive number.")
        {
        }
    }
}
