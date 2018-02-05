using System;
using Newtonsoft.Json;
using TeamleaderDotNet.Common.JsonConvertors;

namespace TeamleaderDotNet.Planning
{
    public class DayOffByUser
    {
        [JsonProperty(PropertyName = "date")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "duration_hours")]
        public int DurationHours { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "approved")]
        [JsonConverter(typeof(YesNoConverter))]
        public bool? Approved { get; set; }
    }
}
