using System;

namespace Ensilog.Engagebay.Companies.Exceptions
{
    public class CompanyIdInvalidException : ArgumentException
    {
        public CompanyIdInvalidException() :
            base("Company ID must be greater than 0")
        {

        }
    }
}