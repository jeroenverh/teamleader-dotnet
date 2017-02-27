using System;
using System.Collections.Generic;
using System.Linq;
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



    }
}
