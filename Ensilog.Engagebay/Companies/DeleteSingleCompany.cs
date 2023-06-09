using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Companies.Exceptions;
using RestSharp;

namespace Ensilog.Engagebay.Companies
{
    public class DeleteSingleCompany : EngageBayCommand
    {
        public override string Uri => $"/dev/api/panel/companies/{_companyId}";
        public override Method Method => Method.Delete;

        private long _companyId;
        public DeleteSingleCompany(long companyId)
        {
            if (companyId < 0)
                throw new CompanyIdInvalidException();

            _companyId = companyId;
        }
    }
}
