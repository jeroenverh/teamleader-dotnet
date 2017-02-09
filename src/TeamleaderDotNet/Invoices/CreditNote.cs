using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TeamleaderDotNet.Common.JsonConvertors;
using TeamleaderDotNet.Crm;
using TeamleaderDotNet.General;

namespace TeamleaderDotNet.Invoices
{
    public class CreditNote : Entity
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "creditnote_nr")]
        public int CreditNoteNr { get; set; }

        [JsonProperty(PropertyName = "creditnote_nr_detailed")]
        public string CreditNoteNrDetailed { get; set; }

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

        [JsonProperty(PropertyName = "related_invoice_id")]
        public string RelatedInvoiceId { get; set; }

        [JsonProperty(PropertyName = "items")]
        public InvoiceLine[] Items { get; set; }
        
    }

 
}
