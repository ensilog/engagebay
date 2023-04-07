using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Contacts.Exceptions;
using Ensilog.Engagebay.Exceptions;
using Ensilog.Engagebay.Validators;
using RestSharp;

namespace Ensilog.Engagebay.Contacts
{
    public class AddScoreToContactByEmail : EngageBayCommand
    {
        public override Method Method => Method.Post;

        public override string Uri => "/dev/api/panel/subscribers/add-score";

        public override string ContentType => "application/x-www-form-urlencoded";

        public string Email { get; private set; }

        public int Score { get; private set; }

        public override string Body => $"email={Email}&score={Score}";

        public AddScoreToContactByEmail(string email, int score)
        {
            if (string.IsNullOrEmpty(email) || !EmailValidator.IsValidEmail(email))
            {
                throw new InvalidEmailException();
            }

            if (score < 0 || score > 100)
            {
                throw new InvalidScoreException();
            }

            Email = email;
            Score = score;
        }
    }

}
