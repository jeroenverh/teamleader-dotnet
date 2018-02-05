using System;
using Newtonsoft.Json;
using TeamleaderDotNet.Common.JsonConvertors;

namespace TeamleaderDotNet.Planning
{
    public class PlanningTask
    {
        [JsonProperty(PropertyName="todo_id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "startdate")]
        [JsonConverter(typeof(UnixDateConverter))]
        public DateTime? StartDate { get; set; }

        [JsonProperty(PropertyName = "startdate_formatted")]
        public string StartDateFormatted { get; set; }

        [JsonProperty(PropertyName = "duration_minutes")]
        public int DurationMinutes { get; set; }

        [JsonProperty(PropertyName = "user_id")]
        public int? UserId { get; set; }

        [JsonProperty(PropertyName = "project_id")]
        public int? ProjectId { get; set; }
    }
}
