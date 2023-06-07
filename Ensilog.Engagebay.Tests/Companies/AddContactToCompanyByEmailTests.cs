using Ensilog.Engagebay.Companies.Exceptions;
using Ensilog.Engagebay.Companies;
using FluentAssertions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ensilog.Engagebay.Contacts.Exceptions;

namespace Ensilog.Engagebay.Tests.Companies
{
    public class AddContactToCompanyByEmailTests
    {
        [Fact]
        public void Constructor_ValidInput_ConstructsSuccessfully()
        {
            // Arrange
            long companyId = 567436789433;
            string contactEmail = "samson@walt.ltd";

            // Act
            var command = new AddContactToCompanyByEmail(companyId, contactEmail);

            // Assert
            command.Should().NotBeNull();
            command.Uri.Should().Be($"/dev/api/panel/companies/{companyId}/add-contact-by-contactEmail");
            command.Method.Should().Be(Method.Post);
            command.ContentType.Should().Be("application/x-www-form-urlencoded");
            command.Body.Should().Be($"companyId={companyId}&contactEmail={contactEmail}");
        }

        [Fact]
        public void Constructor_NegativeCompanyId_ThrowsException()
        {
            // Arrange
            long companyId = -1;
            string contactEmail = "samson@walt.ltd";

            // Act & Assert
            Action act = () => new AddContactToCompanyByEmail(companyId, contactEmail);
            act.Should().Throw<CompanyIdInvalidException>();
        }

        [Fact]
        public void Constructor_InvalidEmail_ThrowsException()
        {
            // Arrange
            long companyId = 567436789433;
            string contactEmail = "";

            // Act & Assert
            Action act = () => new AddContactToCompanyByEmail(companyId, contactEmail);
            act.Should().Throw<ContactEmailNullException>();
        }
    }

}
