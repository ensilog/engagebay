using Ensilog.Engagebay.Json;
using FluentAssertions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Tests.Json
{
    public class UnixEpochDateTimeConverterTests
    {
        private class TestClass
        {
            [JsonConverter(typeof(UnixEpochDateTimeConverter))]
            [JsonPropertyName("date")]
            public DateTime Date { get; set; }
        }


        [Fact]
        public void EpochTime_Should_Deserialize()
        {
            // Plan
            string testString = "{\"date\": 1675977300}";

            // Do
            TestClass test = JsonSerializer.Deserialize<TestClass>(testString)!;

            // Check
            test.Date.Should().Be(new DateTime(2023, 2, 9, 21, 15, 0));
        }
    }
}
