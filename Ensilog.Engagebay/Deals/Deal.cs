using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Json;
using Ensilog.Engagebay.Properties;
using Ensilog.Engagebay.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Deals
{
    public class Deal : PageableObject
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("unique_id")]
        public int? UniqueId { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("track_id")]
        public int? TrackId { get; set; }

        [JsonPropertyName("amount")]
        public float? Amount { get; set; }

        [JsonPropertyName("currency_type")]
        public string Currency { get; set; }

        [JsonPropertyName("closed_date")]
        [JsonConverter(typeof(UnixEpochDateTimeConverter))]
        public DateTime? ClosedDate { get; set; }

        [JsonPropertyName("owner_id")]
        public string OwnerId { get; set; }


        public override IEnumerable<Property> ExtractAllProperties()
        {
            foreach (var baseProp in base.ExtractAllProperties())
            {
                yield return baseProp;
            }

            if (Name != null)
                yield return DealKnownProperties.Name.WithValue(Name);

            if (UniqueId != null)
                yield return DealKnownProperties.UniqueId.WithValue(UniqueId.Value);
            if (TrackId != null)
                yield return DealKnownProperties.TrackId.WithValue(TrackId.Value);

            if (Description != null)
                yield return DealKnownProperties.Description.WithValue(Description);

            if (Amount != null)
                yield return DealKnownProperties.Amount.WithValue(Amount.Value);

            if (Currency != null)
                yield return DealKnownProperties.Currency.WithValue(Currency);

            if (ClosedDate != null)
                yield return DealKnownProperties.ClosedDate.WithValue(ClosedDate.Value);

            if (OwnerId != null)
                yield return DealKnownProperties.OwnerId.WithValue(OwnerId);

        }

    }
}
