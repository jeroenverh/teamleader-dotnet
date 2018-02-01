using Newtonsoft.Json;

namespace TeamleaderDotNet.Users
{
    public class User
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "gsm")]
        public string Gsm { get; set; }

        [JsonProperty(PropertyName = "telephone")]
        public string Telephone { get; set; }

        [JsonProperty(PropertyName = "team_id")]
        public int TeamId { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }
    }
}
