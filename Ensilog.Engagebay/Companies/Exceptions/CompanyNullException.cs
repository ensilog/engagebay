using System;
using System.Collections.Generic;
using System.Text;

namespace Ensilog.Engagebay.Companies.Exceptions
{
    public class CompanyNullException : ArgumentNullException
    {
        public CompanyNullException(string paramName) :
            base(paramName, "Company object cannot be null")
        {

        }
    }
}
