using System;
using Newtonsoft.Json;
using TeamleaderDotNet.Common.JsonConvertors;
using TeamleaderDotNet.Crm;

namespace TeamleaderDotNet.Invoices
{
    public class Invoice : Entity
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "invoice_nr")]
        public int InvoiceNr { get; set; }

        [JsonProperty(PropertyName = "invoice_nr_detailed")]
        public string InvoiceNrDetailed { get; set; }

        [JsonProperty(PropertyName = "booked")]
        public bool Booked { get; set; }

        [JsonProperty(PropertyName = "structured_communication")]
        public string StructuredCommunication { get; set; }

        [JsonProperty(PropertyName = "date")]
        [JsonConverter(typeof(UnixDateConverter))]
        public DateTime? Date { get; set; }

        [JsonProperty(PropertyName = "date_formatted")]
        public string DateFormatted { get; set; }

        [JsonProperty(PropertyName = "date_paid")]
        [JsonConverter(typeof(UnixDateConverter))]
        public DateTime? DatePaid { get; set; }

        [JsonProperty(PropertyName = "date_paid_formatted")]
        public string DatePaidFormatted { get; set; }

        [JsonProperty(PropertyName = "Paid")]
        public bool Paid { get; set; }

        [TeamleaderDataType(Name = "due_date")]
        [JsonProperty(PropertyName = "due_date")]
        [JsonConverter(typeof(UnixDateConverter))]
        public DateTime? DueDate { get; set; }

        [JsonProperty(PropertyName = "due_date_formatted")]
        public string DueDateFormatted { get; set; }



    }
}
