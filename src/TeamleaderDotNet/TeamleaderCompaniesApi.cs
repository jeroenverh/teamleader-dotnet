using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamleaderDotNet.Common;
using TeamleaderDotNet.Crm;
using TeamleaderDotNet.Utils;

namespace TeamleaderDotNet
{
    public class TeamleaderCompaniesApi : TeamleaderApiBase
    {
        public TeamleaderCompaniesApi(ITeamleaderClient teamleaderClient)
            : base(teamleaderClient)
        {
        }


        //TODO:
        //Adding a company to TeamleaderApiBase
        //Updating company information
        //Searching TeamleaderApiBase companies
        //Getting all possible business types for a country



        /// <summary>
        /// Adds a company to TeamleaderApiBase
        /// </summary>
        /// <returns>The TeamleaderApiBase ID of the newly created company</returns>
        public async Task<int> AddCompany(Company company, bool automergeByName, bool automergeByEmail, bool automergeByVatCode, string[] addTagByString, List<KeyValuePair<string, string>> customFields)
        {
            var fields = new List<KeyValuePair<string, string>>(company.ToArrayForApi());

            fields.Add(new KeyValuePair<string, string>("automerge_by_name", automergeByName ? "1" : "0"));
            fields.Add(new KeyValuePair<string, string>("automerge_by_email", automergeByEmail ? "1" : "0"));
            fields.Add(new KeyValuePair<string, string>("automerge_by_vat_code", automergeByVatCode ? "1" : "0"));

            if (addTagByString != null && addTagByString.Any())
                fields.Add(new KeyValuePair<string, string>("add_tag_by_string", string.Join(",", addTagByString)));

            if (customFields != null && customFields.Any())
            {
                foreach (var customField in customFields)
                {
                    fields.Add(new KeyValuePair<string, string>(string.Format("custom_field_{0}", customField.Key), customField.Value));
                }
            }
                



            var companyId =  await DoCall<string>("addCompany.php", fields);

            return int.Parse(companyId);
        }

        /// <summary>
        /// Fetches the information of a specific company
        /// </summary>
        /// <param name="id">The ID of the company</param>
        /// <returns>The detailed information of the company</returns>
        public async Task<Company> GetCompany(int id)
        {
            return await DoCall<Company>("getCompany.php", new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("company_id", id.ToString())
            });  
        }

        /// <summary>
        /// Deletes a company
        /// </summary>
        /// <param name="id">The ID of the company</param>
        public async void DeleteCompany(int id)
        {
            await DoCall<Contact>("deleteCompany.php", new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("company_id", id.ToString())
            });
        }

    }
}
