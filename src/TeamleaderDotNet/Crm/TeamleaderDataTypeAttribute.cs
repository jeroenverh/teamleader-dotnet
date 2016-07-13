using System;

namespace TeamleaderDotNet.Crm
{
    public class TeamleaderDataTypeAttribute : Attribute
    {
        public string Name { get; set; }
        public string UpdateField { get; set; }
    }
}