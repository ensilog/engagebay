using Ensilog.Engagebay.Properties;
using FluentAssertions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Tests.Properties
{
    public class PropertyTypeToStringConverterTests
    {

        private class TestClass
        {
            [JsonConverter(typeof(PropertyTypeToStringConverter))]
            [JsonPropertyName("type")]
            public PropertyType? Type { get; set; }
        }

        [Fact]
        public void CorrectType_Should_Deserialize()
        {
            // Plan
            string testString = "{\"type\": \"SYSTEM\"}";

            // Do
            var testResult = JsonSerializer.Deserialize<TestClass>(testString)!;

            // Check
            testResult.Type.Should().Be(PropertyType.SYSTEM);
        }


        [Fact]
        public void CorrectType_Should_Serialize()
        {
            // Plan
            TestClass testClass = new TestClass()
            {
                Type = PropertyType.CUSTOM
            };

            // Do
            string testResult = JsonSerializer.Serialize(testClass)!;

            // Check
            testResult.Should().Be("{\"type\":\"CUSTOM\"}");
        }
    }
}
