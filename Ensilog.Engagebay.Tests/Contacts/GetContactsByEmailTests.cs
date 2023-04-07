using Ensilog.Engagebay.Contacts;
using Ensilog.Engagebay.Contacts.Exceptions;
using FluentAssertions;

namespace Ensilog.Engagebay.Tests.Contacts
{
    public class GetContactsByEmailTests
    {
        [Fact]
        public void ValidEmail_Should_CreateCorrectRequest()
        {
            // Plan
            string email = "someone@company.com";

            // Do
            var request = new GetContactsByEmail(email);

            // Check
            request.Method.Should().Be(RestSharp.Method.Get);
            request.Body.Should().BeNullOrEmpty();
            request.Uri.Should().Be("/dev/api/panel/subscribers/contact-by-email/someone@company.com");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void InvalidEmail_Should_ThrowException(string email)
        {
            // Plan

            // Do
            Action act = () => new GetContactsByEmail(email);

            // Check
            act.Should().Throw<ContactEmailNullException>();
        }
    }
}
