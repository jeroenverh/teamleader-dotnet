using System;
using Newtonsoft.Json;
using TeamleaderDotNet.Common.JsonConvertors;
using TeamleaderDotNet.Crm;

namespace TeamleaderDotNet.Invoices
{
    public class InvoiceLine : Entity
    {
        [JsonProperty(PropertyName = "subtitle")]
        public string subtitle { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string text { get; set; }

        [JsonProperty(PropertyName = "line_total_excl_vat")]
        public double line_total_excl_vat { get; set; }

        [JsonProperty(PropertyName = "line_total_incl_vat")]
        public double line_total_incl_vat { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public double amount { get; set; }

        [JsonProperty(PropertyName = "price_per_unit")]
        public double price_per_unit { get; set; }

        [JsonProperty(PropertyName = "vat_rate")]
        public VatTariff vat_rate { get; set; }




    }
}
