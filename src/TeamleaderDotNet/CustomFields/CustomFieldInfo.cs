using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TeamleaderDotNet.Crm;

namespace TeamleaderDotNet.CustomFields
{
    public class CustomFieldInfo : Entity
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "for")]
        public string ForObjectType { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "options")]
        public JObject Options { get; set; }
    }
}
