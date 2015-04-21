using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TeamleaderDotNet.Crm;

namespace TeamleaderDotNet
{
    public class TeamleaderCrm : Teamleader
    {
        const string ApiUrl = "https://www.teamleader.be/api";
        const string Version = "1.0.0";
   

        public TeamleaderCrm(string apiGroup, string apiSecret) : base(apiGroup, apiSecret)
        {
        }








            public string helloWorld()
            {
                return DoCall<string>("helloWorld.php").Result;
            }


            /**
     * Search for contacts
     *
     * @param int $amount The amount of contacts returned per
     *                                   request (1-100)
     * @param int         $page     The current page (first page is 0)
     * @param string|null $searchBy A search string. Teamleader will try
     *                                   to match each part of the string to
     *                                   the forename, surname, company name
     *                                   and email address.
     * @param int|null $modifiedSince Teamleader will only return contacts
     *                                   that have been added or modified
     *                                   since that timestamp.
     * @return array of Contact
     */
    public Contact[] crmGetContacts(int amount = 100, int page = 0, string searchBy = null, int? modifiedSince = null)
    {
        var fields = new List<KeyValuePair<string, string>>();

        fields.Add(new KeyValuePair<string, string>("amount", amount.ToString()));
        fields.Add(new KeyValuePair<string, string>("pageno", page.ToString()));

        if (!string.IsNullOrWhiteSpace(searchBy)) {
            fields.Add(new KeyValuePair<string, string>("searchby", searchBy.ToString()));
        }
        //if (modifiedSince.HasValue) {
        //    $fields['modifiedsince'] = (int) $modifiedSince;
        //}

        return DoCall<Contact[]>("getContacts.php", fields).Result;

    }

            public Contact crmGetContact(int Id)
            {
                return DoCall<Contact>("getContact.php", new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("contact_id", Id.ToString())
                }).Result;
            }


        public string crmUpdateContact(Contact contact, bool trackChanges = true, string[] tagsToAdd = null, string[] tagsToRemove = null)
        {
            var fields = new List<KeyValuePair<string, string>>(contact.toArrayForApi());
            
            fields.Add(new KeyValuePair<string, string>("contact_id", contact.Id.ToString()));
            fields.Add(new KeyValuePair<string, string>("track_changes", trackChanges ? "1" : "0"));
            
            return DoCall<string>("updateContact.php", fields).Result;
        }


            /**
     * Update a contact
     *
     * @todo    find a way to update the tags as the api expects
     *
     * @param Contact    $contact
     * @param bool       $trackChanges If true, all changes are logged and
     *                                  visible to users in the web-interface.
     * @param null|array $tagsToAdd Pass one or more tags. Existing tags
     *                                  will be reused, other tags will be
     *                                  automatically created for you and added
     *                                  to the contact.
     * @param null|array $tagsToRemove Pass one or more tags. These tags will
     *                                  be removed from the contact.
     * @return bool
     */
    //public function crmUpdateContact(
    //    Contact $contact,
    //    $trackChanges = true,
    //    array $tagsToAdd = null,
    //    array $tagsToRemove = null
    //) {
    //    $fields = $contact->toArrayForApi();
    //    $fields['contact_id'] = $contact->getId();
    //    $fields['track_changes'] = ($trackChanges) ? 1 : 0;
    //    if ($tagsToAdd) {
    //        $fields['add_tag_by_string'] = implode(',', $tagsToAdd);
    //    }
    //    if ($tagsToRemove) {
    //        $fields['remove_tag_by_string'] = implode(',', $tagsToRemove);
    //    }

    //    $rawData = $this->doCall('updateContact.php', $fields);

    //    return ($rawData == 'OK');
    //}





            /**
    // * Fetch information about a contact
    // *
    // * @param  int     $id The ID of the contact
    // * @return Contact
    // */
    //public function crmGetContact($id)
    //{
    //    $fields = array();
    //    $fields['contact_id'] = (int) $id;

    //    $rawData = $this->doCall('getContact.php', $fields);

    //    // validate response
    //    if (!is_array($rawData)) {
    //        throw new Exception($rawData);
    //    }

    //    return Contact::initializeWithRawData($rawData);
    //}




    }

 
}
