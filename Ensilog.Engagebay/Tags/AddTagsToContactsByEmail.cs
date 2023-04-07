using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using Ensilog.Engagebay.Validators;
using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Exceptions;
using Ensilog.Engagebay.Tags.Exceptions;

namespace Ensilog.Engagebay.Tags
{
    public class AddTagsToContactsByEmail : EngageBayCommand<string>
    {
        public override string Uri => "/dev/api/panel/subscribers/email/tags/add";

        public override string Body => $"email={_email}&tags={JsonSerializer.Serialize(_tags.Select(t => t.TagValue))}";

        public override string ContentType => "application/x-www-form-urlencoded";

        private string _email;
        private IEnumerable<Tag> _tags;

        public AddTagsToContactsByEmail(string email, params string[] tags)
        {
            if (!EmailValidator.IsValidEmail(email))
                throw new InvalidEmailException();

            if (tags == null || tags.Length == 0)
                throw new NoTagHasBeenProvidedException();

            _tags = tags.Select(tName => new Tag(tName));
            _email = email;
        }
    }
}
