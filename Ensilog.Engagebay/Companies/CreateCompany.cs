using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Companies.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ensilog.Engagebay.Companies
{
    public class CreateCompany : EngageBayCommand<Company>
    {
        public override string Uri => "/dev/api/panel/companies/company";

        public override Company Body => _body;

        private Company _body;

        public CreateCompany(Company company)
        {
            if (company == null)
            {
                throw new CompanyNullException(nameof(company));
            }

            _body = company;
        }
    }

}
