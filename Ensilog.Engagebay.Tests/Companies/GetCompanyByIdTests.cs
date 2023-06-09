using Ensilog.Engagebay.Companies;
using Ensilog.Engagebay.Companies.Exceptions;
using FluentAssertions;
using Xunit;

namespace Ensilog.Engagebay.Tests.Companies
{
    public class GetCompanyByIdTests
    {
        [Fact]
        public void ValidId_Should_CreateCorrectRequest()
        {
            // Plan
            ulong id = 10;

            // Do
            var request = new GetCompanyById(id);

            // Check
            request.Method.Should().Be(RestSharp.Method.Get);
            request.Body.Should().BeNullOrEmpty();
            request.Uri.Should().Be($"/dev/api/panel/companies/{id}");
        }

        [Fact]
        public void InvalidId_Should_ThrowException()
        {
            // Plan
            ulong id = 0;

            // Do
            Action act = () => new GetCompanyById(id);

            // Check
            act.Should().Throw<CompanyIdInvalidException>();
        }
    }
}