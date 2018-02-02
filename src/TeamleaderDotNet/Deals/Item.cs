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
        public decimal LineTotalPriceExclusiveVat { get; set; }
        [JsonProperty("line_total_incl_vat")]
        public decimal LineTotalPriceInclusiveVat { get; set; }
        [JsonProperty("vat_rate")]
        public string VatRate { get; set; }
        [JsonProperty("account")]
        public string Account { get; set; }
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("price_per_unit")]
        public decimal? UnitPrice { get; set; }
        [JsonProperty("product_id")]
        public string ProductId { get; set; }
    }
}
