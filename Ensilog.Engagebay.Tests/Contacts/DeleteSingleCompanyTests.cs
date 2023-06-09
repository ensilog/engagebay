using Ensilog.Engagebay.Companies.Exceptions;
using Ensilog.Engagebay.Companies;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensilog.Engagebay.Tests.Contacts
{
    public class DeleteSingleCompanyTests
    {
        [Fact]
        public void Constructor_ValidCompanyId_ConstructsSuccessfully()
        {
            // Arrange
            var companyId = 123456L;

            // Act
            var command = new DeleteSingleCompany(companyId);

            // Assert
            Assert.NotNull(command);
            Assert.Equal($"/dev/api/panel/companies/123456", command.Uri);
            Assert.Equal(Method.Delete, command.Method);
        }

        [Fact]
        public void Constructor_NegativeCompanyId_ThrowsException()
        {
            // Arrange
            var companyId = -1L;

            // Act & Assert
            Assert.Throws<CompanyIdInvalidException>(() => new DeleteSingleCompany(companyId));
        }
    }

}
