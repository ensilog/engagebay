using Ensilog.Engagebay.Contacts.Exceptions;
using Ensilog.Engagebay.Tags;
using Ensilog.Engagebay.Tags.Exceptions;
using FluentAssertions;
using RestSharp;

namespace Ensilog.Engagebay.Tests.Contacts
{
    public class DeleteContactTagsByIdCommandTests
    {
        [Fact]
        public void Constructor_WithValidData_ShouldInitializeCorrectly()
        {
            // Arrange
            long contactId = 123;
            var tags = new List<Tag> { new Tag("sample1"), new Tag("sample2") };

            // Act
            var command = new DeleteContactTagsById(contactId, tags);

            // Assert
            command.ContactId.Should().Be(contactId);
            command.Tags.Should().BeEquivalentTo(tags);
            command.Uri.Should().Be($"dev/api/panel/subscribers/contact/tags/delete/{contactId}");
            command.Method.Should().Be(Method.Post);
            command.Body.Should().BeEquivalentTo(tags);
            command.ContentType.Should().Be("application/json");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_WithInvalidContactId_ShouldThrowException(long contactId)
        {
            // Arrange
            var tags = new List<Tag> { new Tag("sample1"), new Tag("sample2") };

            // Act
            Action createCommand = () => new DeleteContactTagsById(contactId, tags);

            // Assert
            createCommand.Should().Throw<ContactIdInvalidException>();
        }

        [Fact]
        public void Constructor_WithNullTags_ShouldThrowException()
        {
            // Arrange
            long contactId = 123;

            // Act
            Action createCommand = () => new DeleteContactTagsById(contactId, null);

            // Assert
            createCommand.Should().Throw<NoTagHasBeenProvidedException>();
        }
    }

}
