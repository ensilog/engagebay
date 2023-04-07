using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ensilog.Engagebay.Json
{
    public sealed class UnixEpochDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            DateTime s_epoch = new DateTime(1970, 1, 1, 0, 0, 0);
            return s_epoch.AddSeconds(reader.GetInt64());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            DateTime s_epoch = new DateTime(1970, 1, 1, 0, 0, 0);

            long epoch = (int)(value - s_epoch).TotalSeconds;

            writer.WriteNumberValue(epoch);
        }
    }
}
