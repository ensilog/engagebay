using Ensilog.Engagebay.Contacts.Exceptions;
using Ensilog.Engagebay.Tags;
using Ensilog.Engagebay.Tags.Exceptions;
using FluentAssertions;
using RestSharp;
using System.Text.Json;

namespace Ensilog.Engagebay.Tests.Contacts
{
    public class AddTagsToContactByIdTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void InvalidContactId_Should_ThrowException(long contactId)
        {
            // Arrange
            Action act = () => new AddTagsToContactById(contactId, new List<Tag> { new Tag("sample1") });

            // Act and Assert
            act.Should().Throw<ContactIdInvalidException>();
        }

        [Fact]
        public void NullTags_Should_ThrowException()
        {
            // Arrange
            long contactId = 12345;
            var act = new Action(() => new AddTagsToContactById(contactId, null));

            // Act and Assert
            act.Should().Throw<NoTagHasBeenProvidedException>();
        }

        [Fact]
        public void ValidContactIdAndTags_Should_ConstructCommand()
        {
            // Arrange
            long contactId = 12345;
            var tags = new List<Tag> { new Tag("sample1"), new Tag("sample2") };

            // Act
            var command = new AddTagsToContactById(contactId, tags);

            // Assert
            command.ContactId.Should().Be(contactId);
            command.Tags.Should().BeEquivalentTo(tags);
            command.Uri.Should().Be($"dev/api/panel/subscribers/contact/tags/add2/{contactId}");
            command.Method.Should().Be(Method.Post);
            command.ContentType.Should().Be("application/json");
            command.Body.Should().Be(JsonSerializer.Serialize(tags));
        }
    }

}
