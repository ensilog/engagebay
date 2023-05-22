using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Addresses;
using Ensilog.Engagebay.Contacts;
using Ensilog.Engagebay.Json;
using Ensilog.Engagebay.Properties;
using Ensilog.Engagebay.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Companies
{
    public class Company : PageableObject
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("address")]
        [JsonConverter(typeof(AddressStringToAddressDataConverter))]
        public Address Address { get; set; }

        [JsonPropertyName("owner_id")]
        public string OwnerId { get; set; }

        public override IEnumerable<Property> ExtractAllProperties()
        {
            foreach (var baseProp in base.ExtractAllProperties())
            {
                yield return baseProp;
            }

            if (Name != null)
                yield return CompanyKnownProperties.Name.WithValue(Name);

            if (Url != null)
                yield return CompanyKnownProperties.Url.WithValue(Url);

            if (Email != null)
                yield return CompanyKnownProperties.Email.WithValue(Email);

            if (Phone != null)
                yield return CompanyKnownProperties.Phone.WithValue(Phone);

            if (Website != null)
                yield return CompanyKnownProperties.Website.WithValue(Website);

            if (OwnerId != null)
                yield return CompanyKnownProperties.OwnerId.WithValue(OwnerId);

            if (Address != null)
                yield return ContactKnownProperties.Address.WithValue(JsonSerializer.Serialize(Address));
        }
    }
}
