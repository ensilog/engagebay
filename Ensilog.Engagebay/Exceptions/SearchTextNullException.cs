using System;

namespace Ensilog.Engagebay.Exceptions
{
    public class SearchTextNullException : ArgumentNullException
    {
        public SearchTextNullException(string paramName) : base(paramName, "Search text cannot be null or empty.")
        {
        }
    }
}
