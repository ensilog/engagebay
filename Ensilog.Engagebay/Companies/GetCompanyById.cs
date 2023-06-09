using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Companies.Exceptions;

namespace Ensilog.Engagebay.Companies
{
    public class GetCompanyById : EngageBayQuery<Company>
    {
        private ulong _idToRequest;

        public override string Uri => $"/dev/api/panel/companies/{_idToRequest}";

        public GetCompanyById(ulong id)
        {
            if (id == default)
            {
                throw new CompanyIdInvalidException();
            }

            _idToRequest = id;
        }
    }
}