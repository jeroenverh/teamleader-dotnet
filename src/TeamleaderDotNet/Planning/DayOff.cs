using System;
using Newtonsoft.Json;
using TeamleaderDotNet.Common.JsonConvertors;

namespace TeamleaderDotNet.Planning
{
    public class DayOff
    {
        [JsonProperty(PropertyName="id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "date")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime Date { get; set; }
    }
}
