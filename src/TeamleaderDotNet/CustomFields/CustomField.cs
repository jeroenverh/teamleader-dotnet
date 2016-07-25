using System;
using Newtonsoft.Json;
using TeamleaderDotNet.Common.JsonConvertors;
using TeamleaderDotNet.Crm;

namespace TeamleaderDotNet.CustomFields
{
    public class CustomField : Entity
    {
        public int Id { get; set; }

        [TeamleaderDataType(Name = "name")]
        public string name { get; set; }

        [TeamleaderDataType(Name = "type")]
        public string type { get; set; }
    }
}
