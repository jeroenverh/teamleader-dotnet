using System;
using Newtonsoft.Json;

namespace TeamleaderDotNet.Crm
{
    public class Company : Entity
    {
        public int Id { get; set; }

        [TeamleaderDataType(Name = "name")]
        public string name { get; set; }

        [TeamleaderDataType(Name = "email")]
        public string email { get; set; }


        [TeamleaderDataType(Name = "website")]
        public string website { get; set; }

        [TeamleaderDataType(Name = "taxcode", UpdateField = "vat_code")]
        public string taxcode { get; set; }

        [TeamleaderDataType(Name = "kvk_nummer")]
        public string kvk_nummer { get; set; }

        [TeamleaderDataType(Name = "telephone")]
        public string telephone { get; set; }

        [TeamleaderDataType(Name = "fax")]
        public string fax { get; set; }

        [TeamleaderDataType(Name = "iban")]
        public string iban { get; set; }

        [TeamleaderDataType(Name = "bic")]
        public string bic { get; set; }

        [TeamleaderDataType(Name = "country")]
        public string country { get; set; }

        [TeamleaderDataType(Name = "zipcode")]
        public string zipcode { get; set; }

        [TeamleaderDataType(Name = "city")]
        public string city { get; set; }

        [TeamleaderDataType(Name = "street")]
        public string street { get; set; }

        [TeamleaderDataType(Name = "number")]
        public string number { get; set; }

        [TeamleaderDataType(Name = "pricelist_id")]
        public string pricelist_id { get; set; }

        [TeamleaderDataType(Name = "date_added")]
        [JsonProperty(PropertyName = "date_added")]
        [JsonConverter(typeof(UnixDateConverter))]
        public DateTime DateAdded { get; set; }

        [TeamleaderDataType(Name = "account_manager_id")]
        public string account_manager_id { get; set; }

        [TeamleaderDataType(Name = "business_type")]
        public string business_type { get; set; }

        [TeamleaderDataType(Name = "language_code", UpdateField = "language")]
        public string language { get; set; }

        [TeamleaderDataType(Name = "vat_liability")]
        public string vat_liability { get; set; }

        [TeamleaderDataType(Name = "payment_term")]
        public string payment_term { get; set; }


        [TeamleaderDataType(Name = "background_info_html")]
        public string background_info_html { get; set; }


        //[TeamleaderDataType(Name = "extra_addresses")]
        //public string[] extra_addresses { get; set; }

        //public string[] Tags { get; set; }

        //[TeamleaderDataType(Name = "deleted")]
        public bool deleted{ get; set; }

        //public string[] custom_fields { get; set; }



    }
}
