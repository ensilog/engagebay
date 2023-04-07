using Ensilog.Engagebay.Addresses;
using Ensilog.Engagebay.Json;
using FluentAssertions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Tests.Json
{
    public class AddressStringToAddressDataConverterTests
    {
        private class TestClass
        {
            [JsonConverter(typeof(AddressStringToAddressDataConverter))]
            [JsonPropertyName("address")]
            public Address? Address { get; set; }
        }

        [Fact]
        public void CompleteStringAddress_Should_Deserialize()
        {
            // Plan
            string addressString = "{\"address\":\"{\\\"zip\\\":\\\"75000\\\", \\\"country\\\":\\\"France\\\", \\\"address\\\": \\\"8 rue des templiers\\\", \\\"city\\\": \\\"Paris\\\", \\\"state\\\": \\\"Seine\\\"}\"}";

            // Do
            TestClass test = JsonSerializer.Deserialize<TestClass>(addressString)!;

            // Check
            test.Address.Should().BeEquivalentTo(new Address()
            {
                AddressLine = "8 rue des templiers",
                City = "Paris",
                Country = "France",
                State = "Seine",
                Zip = "75000"
            });
        }

        [Fact]
        public void IncompleteStringAddress_Should_Deserialize()
        {
            // Plan
            string addressString = "{\"address\":\"{\\\"zip\\\":\\\"75000\\\", \\\"country\\\":\\\"France\\\", \\\"city\\\": \\\"Paris\\\", \\\"state\\\": \\\"Seine\\\"}\"}";

            // Do
            TestClass test = JsonSerializer.Deserialize<TestClass>(addressString)!;

            // Check
            test.Address.Should().BeEquivalentTo(new Address()
            {
                City = "Paris",
                Country = "France",
                State = "Seine",
                Zip = "75000"
            });
        }

        [Fact]
        public void EmptyAddress_Should_BeNull()
        {
            // Plan
            string addressString = "{\"address\":\"\"}";

            // Do
            TestClass test = JsonSerializer.Deserialize<TestClass>(addressString)!;

            // Check
            test.Address.Should().BeNull();
        }
    }
}
