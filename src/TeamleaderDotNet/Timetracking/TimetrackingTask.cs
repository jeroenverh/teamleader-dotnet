using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TeamleaderDotNet.Common.JsonConvertors;
using TeamleaderDotNet.Crm;

namespace TeamleaderDotNet.Timetracking
{
    public class TimetrackingTask
    {
        [TeamleaderDataType(Name = "date_added")]
        [JsonConverter(typeof(UnixDateConverter))]
        [JsonProperty(PropertyName = "date_added")]
        public DateTime? DateAdded { get; set; }

        [JsonProperty(PropertyName = "estimated_time_required")]
        public int? EstimatedTimeRequired { get; set; }

        [JsonProperty(PropertyName = "estimated_time_used")]
        public int? EstimatedTimeUsed { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "finished")]
        public bool Finished { get; set; }

        [JsonProperty(PropertyName = "date_finished")]
        [JsonConverter(typeof(UnixDateConverter))]
        public DateTime? DateFinished { get; set; }

        [JsonProperty(PropertyName = "date_finished_formatted")]
        public string DateFinishedFormatted { get; set; }

        [JsonProperty(PropertyName = "priority")]
        public string Priority { get; set; }

        [JsonProperty(PropertyName = "due_date")]
        [JsonConverter(typeof(UnixDateConverter))]
        public DateTime? DueDate { get; set; }

        [JsonProperty(PropertyName = "due_date_formatted")]
        public string DueDateFormatted { get; set; }

        [JsonProperty(PropertyName = "project_id")]
        public int ProjectId { get; set; }

        [JsonProperty(PropertyName = "project_name")]
        public string ProjectName { get; set; }

        [JsonProperty(PropertyName = "milestone_name")]
        public string MilestoneName { get; set; }

        [JsonProperty(PropertyName = "related_ticket_id")]
        public int? RelatedTicketId { get; set; }

        [JsonProperty(PropertyName = "client_type")]
        public string ClientType { get; set; }

        [JsonProperty(PropertyName = "client_id")]
        public int? ClientId { get; set; }

        [JsonProperty(PropertyName = "client_name")]
        public string ClientName { get; set; }

        [JsonProperty(PropertyName = "responsible_users")]
        public ResponsibleUsers ResponsibleUsers { get; set; }

        [JsonProperty(PropertyName = "creator_name")]
        public string CreatorName { get; set; }

        [JsonProperty(PropertyName = "deleted")]
        public bool Deleted { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public int? TypeId { get; set; }

        [JsonProperty(PropertyName = "custom_fields")]
        [JsonConverter(typeof(CustomFieldsConverter))]
        public Dictionary<int, string> CustomFields { get; set; }
    }
}
