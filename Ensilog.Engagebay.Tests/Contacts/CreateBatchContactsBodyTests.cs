using Ensilog.Engagebay.Contacts;
using Ensilog.Engagebay.Contacts.Exceptions;
using Ensilog.Engagebay.Tags;
using FluentAssertions;

namespace Ensilog.Engagebay.Tests.Contacts
{
    public class CreateBatchContactsBodyTests
    {
        [Fact]
        public void Constructor_ValidParameters_ShouldCreateInstance()
        {
            var contacts = new List<Contact>
            {
                new Contact { Score = 1, Email = "test@domain.com", Tags = null },
                new Contact { Score = 2, Email = "test2@domain.com", Tags = new List<Tag>(){new Tag("other_test_tag") } }
            };
            string callbackUrl = "https://domainname.com/notify-me";
            Tag tagForWholeBatch = new Tag("sampleTag");

            var createBatchContactsBody = new CreateBatchContactsBody(contacts, tagForWholeBatch, callbackUrl);

            createBatchContactsBody.CallbackUrl.Should().Be(callbackUrl);
            createBatchContactsBody.Contacts.Should().NotBeNull();
            createBatchContactsBody.Contacts.Count().Should().Be(contacts.Count);

            for (int i = 0; i < contacts.Count; i++)
            {
                var batchContact = createBatchContactsBody.Contacts.ElementAt(i);
                batchContact.Tags.Should().Contain(tagForWholeBatch.TagValue);
                batchContact.Score.Should().Be(contacts[i].Score);
                if (i == 1)
                {
                    batchContact.Tags.Should().Contain("other_test_tag");
                }
            }
        }

        [Fact]
        public void Constructor_NullContacts_ShouldThrowException()
        {
            IEnumerable<Contact>? contacts = null;

            Action action = () => new CreateBatchContactsBody(contacts);
            action.Should().Throw<ContactBatchInvalidSizeException>();
        }


        [Theory]
        [InlineData(0)]
        [InlineData(101)]
        public void Constructor_InvalidContactSize_ShouldThrowException(int batchSize)
        {
            List<Contact> contacts = new List<Contact>();
            for (int i = 0; i < batchSize; i++)
            {
                contacts.Add(new Contact());
            }

            Action action = () => new CreateBatchContactsBody(contacts);
            action.Should().Throw<ContactBatchInvalidSizeException>();
        }
    }
}
