using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Companies.Exceptions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ensilog.Engagebay.Companies
{
    public class UpdateCompanyPartial : EngageBayCommand<UpdateCompanyPartialBody>
    {
        public override string Uri => "/dev/api/panel/companies/update-partial";

        public override UpdateCompanyPartialBody Body => _body;

        public override Method Method => Method.Put;

        private UpdateCompanyPartialBody _body;

        public UpdateCompanyPartial(ulong companyId, Company company)
        {
            if (company == null)
            {
                throw new CompanyNullException(nameof(company));
            }

            if (companyId == default)
            {
                throw new CompanyIdInvalidException();
            }

            _body = new UpdateCompanyPartialBody();
            _body.Id = companyId;
            _body.Properties = company.ExtractAllProperties();
            _body.Tags = company.Tags;
        }
    }
}
