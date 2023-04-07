using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Exceptions;
using RestSharp;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Ensilog.Engagebay.Tags
{
    public class ListContactTagsByEmail : EngageBayQuery<IEnumerable<Tag>>
    {
        public override Method Method => Method.Post;

        public override string Uri => $"/dev/api/panel/subscribers/get-tags/{_subscriberEmail}";

        public override string ContentType => "application/x-www-form-urlencoded";

        private string _subscriberEmail;

        public ListContactTagsByEmail(string subscriberEmail)
        {
            if (string.IsNullOrEmpty(subscriberEmail) || !IsValidEmail(subscriberEmail))
            {
                throw new InvalidEmailException();
            }

            _subscriberEmail = subscriberEmail;
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Use a stricter regex for email validation
                Regex regex = new Regex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");
                return regex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }
    }
}
