using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TeamleaderDotNet.Timetracking
{
    public class ResponsibleUsers
    {
        [JsonProperty(PropertyName = "team_id")]
        public int TeamId { get; set; }

        [JsonProperty(PropertyName = "users")]
        public int[] Users { get; set; }
    }
}
