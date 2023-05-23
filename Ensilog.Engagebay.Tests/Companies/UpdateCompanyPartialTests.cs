using Ensilog.Engagebay.Companies.Exceptions;
using Ensilog.Engagebay.Companies;
using Ensilog.Engagebay.Tags;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ensilog.Engagebay.Tests.Companies
{
    public class UpdateCompanyPartialTests
    {
        [Fact]
        public void ValidCompany_Should_CreateCorrectRequest()
        {
            // Arrange
            var company = new Company
            {
                Name = "www.engagebay.com",
                Url = "www.engagebay.com",
                Tags = new List<Tag> { new Tag("testtag1"), new Tag("testtag2") }
            };

            // Act
            var request = new UpdateCompanyPartial(1234567890, company);

            // Assert
            request.Method.Should().Be(RestSharp.Method.Put);
            request.Body.Id.Should().Be(1234567890);
            request.Body.Properties.Should().BeEquivalentTo(company.ExtractAllProperties());
            request.Body.Tags.Should().BeEquivalentTo(company.Tags);
            request.ContentType.Should().Be("application/json");
            request.Uri.Should().Be("/dev/api/panel/companies/update-partial");
        }

        [Fact]
        public void NullCompany_Should_ThrowException()
        {
            // Arrange
            Company company = null;

            // Act
            Action act = () => new UpdateCompanyPartial(1234567890, company);

            // Assert
            act.Should().Throw<CompanyNullException>();
        }

        [Fact]
        public void DefaultCompanyId_Should_ThrowException()
        {
            // Arrange
            Company company = new Company();

            // Act
            Action act = () => new UpdateCompanyPartial(0, company);

            // Assert
            act.Should().Throw<CompanyIdInvalidException>();
        }
    }
}
