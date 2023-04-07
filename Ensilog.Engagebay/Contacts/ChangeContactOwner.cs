using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Contacts.Exceptions;
using Ensilog.Engagebay.Exceptions;
using Ensilog.Engagebay.Validators;
using RestSharp;

namespace Ensilog.Engagebay.Contacts
{
    /// <summary>
    /// WARNING: This class is not working as is. API returns an error about content type.
    /// Further investigation is required.
    /// </summary>
    public class ChangeContactOwner : EngageBayCommand
    {
        public long SubscriberId { get; }
        public string OwnerEmail { get; }

        public ChangeContactOwner(long subscriberId, string ownerEmail)
        {
            if (subscriberId <= 0)
                throw new ContactIdInvalidException();

            if (string.IsNullOrEmpty(ownerEmail) || !EmailValidator.IsValidEmail(ownerEmail))
                throw new InvalidEmailException();

            SubscriberId = subscriberId;
            OwnerEmail = ownerEmail;
        }

        public override string Uri => $"/dev/api/panel/subscribers/update-owner-by-email?subscriberId={SubscriberId}&ownerEmail={OwnerEmail}";

        public override string ContentType => "application/json";

        public override Method Method => Method.Post;
    }

}
