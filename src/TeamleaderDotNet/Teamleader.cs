using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TeamleaderDotNet.Crm;

namespace TeamleaderDotNet
{
    public abstract class Teamleader
    {
        const string ApiUrl = "https://www.teamleader.be/api";
        const string Version = "1.0.0";
   
        private readonly string _apiGroup;
        private readonly string _apiSecret;
        private string _userAgent;
        private const int _timeOut = 30;


        public string getUserAgent()
        {
            return string.Format("TeamleaderDotNet/{0} {1}", Version, _userAgent);
        }

        protected Teamleader(string apiGroup, string apiSecret)
        {
            _apiGroup = apiGroup;
            _apiSecret = apiSecret;
            Timeout = _timeOut;

        }

            /**
     * Set the timeout
     * After this time the request will stop.
     * You should handle any errors triggered by this.
     *
     * @param $seconds int timeout in seconds.
     */
        public int Timeout { get; set; }

        
    /**
     * Make the call
     *
     * @param  string $endPoint The endpoint.
     * @param  array  $fields   The fields that should be passed.
     * @return mixed
     */

        protected async Task<T> DoCall<T>(string endPoint, List<KeyValuePair<string, string>> fields = null)
    {
      

        if(fields == null) fields = new List<KeyValuePair<string, string>>();

        // Add credentials
        fields.Add(new KeyValuePair<string, string>("api_group", _apiGroup));
        fields.Add(new KeyValuePair<string, string>("api_secret", _apiSecret));
        
        // Build Url
        var url = string.Format("{0}/{1}", ApiUrl, endPoint);
        var client = new HttpClient();
        
        client.Timeout = TimeSpan.FromSeconds(Timeout);
        client.DefaultRequestHeaders.Add("User-Agent", getUserAgent());

        HttpResponseMessage response = await client.PostAsync(url, new FormUrlEncodedContent(fields));
        HttpContent responseContent = response.Content;
        string jsonContent = responseContent.ReadAsStringAsync().Result;

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var resultObjects = JObject.Parse(jsonContent);


            if (resultObjects["reason"] != null)
            {
                throw new Exception(string.Format("Teamleader {0} API returned statuscode 400 Bad Request. Reason: {1}",
                    url, resultObjects["reason"]));
            }
            // in case no JSON could be parsed, log the response in the exception
            throw new Exception(
                string.Format("Teamleader {0} API returned statuscode 400 Bad Request. Data returned: {1}",
                    url, jsonContent));
        }


        return JsonConvert.DeserializeObject<T>(jsonContent); ;
    
     
    }


    }

 
}
