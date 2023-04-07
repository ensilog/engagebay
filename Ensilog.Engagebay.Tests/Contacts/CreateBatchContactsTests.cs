using Ensilog.Engagebay.Contacts;
using Ensilog.Engagebay.Contacts.Exceptions;
using Ensilog.Engagebay.Tags;
using FluentAssertions;

namespace Ensilog.Engagebay.Tests.Contacts
{
    public class CreateBatchContactsTests
    {
        [Fact]
        public void Constructor_ValidParameters_ShouldCreateInstance()
        {
            // Plan
            var contacts = new List<Contact>
            {
                new Contact { Score = 1, Email = "test1@engagebay.com", Tags = new List<Tag>(){ new Tag("tag1") } },
                new Contact { Score = 2, Email = "test2@engagebay.com", Tags = new List<Tag>(){ new Tag("tag2") } }
            };

            // Do
            var command = new CreateBatchContacts(contacts, "custom_tag", "https://domainname.com/notify-me");

            // Check
            command.CallbackUrl.Should().Be("https://domainname.com/notify-me");
            command.DefaultTag.TagValue.Should().Be("custom_tag");
            command.Contacts.Should().BeEquivalentTo(contacts);
            command.Uri.Should().Be("/dev/api/panel/subscribers/subscriber-batch");
            command.Method.Should().Be(RestSharp.Method.Post);
            command.Body.CallbackUrl.Should().Be("https://domainname.com/notify-me");
            command.Body.Should().BeEquivalentTo(new CreateBatchContactsBody(contacts, new Tag("custom_tag"), "https://domainname.com/notify-me"));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(101)]
        public void Constructor_InvalidBatchSize_ShouldThrowException(int batchSize)
        {
            // Plan
            var contacts = new List<Contact>();

            for (int i = 0; i < batchSize; i++)
            {
                contacts.Add(new Contact { Score = i, Email = $"test{i}@engagebay.com", Tags = new List<Tag>() });
            }

            // Do
            Action action = () => new CreateBatchContacts(contacts);

            // Check
            action.Should().Throw<ContactBatchInvalidSizeException>();
        }
    }
}
