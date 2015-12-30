using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TeamleaderDotNet.Common
{
    public class TeamleaderClient : ITeamleaderClient
    {
        private readonly string _apiUrl;
        private readonly string _apiGroup;
        private readonly string _apiSecret;
        private readonly string _userAgent;
        private readonly int _timeOut;

        public TeamleaderClient(string apiUrl, string apiGroup, string apiSecret, string userAgent, int timeOut)
        {
            _apiUrl = apiUrl;
            _apiGroup = apiGroup;
            _apiSecret = apiSecret;
            _userAgent = userAgent;
            _timeOut = timeOut;
        }

        /// <summary>
        /// Client used to channel calls to Teamleader
        /// </summary>
        public async Task<string> DoCall(string endPoint, List<KeyValuePair<string, string>> fields)
        {
            // Build full Endpoint URL
            var url = string.Format("{0}/{1}", _apiUrl, endPoint);

            // Init HttpClient
            var client = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(_timeOut)
            };

            client.DefaultRequestHeaders.Add("User-Agent", _userAgent);

            // Call TeamleaderApiBase API
            HttpResponseMessage response = await client.PostAsync(url, new FormUrlEncodedContent(fields));

            var responseContent = response.Content;

            var jsonContent = responseContent.ReadAsStringAsync().Result;

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var resultObjects = JObject.Parse(jsonContent);

                if (resultObjects["reason"] != null)
                {
                    throw new Exception(
                        string.Format("TeamleaderApiBase {0} API returned statuscode 400 Bad Request. Reason: {1}", url, resultObjects["reason"]));
                }
                // in case no JSON could be parsed, log the response in the exception
                throw new Exception(
                    string.Format("TeamleaderApiBase {0} API returned statuscode 400 Bad Request. Data returned: {1}", url, jsonContent));
            }


            return jsonContent;

        }

        public string ApiGroup
        {
            get
            {
                return _apiGroup;
            } 
        }

        public string ApiSecret
        {
            get
            {
                return _apiSecret;
            }
        }
    }

 
}
