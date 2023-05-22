using Ensilog.Engagebay.Abstractions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Properties
{
    public class Property : ValueObject
    {
        public static string DatePropertyFormat = "dd/MM/yyyy";

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("field_type")]
        [JsonConverter(typeof(PropertyFieldTypeToStringConverter))]
        public PropertyFieldType FieldType { get; set; }

        [JsonPropertyName("is_searchable")]
        public bool IsSearchable { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(PropertyTypeToStringConverter))]
        public PropertyType Type { get; set; }

        [JsonPropertyName("subtype")]
        public string SubType { get; set; }

        public Property()
        {

        }

        public Property WithValue(string value)
        {
            Value = value;
            return this;
        }

        public Property WithValue(int value)
        {
            Value = value.ToString();
            return this;
        }

        public Property WithValue(DateTime value)
        {
            Value = value.ToString(DatePropertyFormat);
            return this;
        }

        public Property WithValue(float value)
        {
            Value = value.ToString("F", CultureInfo.InvariantCulture);
            return this;
        }

        public Property WithSubType(string subtype)
        {
            SubType = subtype;
            return this;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return FieldType;
            yield return Type;
            yield return SubType;
        }
    }
}
