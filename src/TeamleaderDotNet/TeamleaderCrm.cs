using System;
using System.Collections.Generic;
using TeamleaderDotNet.Crm;
using TeamleaderDotNet.Utils;

namespace TeamleaderDotNet
{
    public class TeamleaderCrm : Teamleader
    {
        public TeamleaderCrm(string apiGroup, string apiSecret) : base(apiGroup, apiSecret)
        {
        }

        /// <summary>
        ///     Search for contacts
        /// </summary>
        /// <param name="amount">The amount of contacts returned per request (1-100)</param>
        /// <param name="page">The current page (first page is 0)</param>
        /// <param name="searchBy">
        ///     A search string. Teamleader will try to match each part of the string to the forename, surname,
        ///     company name and email address.
        /// </param>
        /// <param name="modifiedSince">Teamleader will only return contacts that have been added or modified since that timestamp</param>
        /// <returns>An array of contacts matching the search results</returns>
        public Contact[] GetContacts(int amount = 100, int page = 0, string searchBy = null, DateTime? modifiedSince = null)
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

            if (modifiedSince.HasValue) {
                fields.Add(new KeyValuePair<string, string>("modifiedsince", modifiedSince.Value.ConvertToUnixTime().ToString()));
            }

            return DoCall<Contact[]>("getContacts.php", fields).Result;
        }


        /// <summary>
        ///     Fetches a contact's information
        /// </summary>
        /// <param name="id">The ID of the contact</param>
        /// <returns>A contact's details</returns>
        public Contact GetContact(int id)
        {
            return DoCall<Contact>("getContact.php", new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("contact_id", id.ToString())
            }).Result;
        }

        /// <summary>
        ///     Update a contact
        /// </summary>
        /// <param name="contact"></param>
        /// <param name="trackChanges">If true, all changes are logged and visible to users in the web-interface</param>
        /// <param name="tagsToAdd">
        ///     Pass one or more tags. Existing tags will be reused, other tags will be automatically created
        ///     for you and added to the contact
        /// </param>
        /// <param name="tagsToRemove">Pass one or more tags. These tags will be removed from the contact.</param>
        /// <returns></returns>
        public string UpdateContact(Contact contact, bool trackChanges = true, string[] tagsToAdd = null,
            string[] tagsToRemove = null)
        {
            // todo    find a way to update the tags as the api expects
            var fields = new List<KeyValuePair<string, string>>(contact.ToArrayForApi());

            fields.Add(new KeyValuePair<string, string>("contact_id", contact.Id.ToString()));
            fields.Add(new KeyValuePair<string, string>("track_changes", trackChanges ? "1" : "0"));

            return DoCall<string>("updateContact.php", fields).Result;
        }
    }
}
