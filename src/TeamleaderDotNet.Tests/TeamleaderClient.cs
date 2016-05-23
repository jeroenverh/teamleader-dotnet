using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TeamleaderDotNet.Common;

namespace TeamleaderDotNet.Tests
{
    public class MockTeamleaderClient : ITeamleaderClient
    {
      
        /// <summary>
        /// Client used to channel calls to Teamleader
        /// </summary>
        public async Task<string> DoCall(string endPoint, List<KeyValuePair<string, string>> fields)
        {
            _endPoint = endPoint;
            _fields = fields;

            return _callResult;
        }

        private string _callResult;
        private string _endPoint;
        private List<KeyValuePair<string, string>> _fields;

        public string GetParam(string key)
        {
            if (_fields == null || !_fields.Any()) return null;

            if (!_fields.Any(f => f.Key == key)) return null;

            if (_fields.Count(f => f.Key == key) != 1) throw new Exception("Field cannot occur multiple times");

            return _fields.Single(f => f.Key == key).Value;
        }

        public void SetResult(string result)
        {
            _callResult = result;
        }
        public void LoadResultFromFile(string path)
        {
            _callResult = System.IO.File.ReadAllText(@"Results\" + path);
        }
        public string GetEndpoint()
        {
            return _endPoint;
        }
        

        public string ApiGroup
        {
            get
            {
                return "MockApiGroup";
            } 
        }

        public string ApiSecret
        {
            get
            {
                return "MockApiSecret";
            }
        }


       
    }

 
}
