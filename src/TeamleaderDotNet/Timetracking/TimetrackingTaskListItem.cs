using Newtonsoft.Json;

namespace TeamleaderDotNet.Timetracking
{
    public class TimetrackingTaskListItem
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "milestone_id")]
        public int? MilestoneId { get; set; }

        [JsonProperty(PropertyName = "project_id")]
        public int? ProjectId { get; set; }

        [JsonProperty(PropertyName = "cf_value_45254")]
        public string Requester { get; set; }

        [JsonProperty(PropertyName = "cf_value_9964")]
        public string TfsItem { get; set; }

        public string[] CustomFields { get; set; }
    }
}
