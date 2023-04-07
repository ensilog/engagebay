using Ensilog.Engagebay.Contacts.Exceptions;
using Ensilog.Engagebay.Tags;
using FluentAssertions;
using RestSharp;

namespace Ensilog.Engagebay.Tests.Contacts
{
    public class ListContactTagsByIdTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void InvalidContactId_Should_ThrowException(long contactId)
        {
            // Act and Assert
            Action act = () => new ListContactTagsById(contactId);
            act.Should().Throw<ContactIdInvalidException>();
        }

        [Fact]
        public void ValidContactId_Should_ConstructQuery()
        {
            // Arrange
            long contactId = 12345;

            // Act
            var query = new ListContactTagsById(contactId);

            // Assert
            query.ContactId.Should().Be(contactId);
            query.Uri.Should().Be($"dev/api/panel/subscribers/get-tags-by-id/{contactId}");
            query.Method.Should().Be(Method.Get);
            query.ContentType.Should().Be("application/x-www-form-urlencoded");
            query.Body.Should().BeNullOrEmpty();
        }
    }

}
