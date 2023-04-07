using Ensilog.Engagebay.Tags;
using Ensilog.Engagebay.Tags.Exceptions;
using FluentAssertions;

namespace Ensilog.Engagebay.Tests.Tags
{
    public class TagTests
    {
        [Theory]
        [InlineData("tag")]
        [InlineData("tag_test")]
        [InlineData("tag test")]
        public void ValidTagNames_Should_CreateTag(string testName)
        {
            // Plan

            // Act
            var tag = new Tag(testName);

            // Check
            tag.TagValue.Should().Be(testName);
        }

        [Theory]
        [InlineData("1tag")]
        [InlineData("tag-test")]
        [InlineData("tag#test")]
        public void InvalidTagNames_Should_Throw(string testName)
        {
            // Plan

            // Act
            Action act = () => new Tag(testName);

            // Check
            act.Should().Throw<TagNameInvalidFormatException>();
        }
    }
}
