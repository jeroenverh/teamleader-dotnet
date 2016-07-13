using System.Collections.Generic;
using TeamleaderDotNet.Utils;

namespace TeamleaderDotNet.Crm
{
    public abstract class Entity
    {
        public List<KeyValuePair<string, string>> ToArrayForApi()
        {
            return new ApiArrayConvertor().ToArrayForApi(this);

        }
    }
}