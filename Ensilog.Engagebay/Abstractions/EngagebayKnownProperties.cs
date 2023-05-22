using Ensilog.Engagebay.Properties;
using static Ensilog.Engagebay.Properties.PropertyFactory;

namespace Ensilog.Engagebay.Abstractions
{
    public class EngagebayKnownProperties
    {
        public static readonly Property Score = CreateSystemProperty("score", PropertyFieldType.NUMBER);
        public static readonly Property Tags = CreateSystemProperty("tags", PropertyFieldType.LIST);
        public static readonly Property CreatedTime = CreateSystemProperty("created_time", PropertyFieldType.DATE);
        public static readonly Property UpdatedTime = CreateSystemProperty("updated_time", PropertyFieldType.DATE);

    }
}
