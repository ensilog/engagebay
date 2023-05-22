namespace Ensilog.Engagebay.Properties
{
    public static class PropertyFactory
    {
        public static Property CreateSystemProperty(string name, string value, PropertyFieldType type = null)
        {
            if (type == null)
            {
                type = PropertyFieldType.TEXT;
            }

            return new Property()
            {
                FieldType = type,
                IsSearchable = false,
                Name = name,
                Value = value,
                Type = PropertyType.SYSTEM
            };
        }
        public static Property CreateSystemProperty(string name, PropertyFieldType type = null)
        {
            return CreateSystemProperty(name, null, type);
        }

        public static Property CreateCustomProperty(string name, string value, PropertyFieldType type = null)
        {
            if (type == null)
            {
                type = PropertyFieldType.TEXT;
            }

            return new Property()
            {
                FieldType = type,
                IsSearchable = false,
                Name = name,
                Value = value,
                Type = PropertyType.CUSTOM
            };
        }

        public static Property CreateCustomProperty(string name, PropertyFieldType type = null)
        {
            return CreateCustomProperty(name, null, type);
        }
    }
}
