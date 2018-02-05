using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TeamleaderDotNet.Timetracking;

namespace TeamleaderDotNet.Common.JsonConvertors
{
    public class CustomFieldsConverter : JsonConverter
    {
        private static readonly Type[] s_types = { typeof(TimetrackingTask) };

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var jobject = JObject.Load(reader);
            var numberSeries = new NumberSeries(NumberSeriesDirections.Down);

            return jobject.Children<JProperty>().ToDictionary(
                property => int.TryParse(property.Name, out int number) ? number : numberSeries.Next(), 
                property => property.Value.ToString()
            );
        }

        public override bool CanConvert(Type objectType)
        {
            return s_types.Contains(objectType);
        }
    }
}
