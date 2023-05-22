using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Addresses;
using Ensilog.Engagebay.Json;
using Ensilog.Engagebay.Properties;
using Ensilog.Engagebay.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Contacts
{
    public class Contact : PageableObject
    {
        [JsonPropertyName("name")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastname")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("address")]
        [JsonConverter(typeof(AddressStringToAddressDataConverter))]
        public Address Address { get; set; }

        [JsonPropertyName("companyIds")]
        public IEnumerable<long> CompanyIds { get; set; }

        public override string ToString()
        {
            return $"Contact #{Id} - {FirstName} {LastName} - {Email}";
        }

        public override IEnumerable<Property> ExtractAllProperties()
        {
            foreach (var pr in base.ExtractAllProperties())
            {
                yield return pr;
            }

            if (FirstName != null)
                yield return ContactKnownProperties.FirstName.WithValue(FirstName);

            if (LastName != null)
                yield return ContactKnownProperties.LastName.WithValue(LastName);

            if (Email != null)
                yield return ContactKnownProperties.Email.WithValue(Email);

            if (Phone != null)
                yield return ContactKnownProperties.PhoneWork.WithValue(Phone);

            if (Role != null)
                yield return ContactKnownProperties.Role.WithValue(Role);

            if(Address != null)
                yield return ContactKnownProperties.Address.WithValue(JsonSerializer.Serialize(Address));

            if (Website != null)
                yield return ContactKnownProperties.WebsiteUrl.WithValue(Website);
        }
    }
}
