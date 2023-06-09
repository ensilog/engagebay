using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Companies.Exceptions;

namespace Ensilog.Engagebay.Companies
{
    public class CreateCompany : EngageBayCommand<CreateCompanyBody>
    {
        public override string Uri => "/dev/api/panel/companies/company";

        public override CreateCompanyBody Body => _body;

        private CreateCompanyBody _body;

        public CreateCompany(Company company)
        {
            if (company == null)
            {
                throw new CompanyNullException(nameof(company));
            }

            _body = new CreateCompanyBody();
            _body.Properties = company.ExtractAllProperties();
            _body.Tags = company.Tags;
        }
    }

}
