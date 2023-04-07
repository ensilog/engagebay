using Ensilog.Engagebay.Contacts;
using Ensilog.Engagebay.Contacts.Exceptions;
using Ensilog.Engagebay.Exceptions;
using FluentAssertions;

namespace Ensilog.Engagebay.Tests.Contacts
{
    public class ChangeContactOwnerTests
    {
        [Fact]
        public void Constructor_ValidParameters_ShouldCreateInstance()
        {
            var command = new ChangeContactOwner(5015780936646656, "test@engagebay.com");

            command.SubscriberId.Should().Be(5015780936646656);
            command.OwnerEmail.Should().Be("test@engagebay.com");
            command.Uri.Should().Be("/dev/api/panel/subscribers/update-owner-by-email?subscriberId=5015780936646656&ownerEmail=test@engagebay.com");
            command.Body.Should().BeNullOrEmpty();
            command.ContentType.Should().Be("application/json");
            command.Method.Should().Be(RestSharp.Method.Post);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_InvalidSubscriberId_ShouldThrowException(long subscriberId)
        {
            Action action = () => new ChangeContactOwner(subscriberId, "test@engagebay.com");
            action.Should().Throw<ContactIdInvalidException>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("test")]
        [InlineData("test@")]
        [InlineData("@engagebay.com")]
        public void Constructor_InvalidOwnerEmail_ShouldThrowException(string ownerEmail)
        {
            Action action = () => new ChangeContactOwner(5015780936646656, ownerEmail);
            action.Should().Throw<InvalidEmailException>();
        }
    }
}
