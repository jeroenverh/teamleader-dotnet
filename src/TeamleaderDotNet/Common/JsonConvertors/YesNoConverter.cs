using System;
using Newtonsoft.Json;

namespace TeamleaderDotNet.Common.JsonConvertors
{
    public class YesNoConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value;

            if (string.IsNullOrWhiteSpace(value?.ToString()))
            {
                return false;
            }

            switch ((string)value)
            {
                case "yes": return true;
                case "no": return false;

                default:
                    return null;
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string) || objectType == typeof(bool) || objectType == typeof(bool?);
        }
    }
}
