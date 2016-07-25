using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TeamleaderDotNet.Invoices;

namespace TeamleaderDotNet.Common
{
    public abstract class TeamleaderApiBase
    {
        private readonly ITeamleaderClient _teamleaderClient;
        protected readonly EnumMapper _enumMapper;
     
        protected TeamleaderApiBase(ITeamleaderClient teamleaderClient)
        {
            _teamleaderClient = teamleaderClient;
            _enumMapper = new EnumMapper();
        }

        protected T DoCall<T>(string endPoint, List<KeyValuePair<string, string>> fields = null)
        {
            if (fields == null) fields = new List<KeyValuePair<string, string>>();
    
            // Add API Credentials
            fields.Add(new KeyValuePair<string, string>("api_group", _teamleaderClient.ApiGroup));
            fields.Add(new KeyValuePair<string, string>("api_secret", _teamleaderClient.ApiSecret));

            var jsonResponse = _teamleaderClient.DoCall(endPoint, fields);

            if (typeof (T) == typeof (bool))
            {
                var booleanResult = jsonResponse.Result;

                return (T)(object)(booleanResult == "\"OK\"");
            }

            var result = jsonResponse.Result;

            return JsonConvert.DeserializeObject<T>(result);
        }

        protected Stream DoStreamCall(string endPoint, List<KeyValuePair<string, string>> fields = null)
        {
            if (fields == null) fields = new List<KeyValuePair<string, string>>();

            // Add API Credentials
            fields.Add(new KeyValuePair<string, string>("api_group", _teamleaderClient.ApiGroup));
            fields.Add(new KeyValuePair<string, string>("api_secret", _teamleaderClient.ApiSecret));

            var result = _teamleaderClient.DoStreamCall(endPoint, fields);
           
            return result.Result;
        }
    }
}
