using Newtonsoft.Json;
using TeamleaderDotNet.Crm;

namespace TeamleaderDotNet.Products
{
    public class Product : Entity
    {
        [TeamleaderDataType(Name = "Id")]
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }
        [TeamleaderDataType(Name = "external_id")]
        [JsonProperty(PropertyName = "external_id")]
        public string ExternalId { get; set; }
        [TeamleaderDataType(Name = "name")]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [TeamleaderDataType(Name = "vat")]
        [JsonProperty(PropertyName = "vat")]
        public string Vat { get; set; }
        [TeamleaderDataType(Name = "booking_account")]
        [JsonProperty(PropertyName = "booking_account")]
        public object BookingAccount { get; set; }
        [TeamleaderDataType(Name = "booking_account_id")]
        [JsonProperty(PropertyName = "booking_account_id")]
        public int BookingAccountId { get; set; }
        [TeamleaderDataType(Name = "stock")]
        [JsonProperty(PropertyName = "stock")]
        public int Stock { get; set; }
        [TeamleaderDataType(Name = "price_value_43269")]
        [JsonProperty(PropertyName = "price_value_43269")]
        public string Price { get; set; }
    }
}
