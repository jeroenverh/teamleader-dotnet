using System.Collections.Generic;

namespace TeamleaderDotNet.Crm
{
    public class Contact
    {
        public int Id { get; set; }

        public string Forename { get; set; }
        
        public string Surname { get; set; }
        
        public string Email { get; set; }
        
        public string Telephone { get; set; }
        
        public string Gsm { get; set; }

        public string Fax { get; set; }
        
        public string Website { get; set; }
        
        public string Street { get; set; }
        
        public string Number { get; set; }

        public string Zipcode { get; set; }
        
        public string City { get; set; }
        
        public string Country { get; set; }

        public string[] ExtraAddresses { get; set; }

        public string Language { get; set; }

        public string Gender { get; set; }
        
        public int Dob { get; set; }

        public string Iban { get; set; }
        
        public string Bic { get; set; }
        
        public int DateAdded { get; set; }
        
        public int DateEdited { get; set; }

        public bool Deleted { get; set; }

        public string Status { get; set; }

        public string[] CustomFields { get; set; }

        public string[] LinkedCompanyIds { get; set; }

        public string[] Tags { get; set; }




        /**
     * This method will convert a contact to an array that can be used for an
     * API-request
     *
     * @return array
     */
    public  List<KeyValuePair<string, string>> ToArrayForApi()
    {
        var r = new List<KeyValuePair<string, string>>();

        if(!string.IsNullOrWhiteSpace(Forename))
            r.Add(new KeyValuePair<string, string>("forename", Forename));

        if(!string.IsNullOrWhiteSpace(Surname))
            r.Add(new KeyValuePair<string, string>("surname", Surname));

        //TODO: Verder uitwerken van ToArrayForApi
        //if ($this->getEmail()) {
        //    $return['email'] = $this->getEmail();
        //}
        //if ($this->getTelephone()) {
        //    $return['telephone'] = $this->getTelephone();
        //}
        //if ($this->getCountry()) {
        //    $return['country'] = $this->getCountry();
        //}
        //if ($this->getZipcode()) {
        //    $return['zipcode'] = $this->getZipcode();
        //}
        //if ($this->getCity()) {
        //    $return['city'] = $this->getCity();
        //}
        //if ($this->getStreet()) {
        //    $return['street'] = $this->getStreet();
        //}
        //if ($this->getNumber()) {
        //    $return['number'] = $this->getNumber();
        //}
        //if ($this->getLanguage()) {
        //    $return['language'] = $this->getLanguage();
        //}
        //if ($this->getGender()) {
        //    $return['gender'] = $this->getGender();
        //}
        //if ($this->getDob()) {
        //    $return['dob'] = $this->getDob();
        //}
        //if ($this->getLinkedCompanyIds()) {
        //    $return['linked_company_ids'] = implode(',', $this->getLinkedCompanyIds());
        //}
        //if ($this->getTags()) {
        //    $return['add_tag_by_string'] = implode(',', $this->getTags());
        //}
        //if ($this->getCustomFields()) {
        //    foreach ($this->getCustomFields() as $fieldID => $fieldValue) {
        //        $return['custom_field_' . $fieldID] = $fieldValue;
        //    }
        //}
        return r;
    }

    }
}
