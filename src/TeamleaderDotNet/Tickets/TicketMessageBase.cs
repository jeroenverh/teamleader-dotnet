using System;
using Newtonsoft.Json;
using TeamleaderDotNet.Common.JsonConvertors;

namespace TeamleaderDotNet.Tickets
{
    public abstract class TicketMessageBase
    {
        [JsonProperty(PropertyName= "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        //date: unix timestamp
        [JsonProperty(PropertyName = "date")]
        [JsonConverter(typeof(UnixDateConverter))]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "date_formatted")]
        public string DateFormatted { get; set; }

        [JsonProperty(PropertyName = "from")]
        public string From { get; set; }

        [JsonProperty(PropertyName = "from_id")]
        public int? FromId { get; set; }

        [JsonProperty(PropertyName = "internal_message")]
        public bool InternalMessage { get; set; }
    }
}
