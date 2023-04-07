using Ensilog.Engagebay.Contacts;
using Ensilog.Engagebay.Contacts.Exceptions;
using FluentAssertions;

namespace Ensilog.Engagebay.Tests.Contacts
{
    public class DeleteContactTests
    {
        [Fact]
        public void CorrectInput_Should_CreateCorrectRequest()
        {
            // Plan
            long idToTest = 1001;

            // Do
            var request = new DeleteContact(idToTest);

            // Check
            request.Body.Should().BeNull();
            request.ContentType.Should().BeNull();
            request.Method.Should().Be(RestSharp.Method.Delete);
            request.Uri.Should().Be($"dev/api/panel/subscribers/{idToTest}");
        }

        [Theory]
        [InlineData(-100)]
        [InlineData(0)]
        public void InvalidId_Should_ThrowException(long testId)
        {
            // Plan
            Contact? contactToCreate = new Contact();

            // Do
            Action act = () => new DeleteContact(testId);

            // Check
            act.Should().Throw<ContactIdInvalidException>();
        }
    }
}
