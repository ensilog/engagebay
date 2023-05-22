using Ensilog.Engagebay.Deals;
using Ensilog.Engagebay.Properties;
using FluentAssertions;
using System.Globalization;
using static Ensilog.Engagebay.Properties.PropertyFactory;

namespace Ensilog.Engagebay.Tests.Deals
{
    public class DealTests
    {
        [Fact]
        public void ExtractAllProperties_ShouldExtractCorrectProperties()
        {
            // Arrange
            var deal = new Deal
            {
                Name = "Test Deal",
                UniqueId = 1,
                Description = "Test Description",
                TrackId = 1,
                Amount = 100.5f,
                Currency = "USD",
                ClosedDate = DateTime.UtcNow,
                OwnerId = "1",
                OtherProperties = new List<Property>
                {
                    CreateCustomProperty("custom_property",PropertyFieldType.TEXT).WithValue("custom_property_value")
                }
            };

            // Act
            var properties = deal.ExtractAllProperties().ToList();

            // Assert
            properties.Should().HaveCount(9);
            properties.Should().ContainSingle(p => p.Name == "name" && p.Value == deal.Name);
            properties.Should().ContainSingle(p => p.Name == "unique_id" && p.Value == deal.UniqueId.ToString());
            properties.Should().ContainSingle(p => p.Name == "description" && p.Value == deal.Description);
            properties.Should().ContainSingle(p => p.Name == "track_id" && p.Value == deal.TrackId.ToString());
            properties.Should().ContainSingle(p => p.Name == "amount" && p.Value == deal.Amount.Value.ToString("F", CultureInfo.InvariantCulture));
            properties.Should().ContainSingle(p => p.Name == "currency_type" && p.Value == deal.Currency);
            properties.Should().ContainSingle(p => p.Name == "closed_date" && p.Value == deal.ClosedDate.Value.ToString("dd/MM/yyyy"));
            properties.Should().ContainSingle(p => p.Name == "owner_id" && p.Value == deal.OwnerId);
            properties.Should().ContainSingle(p => p.Name == "custom_property" && p.Value == "custom_property_value");
        }
    }
}
