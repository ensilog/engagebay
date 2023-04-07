using Ensilog.Engagebay.Abstractions;
using System.Collections.Generic;

namespace Ensilog.Engagebay.Properties
{
    public class PropertyType : ValueObject
    {
        private string _type;
        public string Type => _type;

        public static PropertyType SYSTEM => new PropertyType("SYSTEM");
        public static PropertyType CUSTOM => new PropertyType("CUSTOM");

        /// <summary>
        /// This value does not exist in Engage Bay API. It is only used while deserializing
        /// In case API adds in the future some other value.
        /// </summary>
        public static PropertyType UNKNOWN => new PropertyType("UNKNOWN");

        private PropertyType(string type)
        {
            _type = type;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Type;
        }
    }
}
