using Ensilog.Engagebay.Contacts;
using Ensilog.Engagebay.Contacts.Exceptions;
using FluentAssertions;

namespace Ensilog.Engagebay.Tests.Contacts
{
    public class GetContactByIdTests
    {
        [Fact]
        public void ValidId_Should_CreateCorrectRequest()
        {
            // Plan
            ulong id = 10;

            // Do
            var request = new GetContactById(id);

            // Check
            request.Method.Should().Be(RestSharp.Method.Get);
            request.Body.Should().BeNullOrEmpty();
            request.Uri.Should().Be("/dev/api/panel/subscribers/10");
        }

        [Fact]
        public void InvalidId_Should_ThrowException()
        {
            // Plan
            ulong id = 0;

            // Do
            Action act = () => new GetContactById(id);

            // Check
            act.Should().Throw<ContactIdInvalidException>();
        }
    }
}
