using Ensilog.Engagebay.Contacts;
using Ensilog.Engagebay.Contacts.Exceptions;
using Ensilog.Engagebay.Exceptions;
using FluentAssertions;

namespace Ensilog.Engagebay.Tests.Contacts
{
    /// <summary>
    /// WARNING: This action seems not to be working on engage bay with a HTTP Method not allowed.
    /// Further investigation is needed.
    /// </summary>
    public class AddScoreToContactByEmailTests
    {
        [Fact]
        public void ValidParameters_Should_Construct()
        {
            var command = new AddScoreToContactByEmail("test@example.com", 100);

            command.Email.ToString().Should().Be("test@example.com");
            command.Score.Should().Be(100);
            command.Method.Should().Be(RestSharp.Method.Post);
            command.ContentType.Should().Be("application/x-www-form-urlencoded");
            command.Uri.Should().Be("/dev/api/panel/subscribers/add-score");
            command.Body.Should().Be("email=test@example.com&score=100");
        }

        [Fact]
        public void NullEmail_Should_ThrowException()
        {
            Action act = () => new AddScoreToContactByEmail(null, 100);
            act.Should().Throw<InvalidEmailException>();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(101)]
        public void InvalidScore_Should_ThrowException(int invalidScore)
        {
            Action act = () => new AddScoreToContactByEmail("test@example.com", invalidScore);
            act.Should().Throw<InvalidScoreException>();
        }
    }
}
