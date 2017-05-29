using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TeamleaderDotNet.Common.JsonConvertors;
using TeamleaderDotNet.Crm;

namespace TeamleaderDotNet.Deals
{
    public class Deal : Entity
    {
        public int Id { get; set; }

        [TeamleaderDataType(Name = "title")]
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [TeamleaderDataType(Name = "responsible_user_id")]
        [JsonProperty(PropertyName = "responsible_user_id")]
        public string ResponsibleUserId { get; set; }


        [TeamleaderDataType(Name = "for_id")]
        [JsonProperty(PropertyName = "for_id")]
        public string ForId { get; set; }

        [TeamleaderDataType(Name = "offerte_nr")]
        [JsonProperty(PropertyName = "offerte_nr")]
        public string OfferteNr { get; set; }

        [TeamleaderDataType(Name = "quotation_nr")]
        [JsonProperty(PropertyName = "quotation_nr")]
        public string QuotationNr { get; set; }

        [TeamleaderDataType(Name = "source_id")]
        [JsonProperty(PropertyName = "source_id")]
        public string SourceId { get; set; }

        [TeamleaderDataType(Name = "phase_id")]
        [JsonProperty(PropertyName = "phase_id")]
        public string PhaseId { get; set; }

        [TeamleaderDataType(Name = "probability")]
        [JsonProperty(PropertyName = "probability")]
        public string Probability { get; set; }

        [TeamleaderDataType(Name = "reason_refused")]
        [JsonProperty(PropertyName = "reason_refused")]
        public string ReasonRefused { get; set; }

        [TeamleaderDataType(Name = "total_price_excl_vat")]
        [JsonProperty(PropertyName = "total_price_excl_vat")]
        public string TotalPriceExclVat { get; set; }

        [TeamleaderDataType(Name = "quotation_file_id")]
        [JsonProperty(PropertyName = "quotation_file_id")]
        public string QuotationFileId { get; set; }

        [TeamleaderDataType(Name = "entry_date")]
        [JsonConverter(typeof(UnixDateConverter))]
        [JsonProperty(PropertyName = "entry_date")]
        public DateTime EntryDate { get; set; }

        [TeamleaderDataType(Name = "latest_activity_date")]
        [JsonConverter(typeof(UnixDateConverter))]
        [JsonProperty(PropertyName = "latest_activity_date")]
        public DateTime LatestActivityDate { get; set; }

        [TeamleaderDataType(Name = "close_date")]
        [JsonConverter(typeof(UnixDateConverter))]
        [JsonProperty(PropertyName = "close_date")]
        public DateTime CloseDate { get; set; }

        [TeamleaderDataType(Name = "date_won")]
        [JsonConverter(typeof(UnixDateConverter))]
        [JsonProperty(PropertyName = "date_won")]
        public DateTime DateWon { get; set; }

        [TeamleaderDataType(Name = "date_added")]
        [JsonConverter(typeof(UnixDateConverter))]
        [JsonProperty(PropertyName = "date_added")]
        public DateTime DateAdded { get; set; }

        [TeamleaderDataType(Name = "date_lost")]
        [JsonConverter(typeof(UnixDateConverter))]
        [JsonProperty(PropertyName = "date_lost")]
        public DateTime DateLost { get; set; }

        [TeamleaderDataType(Name = "date_last_activity")]
        [JsonConverter(typeof(UnixDateConverter))]
        [JsonProperty(PropertyName = "date_last_activity")]
        public DateTime DateLastActivity { get; set; }

        [TeamleaderDataType(Name = "deleted")]
        [JsonProperty(PropertyName = "deleted")]
        public bool Deleted{ get; set; }

        [JsonProperty(PropertyName = "custom_fields")]
        public JObject CustomFields { get; set; }

    }
}
