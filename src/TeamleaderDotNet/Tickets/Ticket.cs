using System;
using Newtonsoft.Json;
using TeamleaderDotNet.Common.JsonConvertors;

namespace TeamleaderDotNet.Tickets
{
    public class Ticket
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }

        [JsonProperty(PropertyName = "date_created")]
        [JsonConverter(typeof(UnixDateConverter))]
        public DateTime DateCreated { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "date_closed")]
        [JsonConverter(typeof(UnixDateConverter))]
        public DateTime? DateClosed { get; set; }

        [JsonProperty(PropertyName = "responsible_user_id")]
        public int? ResponsibleUserId { get; set; }

        [JsonProperty(PropertyName = "for")]
        public string For { get; set; }

        [JsonProperty(PropertyName = "for_id")]
        public int ForId { get; set; }

        [JsonProperty(PropertyName = "deleted")]
        public bool Deleted { get; set; }

        [JsonProperty(PropertyName = "optional_company_id")]
        public int? OptionalCompanyId { get; set; }

        [JsonProperty(PropertyName = "background_info_html")]
        public string BackgroundInfoHtml { get; set; }

        //[JsonProperty(PropertyName = "custom_fields")]
        //[JsonConverter(typeof(CustomFieldsConverter))]
        //public Dictionary<int, string> CustomFields { get; set; }
    }
}
