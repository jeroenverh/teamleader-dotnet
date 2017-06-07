using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TeamleaderDotNet.Deals
{
    public class Item
    {
        [JsonProperty("text")]
        public string Name { get; set; }
        [JsonProperty("subtitle")]
        public string SubTitle { get; set; }
        [JsonProperty("line_total_excl_vat")]
        public double LineTotalPriceExclusiveVat { get; set; }
        [JsonProperty("line_total_incl_vat")]
        public double LineTotalPriceInclusiveVat { get; set; }
        [JsonProperty("vat_rate")]
        public string VatRate { get; set; }
        [JsonProperty("account")]
        public string Account { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }
        [JsonProperty("price_per_unit")]
        public double? UnitPrice { get; set; }
        [JsonProperty("product_id")]
        public string ProductId { get; set; }
    }
}
