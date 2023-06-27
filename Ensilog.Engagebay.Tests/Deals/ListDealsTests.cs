using Ensilog.Engagebay.Deals;
using FluentAssertions;
using RestSharp;

namespace Ensilog.Engagebay.Tests;

public class ListDealsTests
{
    [Fact]
    public void ListDeals_Should_Create_Properly()
    {
        // Arrange
        int pageSize = 10;
        string sortKey = "created_time";
        bool ascendingSort = true;
        string trackId = "xxxxx";

        // Act
        var command = new ListDeals(pageSize, sortKey, ascendingSort, trackId);

        // Assert
        command.Method.Should().Be(Method.Post);
        command.Uri.Should().Be("/dev/api/panel/deals");
        command.ContentType.Should().Be("application/x-www-form-urlencoded");

        string expectedBody = $"page_size={pageSize}&sort_key={sortKey}&track_id={trackId}";
        command.Body.Should().Be(expectedBody);
    }

    [Fact]
    public void ListDeals_Should_CreateWithNoTrackId()
    {
        // Arrange
        int pageSize = 10;
        string sortKey = "created_time";
        bool ascendingSort = true;

        // Act
        var command = new ListDeals(pageSize, sortKey, ascendingSort);

        // Assert
        command.Method.Should().Be(Method.Post);
        command.Uri.Should().Be("/dev/api/panel/deals");
        command.ContentType.Should().Be("application/x-www-form-urlencoded");

        string expectedBody = $"page_size={pageSize}&sort_key={sortKey}";
        command.Body.Should().Be(expectedBody);
    }

}
