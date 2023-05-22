using Ensilog.Engagebay.Companies;
using Ensilog.Engagebay.Companies.Exceptions;
using Ensilog.Engagebay.Properties;
using Ensilog.Engagebay.Tags;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensilog.Engagebay.Tests.Companies
{
    public class CreateCompanyTests
    {
        [Fact]
        public void ValidCompany_Should_CreateCorrectRequest()
        {
            // Arrange
            var company = new Company
            {
                Name = "www.engagebay.com",
                Url = "www.engagebay.com",
                CreatedTime = DateTime.Now,
                Tags = new List<Tag> { new Tag("testtag1"), new Tag("testtag2") }
            };

            // Act
            var request = new CreateCompany(company);

            // Assert
            request.Method.Should().Be(RestSharp.Method.Post);
            request.Body.Properties.Should().BeEquivalentTo(company.ExtractAllProperties());
            request.Body.Tags.Should().BeEquivalentTo(company.Tags);
            request.ContentType.Should().Be("application/json");
            request.Uri.Should().Be("/dev/api/panel/companies/company");
        }

        [Fact]
        public void NullCompany_Should_ThrowException()
        {
            // Arrange
            Company company = null;

            // Act
            Action act = () => new CreateCompany(company);

            // Assert
            act.Should().Throw<CompanyNullException>();
        }
    }

}
