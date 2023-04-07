using System;

namespace Ensilog.Engagebay.Tags.Exceptions
{
    public class NoTagHasBeenProvidedException : Exception
    {
        public NoTagHasBeenProvidedException()
            : base("At least one tag must be provided")
        {

        }
    }
}
