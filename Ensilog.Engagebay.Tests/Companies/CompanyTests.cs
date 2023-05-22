using Ensilog.Engagebay.Addresses;
using Ensilog.Engagebay.Companies;
using Ensilog.Engagebay.Properties;
using Ensilog.Engagebay.Tests.Json;
using FluentAssertions;
using System.Text.Json;
using static Ensilog.Engagebay.Properties.PropertyFactory;

namespace Ensilog.Engagebay.Tests.Companies
{
    public class CompanyTests
    {
        [Fact]
        public void ExtractAllProperties_ShouldExtractCorrectProperties()
        {
            // Arrange
            var company = new Company
            {
                Name = "Test Name",
                Url = "https://example.com",
                Email = "test@example.com",
                Phone = "1234567890",
                Website = "https://website.com",
                Address = new Address
                {
                    AddressLine = "12 rue du test",
                    City = "Testiland",
                    Country = "France",
                    State = "",
                    Zip = "75000"
                },
                OwnerId = "1",
                OtherProperties = new List<Property> {
                    CreateCustomProperty("custom_property", PropertyFieldType.TEXT).WithValue("custom_property_value")
                }
            };

            // Act
            var properties = company.ExtractAllProperties().ToList();

            // Assert
            properties.Should().HaveCount(8);
            properties.Should().ContainSingle(p => p.Name == "name" && p.Value == company.Name);
            properties.Should().ContainSingle(p => p.Name == "url" && p.Value == company.Url);
            properties.Should().ContainSingle(p => p.Name == "email" && p.Value == company.Email);
            properties.Should().ContainSingle(p => p.Name == "phone" && p.Value == company.Phone);
            properties.Should().ContainSingle(p => p.Name == "website" && p.Value == company.Website);
            properties.Should().ContainSingle(p => p.Name == "owner_id" && p.Value == company.OwnerId);
            properties.Should().ContainSingle(p => p.Name == "custom_property" && p.Value == "custom_property_value");
            properties.Should().ContainSingle(p => p.Name == "address" && p.Value == JsonSerializer.Serialize(company.Address, JsonSerializerOptions.Default));
        }
    }
}
