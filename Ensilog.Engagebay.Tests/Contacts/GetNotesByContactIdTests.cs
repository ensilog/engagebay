using FluentAssertions;
using RestSharp;
using Ensilog.Engagebay.Contacts.Exceptions;
using Ensilog.Engagebay.Notes;

namespace Ensilog.Engagebay.Tests.Contacts
{
    public class GetNotesByContactIdTests
    {
        [Fact]
        public void OnlyPageSize_Should_GiveCorrectRequest()
        {
            // Arrange
            long contactId = 123;

            // Act
            var getNotesByContactId = new GetNotesByContactId(contactId, 500);

            // Assert
            getNotesByContactId.ContactId.Should().Be(contactId);
            getNotesByContactId.Uri.Should().Be($"/dev/api/panel/notes/{contactId}?page_size=500&sort_key=created_time");
            getNotesByContactId.Method.Should().Be(Method.Get);
        }

        [Fact]
        public void Response_WithCursor_SetsProperties()
        {
            // Arrange
            long contactId = 123;

            // Act
            var getNotesByContactId = new GetNotesByContactId(contactId);
            bool hasNextResults = getNotesByContactId.NextResults(new List<Note>()
            {
                new Note()
                {
                    Cursor = "thisisnextcursor"
                }
            });

            // Assert
            hasNextResults.Should().BeTrue();
            getNotesByContactId.ContactId.Should().Be(contactId);
            getNotesByContactId.Uri.Should().Be($"/dev/api/panel/notes/{contactId}?page_size=1000&sort_key=created_time&cursor=thisisnextcursor");
            getNotesByContactId.Method.Should().Be(Method.Get);
        }

        [Fact]
        public void Response_WithoutCursor_ReturnsFalse()
        {
            // Arrange
            long contactId = 123;

            // Act
            var getNotesByContactId = new GetNotesByContactId(contactId);
            bool hasNextResults = getNotesByContactId.NextResults(new List<Note>()
            {
                new Note()
                {
                    Cursor = null
                }
            });

            // Assert
            hasNextResults.Should().BeFalse();
        }

        [Fact]
        public void EmptySortKey_Should_GiveCorrectRequest()
        {
            // Plan
            long contactId = 123;
            int pageSize = 20;

            // Do
            GetNotesByContactId request = new GetNotesByContactId(contactId, pageSize, "");

            // Check
            request.Uri.Should().Be($"/dev/api/panel/notes/{contactId}?page_size=20&sort_key=created_time");
            request.Method.Should().Be(Method.Get);
        }

        [Fact]
        public void SortKeyAndOrderSetting_Should_GiveCorrectRequest()
        {
            // Plan
            int pageSize = 20;
            string sortKey = "test_key";
            bool ascending = false;
            long contactId = 123;


            // Do
            GetNotesByContactId request = new GetNotesByContactId(contactId, pageSize, sortKey, ascending);

            // Check
            request.Uri.Should().Be($"/dev/api/panel/notes/{contactId}?page_size=20&sort_key=-test_key");
            request.Method.Should().Be(Method.Get);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_InvalidContactId_ThrowsContactIdInvalidException(long contactId)
        {
            // Act
            Action act = () => new GetNotesByContactId(contactId);

            // Assert
            act.Should().Throw<ContactIdInvalidException>();
        }
    }
}
