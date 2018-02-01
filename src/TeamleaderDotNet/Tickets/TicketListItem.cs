using System;
using Newtonsoft.Json;
using TeamleaderDotNet.Common.JsonConvertors;

namespace TeamleaderDotNet.Tickets
{
    public class TicketListItem
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "for")]
        public string For { get; set; }

        [JsonProperty(PropertyName = "for_id")]
        public int ForId { get; set; }

        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }

        [JsonProperty(PropertyName = "date_created")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime DateCreated { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "responsible_sys_client_id")]
        public int? SysClientId { get; set; }

        [JsonProperty(PropertyName = "time_spent")]
        public int? TimeSpent { get; set; }
    }
}
