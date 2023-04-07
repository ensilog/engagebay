using Ensilog.Engagebay.Contacts;
using Ensilog.Engagebay.Exceptions;
using FluentAssertions;

namespace Ensilog.Engagebay.Tests.Contacts
{
    public class SearchContactsQueryTests
    {
        [Fact]
        public void ValidParameters_Should_Construct()
        {
            var query = new SearchContacts("test", 10);

            query.SearchText.Should().Be("test");
            query.PageSize.Should().Be(10);
            query.Method.Should().Be(RestSharp.Method.Get);
            query.Uri.Should().Be("dev/api/search?q=test&type=Subscriber&page_size=10");
        }

        [Fact]
        public void NullSearchText_Should_ThrowException()
        {
            Action act = () => new SearchContacts(null, 10);
            act.Should().Throw<SearchTextNullException>();
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        public void EmptySearchText_Should_ThrowException(string searchText)
        {
            Action act = () => new SearchContacts(searchText, 10);
            act.Should().Throw<SearchTextNullException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void InvalidPageSize_Should_ThrowException(int pageSize)
        {
            Action act = () => new SearchContacts("test", pageSize);
            act.Should().Throw<PageSizeOutOfRangeException>();
        }
    }

}
