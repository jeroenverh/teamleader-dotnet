using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TeamleaderDotNet
{
    public abstract class TeamleaderApiBase
    {
        private const string ApiUrl = "https://www.teamleader.be/api";
        private const string Version = "1.0.0";
        private const int DefaultTimeout = 30;

        private readonly string _apiGroup;
        private readonly string _apiSecret;
        
        public string GetUserAgent()
        {
            return string.Format("TeamleaderDotNet/{0}", Version);
        }

        protected TeamleaderApiBase(string apiGroup, string apiSecret)
        {
            _apiGroup = apiGroup;
            _apiSecret = apiSecret;
            Timeout = DefaultTimeout;
        }

        /// <summary>
        /// The timeout for the API call. After this time the request will stop.
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// Makes the actual call to the TeamleaderApiBase API
        /// </summary>
        /// <typeparam name="T">The result type that is expected</typeparam>
        /// <param name="endPoint">The endpoint <example>helloWorld.php</example></param>
        /// <param name="fields">The fields that should be passed</param>
        /// <returns>The result from the webservice call</returns>
        protected async Task<T> DoCall<T>(string endPoint, List<KeyValuePair<string, string>> fields = null)
        {
            if (fields == null) fields = new List<KeyValuePair<string, string>>();
    
            // Add API Credentials
            fields.Add(new KeyValuePair<string, string>("api_group", _apiGroup));
            fields.Add(new KeyValuePair<string, string>("api_secret", _apiSecret));

            // Build full Endpoint URL
            var url = string.Format("{0}/{1}", ApiUrl, endPoint);

            // Init HttpClient
            var client = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(Timeout)
            };

            client.DefaultRequestHeaders.Add("User-Agent", GetUserAgent());

            // Call TeamleaderApiBase API
            HttpResponseMessage response = await client.PostAsync(url, new FormUrlEncodedContent(fields));

            return ParseHttpResponse<T>(response);
        }

        private T ParseHttpResponse<T>(HttpResponseMessage message)
        {
            var responseContent = message.Content;

            var jsonContent = responseContent.ReadAsStringAsync().Result;

            if (message.StatusCode == HttpStatusCode.BadRequest)
            {
                string url = "";

                var resultObjects = JObject.Parse(jsonContent);


                if (resultObjects["reason"] != null)
                {
                    throw new Exception(
                        string.Format("TeamleaderApiBase {0} API returned statuscode 400 Bad Request. Reason: {1}",
                            url, resultObjects["reason"]));
                }
                // in case no JSON could be parsed, log the response in the exception
                throw new Exception(
                    string.Format("TeamleaderApiBase {0} API returned statuscode 400 Bad Request. Data returned: {1}",
                        url, jsonContent));
            }


            return JsonConvert.DeserializeObject<T>(jsonContent);
        }




    }


}
