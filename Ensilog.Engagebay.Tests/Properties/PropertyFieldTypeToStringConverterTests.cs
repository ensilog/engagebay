using Ensilog.Engagebay.Properties;
using FluentAssertions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Tests.Properties
{
    public class PropertyFieldTypeToStringConverterTests
    {
        private class TestClass
        {
            [JsonConverter(typeof(PropertyFieldTypeToStringConverter))]
            [JsonPropertyName("field_type")]
            public PropertyFieldType? FieldType { get; set; }
        }

        [Fact]
        public void CorrectType_Should_Deserialize()
        {
            // Plan
            string testString = "{\"field_type\": \"CHECKBOX\"}";

            // Do
            var testResult = JsonSerializer.Deserialize<TestClass>(testString)!;

            // Check
            testResult.FieldType.Should().Be(PropertyFieldType.CHECKBOX);
        }


        [Fact]
        public void CorrectType_Should_Serialize()
        {
            // Plan
            TestClass testClass = new TestClass()
            {
                FieldType = PropertyFieldType.LIST
            };

            // Do
            string testResult = JsonSerializer.Serialize(testClass)!;

            // Check
            testResult.Should().Be("{\"field_type\":\"LIST\"}");
        }
    }
}
