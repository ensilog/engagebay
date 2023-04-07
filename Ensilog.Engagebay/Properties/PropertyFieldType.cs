using Ensilog.Engagebay.Abstractions;
using System;
using System.Collections.Generic;

namespace Ensilog.Engagebay.Properties
{
    public class PropertyFieldType : ValueObject
    {
        private string _fieldType;
        public string FieldType => _fieldType;

        private Type _dataType;
        public Type DataType => _dataType;

        public static PropertyFieldType TEXT => new PropertyFieldType("TEXT", typeof(string));
        public static PropertyFieldType DATE => new PropertyFieldType("DATE", typeof(DateTime));
        public static PropertyFieldType LIST => new PropertyFieldType("LIST", typeof(string));
        public static PropertyFieldType CHECKBOX => new PropertyFieldType("CHECKBOX", typeof(bool));
        public static PropertyFieldType TEXTAREA => new PropertyFieldType("TEXTAREA", typeof(string));
        public static PropertyFieldType NUMBER => new PropertyFieldType("NUMBER", typeof(long));
        public static PropertyFieldType CURRENCY => new PropertyFieldType("CURRENCY", typeof(double));
        public static PropertyFieldType MULTICHECKBOX => new PropertyFieldType("MULTICHECKBOX", typeof(string));
        public static PropertyFieldType URL => new PropertyFieldType("URL", typeof(string));
        public static PropertyFieldType PHONE => new PropertyFieldType("PHONE", typeof(string));
        public static PropertyFieldType FILE => new PropertyFieldType("FILE", typeof(string[]));

        /// <summary>
        /// This field type does not exist in Engage Bay API.
        /// It is created to allow deserialization even if the API adds a possible value in the future.
        /// </summary>
        public static PropertyFieldType UNKNOWN => new PropertyFieldType("UNKNOWN", typeof(string));

        private PropertyFieldType(string type, Type dataType)
        {
            _fieldType = type;
            _dataType = dataType;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _fieldType;
        }
    }
}
