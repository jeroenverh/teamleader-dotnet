using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;
using TeamleaderDotNet.Common;
using TeamleaderDotNet.Crm;
using TeamleaderDotNet.CustomFields;
using TeamleaderDotNet.Utils;

namespace TeamleaderDotNet
{
    public class TeamleaderCustomFieldsApi : TeamleaderApiBase
    {
        public TeamleaderCustomFieldsApi(ITeamleaderClient teamleaderClient)
            : base(teamleaderClient)
        {
        }

        /// <summary>
        /// Getting all custom fields for one object type
        /// </summary>
        /// <param name="objectType">The type of object: contact, company, sale, project, invoice, ticket, milestone</param>
        /// <returns>A list of all custom fields for the requested object type</returns>
        public async Task<List<CustomField>> GetCustomFields(string objectType)
        {
            return await DoCall<List<CustomField>>("getCustomFields.php", new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("for", objectType)
            });
        }
        /// <summary>
        /// Getting the extra info of a custom field from cache or via api call to Teamleader
        /// </summary>
        /// <param name="customFieldId">The CustomField ID</param>
        /// <returns></returns>
        public async Task<CustomFieldInfo> GetCustomFieldInfo(int customFieldId)
        {
            var cacheKey = "customfield_" + customFieldId;
            var cache = MemoryCache.Default;
            var customFieldInfo = cache[cacheKey] as CustomFieldInfo;
            if (customFieldInfo == null)
            {
                customFieldInfo = await DoCall<CustomFieldInfo>("getCustomFieldInfo.php", new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("custom_field_id", customFieldId.ToString())
                });
                cache.Add(cacheKey, customFieldInfo, new CacheItemPolicy(){SlidingExpiration = TimeSpan.FromHours(1)});
            }
            return customFieldInfo;
        }

    }
}
