using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamleaderDotNet.Common;
using TeamleaderDotNet.Crm;
using TeamleaderDotNet.Utils;

namespace TeamleaderDotNet
{
    public class TeamleaderContactsApi : TeamleaderApiBase
    {
        public TeamleaderContactsApi(ITeamleaderClient teamleaderClient)
            : base(teamleaderClient)
        {
        }

        //TODO:
        //Adding a contact to TeamleaderApiBase
        //Updating contact information
        //Deleting a contact
        //Getting all contacts related to a company
        //Getting all relationships between contacts and companies


        public async Task<int> AddContact(Contact contact, bool newsletter, bool automerge_by_name, bool automerge_by_email, string[] add_tag_by_string, List<KeyValuePair<string, string>> customFields)
        {
            var fields = new List<KeyValuePair<string, string>>(contact.ToArrayForApi());

            fields.Add(new KeyValuePair<string, string>("automerge_by_name", automerge_by_name ? "1" : "0"));
            fields.Add(new KeyValuePair<string, string>("automerge_by_email", automerge_by_email ? "1" : "0"));
            fields.Add(new KeyValuePair<string, string>("newsletter", newsletter ? "1" : "0"));

            if (add_tag_by_string != null && add_tag_by_string.Any())
                fields.Add(new KeyValuePair<string, string>("add_tag_by_string", string.Join(",", add_tag_by_string)));

            if (customFields != null && customFields.Any())
            {
                foreach (var customField in customFields)
                {
                    fields.Add(new KeyValuePair<string, string>(string.Format("custom_field_{0}", customField.Key), customField.Value));
                }
            }

            var contactId = await DoCall<string>("addContact.php", fields);

            return int.Parse(contactId);
        }

        /// <summary>
        /// Fetches a contact's information
        /// </summary>
        /// <param name="id">The ID of the contact</param>
        /// <returns>A contact's details</returns>
        public async Task<Contact> GetContact(int id)
        {
            return await DoCall<Contact>("getContact.php", new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("contact_id", id.ToString())
            });
        }

        /// <summary>
        /// Links a contact to a company
        /// </summary>
        /// <param name="contactId">ID of the contact</param>
        /// <param name="companyId">ID of the company</param>
        /// <param name="function">the job title the contact holds at the company (eg: HR manager)</param>
        public async void AddContactToCompany(int contactId, int companyId, string function)
        {
            await DoCall<bool>("linkContactToCompany.php", new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("contact_id", contactId.ToString()),
                new KeyValuePair<string, string>("company_id", companyId.ToString()),
                new KeyValuePair<string, string>("mode", "link"),
                new KeyValuePair<string, string>("function", function)
            });
        }

        /// <summary>
        /// Unlinks a contact from a company
        /// </summary>
        /// <param name="contactId">ID of the contact</param>
        /// <param name="companyId">ID of the company</param>
        public async void RemoveContactFromCompany(int contactId, int companyId)
        {
            await DoCall<Contact>("linkContactToCompany.php", new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("contact_id", contactId.ToString()),
                new KeyValuePair<string, string>("company_id", companyId.ToString()),
                new KeyValuePair<string, string>("mode", "unlink")
            });
        }

        /// <summary>
        ///  Search for contacts
        /// </summary>
        /// <param name="amount">The amount of contacts returned per request (1-100)</param>
        /// <param name="page">The current page (first page is 0)</param>
        /// <param name="searchBy">A search string. TeamleaderApiBase will try to match each part of the string to the forename, surname, company name and email address.</param>
        /// <param name="modifiedSince">TeamleaderApiBase will only return contacts that have been added or modified since that timestamp</param>
        /// <returns>An array of contacts matching the search results</returns>
        public async Task<Contact[]> GetContacts(int amount = 100, int page = 0, string searchBy = null, DateTime? modifiedSince = null)
        {
            var fields = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("amount", amount.ToString()),
                new KeyValuePair<string, string>("pageno", page.ToString())
            };

            if (!string.IsNullOrWhiteSpace(searchBy))
            {
                fields.Add(new KeyValuePair<string, string>("searchby", searchBy));
            }

            if (modifiedSince.HasValue)
            {
                fields.Add(new KeyValuePair<string, string>("modifiedsince", modifiedSince.Value.ConvertToUnixTime().ToString()));
            }

            return await DoCall<Contact[]>("getContacts.php", fields);
        }

        /// <summary>
        /// Deletes a contact
        /// </summary>
        /// <param name="id">The ID of the contact</param>
        public async void DeleteContact(int id)
        {
            await DoCall<Contact>("deleteContact.php", new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("contact_id", id.ToString())
            });
        }

   
    }
}
