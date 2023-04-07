using Ensilog.Engagebay.Contacts;
using Ensilog.Engagebay.Exceptions;
using FluentAssertions;
using RestSharp;

namespace Ensilog.Engagebay.Tests.Contacts
{
    public class ListContactsTests
    {
        [Fact]
        public void OnlyPageSize_Should_GiveCorrectRequest()
        {
            // Plan
            int pageSize = 20;

            // Do
            ListContacts request = new ListContacts(pageSize);

            // Check
            request.ContentType.Should().Be("application/x-www-form-urlencoded");
            request.Body.Should().Be("page_size=20&sort_key=created_time");
            request.Uri.Should().Be("/dev/api/panel/subscribers");
            request.Method.Should().Be(Method.Post);
        }

        [Fact]
        public void EmptySortKey_Should_GiveCorrectRequest()
        {
            // Plan
            int pageSize = 20;

            // Do
            ListContacts request = new ListContacts(pageSize, "");

            // Check
            request.ContentType.Should().Be("application/x-www-form-urlencoded");
            request.Body.Should().Be("page_size=20&sort_key=created_time");
            request.Uri.Should().Be("/dev/api/panel/subscribers");
            request.Method.Should().Be(Method.Post);
        }

        [Fact]
        public void SortKeyAndOrderSetting_Should_GiveCorrectRequest()
        {
            // Plan
            int pageSize = 20;
            string sortKey = "test_key";
            bool ascending = false;


            // Do
            ListContacts request = new ListContacts(pageSize, sortKey, ascending);

            // Check
            request.ContentType.Should().Be("application/x-www-form-urlencoded");
            request.Body.Should().Be("page_size=20&sort_key=-test_key");
            request.Uri.Should().Be("/dev/api/panel/subscribers");
            request.Method.Should().Be(Method.Post);
        }

        [Fact]
        public void NextResultWhenNull_Should_BeFalse()
        {
            // Plan
            int pageSize = 20;
            List<Contact>? contacts = null;

            // Do
            ListContacts request = new ListContacts(pageSize);
            bool result = request.NextResults(contacts);

            // Check
            result.Should().BeFalse();
        }

        [Fact]
        public void NextResultWithoutCursor_Should_BeFalse()
        {
            // Plan
            int pageSize = 20;
            List<Contact> contacts = new List<Contact>()
            {
                new Contact()
                {
                    Cursor = null
                }
            };

            // Do
            ListContacts request = new ListContacts(pageSize);
            bool result = request.NextResults(contacts);

            // Check
            result.Should().BeFalse();
        }

        [Fact]
        public void NextResultWithCursor_Should_BeTrueAndRequest_Should_BeValid()
        {
            // Plan
            int pageSize = 20;
            List<Contact> contacts = new List<Contact>()
            {
                new Contact()
                {
                    Cursor = "cursor123"
                }
            };

            // Do
            ListContacts request = new ListContacts(pageSize);
            bool result = request.NextResults(contacts);

            // Check
            result.Should().BeTrue();
            request.Body.Should().Be("page_size=20&sort_key=created_time&cursor=cursor123");
        }


        [Theory]
        [InlineData(0)]
        [InlineData(1001)]
        public void PageSizeZero_Should_ThrowException(int pageSize)
        {
            // Plan

            // Do
            Action act = () => new ListContacts(pageSize);

            // Check
            act.Should().Throw<PageSizeInvalidException>("Page size must be between 1 and 1000");
        }
    }
}
