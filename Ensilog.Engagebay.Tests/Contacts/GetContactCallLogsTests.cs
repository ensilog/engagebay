using FluentAssertions;
using Ensilog.Engagebay.Contacts.Exceptions;
using Ensilog.Engagebay.CallLogs;

namespace Ensilog.Engagebay.Tests.Contacts
{

    public class GetContactCallLogsTests
    {
        [Fact]
        public void Constructor_WithValidContactId_SetsContactId()
        {
            // Arrange
            long contactId = 12345;

            // Act
            var getContactCallLogs = new GetContactCallLogs(contactId);

            // Assert
            getContactCallLogs.ContactId.Should().Be(contactId);
        }

        [Fact]
        public void Constructor_WithInvalidContactId_ThrowsContactIdInvalidException()
        {
            // Arrange
            long contactId = 0;

            // Act & Assert
            Action act = () => new GetContactCallLogs(contactId);
            act.Should().Throw<ContactIdInvalidException>();
        }

        [Fact]
        public void Uri_WithValidContactId_ReturnsCorrectUri()
        {
            // Arrange
            long contactId = 12345;
            var getContactCallLogs = new GetContactCallLogs(contactId);

            // Act
            string uri = getContactCallLogs.Uri;

            // Assert
            uri.Should().Be($"/dev/api/panel/call-logs?contact_id={contactId}");
        }
    }
}