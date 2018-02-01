using Newtonsoft.Json;

namespace TeamleaderDotNet.Tickets
{
    public class TicketMessage : TicketMessageBase
    {
        [JsonProperty(PropertyName = "raw_message")]
        public string RawMessage { get; set; }

        [JsonProperty(PropertyName = "ticket_id")]
        public int? TicketId { get; set; }
    }
}
