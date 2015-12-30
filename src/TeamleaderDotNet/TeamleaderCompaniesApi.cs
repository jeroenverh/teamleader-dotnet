using System;
using System.Collections.Generic;
using System.Linq;
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
        public int AddCompany(Company company, bool automerge_by_name, bool automerge_by_email, bool automerge_by_vat_code, string[] add_tag_by_string)
        {
            var fields = new List<KeyValuePair<string, string>>(company.ToArrayForApi());

            fields.Add(new KeyValuePair<string, string>("automerge_by_name", automerge_by_name ? "1" : "0"));
            fields.Add(new KeyValuePair<string, string>("automerge_by_email", automerge_by_email ? "1" : "0"));
            fields.Add(new KeyValuePair<string, string>("automerge_by_vat_code", automerge_by_vat_code ? "1" : "0"));

            if (add_tag_by_string != null && add_tag_by_string.Any())
                fields.Add(new KeyValuePair<string, string>("add_tag_by_string", string.Join(",", add_tag_by_string)));

            var companyId =  DoCall<string>("addCompany.php", fields);

            return int.Parse(companyId);
        }

        /// <summary>
        /// Fetches the information of a specific company
        /// </summary>
        /// <param name="id">The ID of the company</param>
        /// <returns>The detailed information of the company</returns>
        public Company GetCompany(int id)
        {
            return DoCall<Company>("getCompany.php", new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("company_id", id.ToString())
            });  
        }

        /// <summary>
        /// Deletes a company
        /// </summary>
        /// <param name="id">The ID of the company</param>
        public void DeleteCompany(int id)
        {
            DoCall<Contact>("deleteCompany.php", new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("company_id", id.ToString())
            });
        }

    }
}
