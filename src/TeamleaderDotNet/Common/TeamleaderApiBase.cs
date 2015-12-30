using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TeamleaderDotNet.Common
{
    public abstract class TeamleaderApiBase
    {
        private readonly ITeamleaderClient _teamleaderClient;
     
        protected TeamleaderApiBase(ITeamleaderClient teamleaderClient)
        {
            _teamleaderClient = teamleaderClient;
        }

        protected T DoCall<T>(string endPoint, List<KeyValuePair<string, string>> fields = null)
        {
            if (fields == null) fields = new List<KeyValuePair<string, string>>();
    
            // Add API Credentials
            fields.Add(new KeyValuePair<string, string>("api_group", _teamleaderClient.ApiGroup));
            fields.Add(new KeyValuePair<string, string>("api_secret", _teamleaderClient.ApiSecret));

            var jsonResponse = _teamleaderClient.DoCall(endPoint, fields);

            return JsonConvert.DeserializeObject<T>(jsonResponse.Result);
        }
    }
}
