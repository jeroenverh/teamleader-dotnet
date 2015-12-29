using System.Collections.Generic;
using TeamleaderDotNet.Crm;

namespace TeamleaderDotNet.Utils
{
    public class ApiArrayConvertor
    {
        public List<KeyValuePair<string, string>> ToArrayForApi(object o)
        {
            var r = new List<KeyValuePair<string, string>>();

            var properties = o.GetType().GetProperties();


            foreach (var prop in properties)
            {
                var attrs = prop.GetCustomAttributes(true);
                foreach (var attr in attrs)
                {
                    var authAttr = attr as TeamleaderDataTypeAttribute;
                    if (authAttr != null)
                    {
                        var propName = prop.Name;
                        var auth = authAttr.Name;

                        r.Add(new KeyValuePair<string, string>(auth, prop.GetValue(o).ToString()));
                    }
                }
            }

            return r;
        }
    }
}
