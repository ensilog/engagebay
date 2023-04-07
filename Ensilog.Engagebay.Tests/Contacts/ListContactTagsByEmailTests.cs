using Ensilog.Engagebay.Exceptions;
using Ensilog.Engagebay.Tags;
using FluentAssertions;
using RestSharp;

namespace Ensilog.Engagebay.Tests.Contacts
{
    public class ListContactTagsByEmailTests
    {
        [Fact]
        public void ValidEmail_Should_GiveCorrectRequest()
        {
            // Plan
            string email = "test@test.com";

            // Do
            ListContactTagsByEmail request = new ListContactTagsByEmail(email);

            // Check
            request.ContentType.Should().Be("application/x-www-form-urlencoded");
            request.Uri.Should().Be("/dev/api/panel/subscribers/get-tags/test@test.com");
            request.Method.Should().Be(Method.Post);
        }

        [Theory]
        [InlineData("")]
        [InlineData("test@test")]
        [InlineData("test.com")]
        public void InvalidEmail_Should_ThrowException(string email)
        {
            // Plan

            // Do
            Action act = () => new ListContactTagsByEmail(email);

            // Check
            act.Should().Throw<InvalidEmailException>("The provided email is not valid.");
        }
    }

}
