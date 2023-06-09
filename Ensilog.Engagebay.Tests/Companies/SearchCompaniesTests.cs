using Ensilog.Engagebay.Companies;
using Ensilog.Engagebay.Exceptions;
using FluentAssertions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensilog.Engagebay.Tests.Companies
{
    public class SearchCompaniesCommandTests
    {
        [Fact]
        public void Constructor_ValidSearchText_ConstructsSuccessfully()
        {
            // Arrange
            var searchText = "samplecompany";

            // Act
            var query = new SearchCompanies(searchText);

            // Assert            
            query.Should().NotBeNull();
            query.Uri.Should().Be($"/dev/api/search?q=samplecompany&page_size=100&type=Company");
            query.ContentType.Should().Be("application/json");
            query.Method.Should().Be(Method.Get);
            query.PageSize.Should().Be(100);
            query.SearchText.Should().Be("samplecompany");
        }

        [Fact]
        public void Constructor_ValidSearchTextAndSpecificPageSize_ConstructsSuccessfully()
        {
            // Arrange
            var searchText = "samplecompany";

            // Act
            var query = new SearchCompanies(searchText, 156);

            // Assert
            query.PageSize.Should().Be(156);
            query.Uri.Should().Be($"/dev/api/search?q=samplecompany&page_size=156&type=Company");
        }

        [Fact]
        public void Constructor_NullOrEmptySearchText_ThrowsException()
        {
            // Arrange
            var searchText = string.Empty;

            // Act 
            var act = () => new SearchCompanies(searchText);

            // Assert
            act.Should().ThrowExactly<SearchTextNullException>();
        }

        [Theory]
        [InlineData(-10)]
        [InlineData(0)]
        [InlineData(1026)]
        public void Constructor_InvalidPagesize_ThrowsException(int pageSize)
        {
            // Arrange
            var searchText = "testcompany";

            var act = () => new SearchCompanies(searchText, pageSize);

            // Act & Assert
            act.Should().ThrowExactly<PageSizeInvalidException>();
        }
    }

}
