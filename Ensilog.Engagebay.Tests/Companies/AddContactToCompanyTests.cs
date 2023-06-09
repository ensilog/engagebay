using Ensilog.Engagebay.Companies.Exceptions;
using Ensilog.Engagebay.Contacts.Exceptions;
using FluentAssertions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensilog.Engagebay.Tests.Companies
{
    public class AddContactToCompanyTests
    {
        [Fact]
        public void Constructor_ValidInput_ConstructsSuccessfully()
        {
            // Arrange
            long companyId = 567436789433;
            long contactId = 65654657678;

            // Act
            var command = new AddContactToCompany(companyId, contactId);

            // Assert
            command.Should().NotBeNull();
            command.Uri.Should().Be($"/dev/api/panel/companies/{companyId}/add-contact-by-contactId");
            command.Method.Should().Be(Method.Post);
            command.ContentType.Should().Be("application/x-www-form-urlencoded");
            command.Body.Should().Be($"companyId={companyId}&contactId={contactId}");
        }

        [Fact]
        public void Constructor_NegativeCompanyId_ThrowsException()
        {
            // Arrange
            long companyId = -1;
            long contactId = 65654657678;

            // Act & Assert
            Action act = () => new AddContactToCompany(companyId, contactId);
            act.Should().Throw<CompanyIdInvalidException>();
        }

        [Fact]
        public void Constructor_NegativeContactId_ThrowsException()
        {
            // Arrange
            long companyId = 567436789433;
            long contactId = -1;

            // Act & Assert
            Action act = () => new AddContactToCompany(companyId, contactId);
            act.Should().Throw<ContactIdInvalidException>();
        }
    }
}
