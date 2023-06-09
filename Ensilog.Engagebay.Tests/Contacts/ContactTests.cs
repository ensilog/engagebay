using static Ensilog.Engagebay.Properties.PropertyFactory;

namespace Ensilog.Engagebay.Tests.Contacts
{
    using Ensilog.Engagebay.Addresses;
    using Ensilog.Engagebay.Contacts;
    using Ensilog.Engagebay.Properties;
    using FluentAssertions;
    using System.Text.Json;
    using Xunit;

    public class ContactTests
    {
        [Fact]
        public void ExtractAllProperties_ShouldExtractCorrectProperties()
        {
            // Arrange
            var contact = new Contact
            {
                FirstName = "Test First Name",
                LastName = "Test Last Name",
                Email = "test@example.com",
                Role = "Test Role",
                Phone = "1234567890",
                Website = "https://website.com",
                Address = new Address
                {
                    AddressLine = "Test AddressLine",
                    City = "Test City",
                    State = "Test State",
                    Zip = "12345",
                    Country = "Test Country"
                },
                CompanyIds = new List<long> { 1, 2, 3 },
                OtherProperties = new List<Property>
                {
                    CreateCustomProperty("custom_property", PropertyFieldType.TEXT).WithValue("custom_property_value")
                }
            };

            // Act
            var properties = contact.ExtractAllProperties().ToList();

            // Assert
            properties.Should().ContainSingle(p => p.Name == "name" && p.Value == contact.FirstName);
            properties.Should().ContainSingle(p => p.Name == "last_name" && p.Value == contact.LastName);
            properties.Should().ContainSingle(p => p.Name == "email" && p.Value == contact.Email);
            properties.Should().ContainSingle(p => p.Name == "role" && p.Value == contact.Role);
            properties.Should().ContainSingle(p => p.Name == "phone" && p.Value == contact.Phone);
            properties.Should().ContainSingle(p => p.Name == "website" && p.Value == contact.Website);
            properties.Should().ContainSingle(p => p.Name == "custom_property" && p.Value == "custom_property_value");
            properties.Should().ContainSingle(p => p.Name == "address" && p.Value == JsonSerializer.Serialize(contact.Address, JsonSerializerOptions.Default));
            properties.Should().HaveCount(8);
        }
    }

}
