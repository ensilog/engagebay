using FluentAssertions;
using Ensilog.Engagebay.Contacts.Exceptions;
using Ensilog.Engagebay.Tags.Exceptions;
using Ensilog.Engagebay.Tags;

namespace Ensilog.Engagebay.Tests.Contacts
{
    public class DeleteTagsToContactsByEmailTests
    {
        [Fact]
        public void CorrectInput_Should_CreateRequest()
        {
            // Plan
            string testEmail = "someone@company.com";

            // Act
            var addTagRequest = new DeleteTagsToContactsByEmail(testEmail, "tag1", "tag2", "tag3");

            // Check 
            addTagRequest.Body.Should().Be("email=someone@company.com&tags=[\"tag1\",\"tag2\",\"tag3\"]");
            addTagRequest.ContentType.Should().Be("application/x-www-form-urlencoded");
            addTagRequest.Method.Should().Be(RestSharp.Method.Post);
            addTagRequest.Uri.Should().Be("/dev/api/panel/subscribers/email/tags/delete");
        }

        [Fact]
        public void NoTag_Should_Throw()
        {
            // Plan
            string testEmail = "someone@company.com";

            // Act
            Action act = () => new DeleteTagsToContactsByEmail(testEmail);

            // Check
            act.Should().Throw<NoTagHasBeenProvidedException>();
        }

        [Fact]
        public void InvalidEmail_Should_Throw()
        {
            // Plan
            string testEmail = "";

            // Act
            Action act = () => new DeleteTagsToContactsByEmail(testEmail, "tag");

            // Check
            act.Should().Throw<ContactEmailNullException>();
        }
    }
}
