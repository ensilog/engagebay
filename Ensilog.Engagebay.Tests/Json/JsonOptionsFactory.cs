using System.Text.Json;

namespace Ensilog.Engagebay.Tests.Json
{
    public static class JsonSerializerOptionsFactory
    {
        public static JsonSerializerOptions GetDefaultOptions()
        {
            var defaults = new JsonSerializerOptions(JsonSerializerDefaults.Web);

            defaults.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault;

            return defaults;
        }
    }
}
