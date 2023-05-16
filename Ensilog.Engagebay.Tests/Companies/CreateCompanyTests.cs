using Ensilog.Engagebay.Companies;
using Ensilog.Engagebay.Properties;
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
                OtherProperties = new List<Property>
            {
                new Property
                {
                    Name = "url",
                    Value = "www.engagebay.com",
                    FieldType = "TEXT",
                    IsSearchable = false,
                    Type = "SYSTEM"
                },
                new Property
                {
                    Name = "name",
                    Value = "www.engagebay.com",
                    FieldType = "TEXT",
                    IsSearchable = false,
                    Type = "SYSTEM"
                },
                new Property
                {
                    Name = "email",
                    Value = "",
                    FieldType = "TEXT",
                    IsSearchable = false,
                    Type = "SYSTEM"
                }
            },
                Tags = new List<string>(),
                ContactIds = new List<ulong>(),
                EntityGroupName = "company",
                CompanyIds = new List<ulong>()
            };

            // Act
            var request = new CreateCompany(company);

            // Assert
            request.Method.Should().Be(RestSharp.Method.Post);
            request.Body.Should().BeEquivalentTo(company);
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
            act.Should().Throw<ArgumentNullException>();
        }
    }

}
