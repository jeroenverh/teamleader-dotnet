using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamleaderDotNet.Utils;

namespace TeamleaderDotNet.Tests.CompaniesApi
{
    [TestClass]
    public class GetCompanyTests
    {
        [TestMethod]
        public async void When_we_get_a_company_we_should_send_a_correct_request()
        {
            var tlMockClient = new MockTeamleaderClient();
            tlMockClient.LoadResultFromFile(@"CrmCompanies\getCompany.txt");

            var tlApi = new TeamleaderApi(tlMockClient);

            var company = await tlApi.Companies.GetCompany(123);

            Assert.AreEqual(tlMockClient.ApiGroup, tlMockClient.GetParam("api_group"));
            Assert.AreEqual(tlMockClient.ApiSecret, tlMockClient.GetParam("api_secret"));
            Assert.AreEqual("123", tlMockClient.GetParam("company_id"));

        }


        [TestMethod]
        public async void When_we_get_a_company_all_fields_should_map_correctly()
        {
            var tlMockClient = new MockTeamleaderClient();
            tlMockClient.LoadResultFromFile(@"CrmCompanies\getCompany.txt");

            var tlApi = new TeamleaderApi(tlMockClient);
            var company = await tlApi.Companies.GetCompany(123);

            Assert.AreEqual(2916166, company.Id);
            Assert.AreEqual("Teamleader", company.name);
            Assert.AreEqual("Visserij", company.street);
            Assert.AreEqual("43P", company.number);
            Assert.AreEqual("9000", company.zipcode);
            Assert.AreEqual("Gent", company.city);
            Assert.AreEqual("BE 0899.623.035", company.taxcode);
            Assert.AreEqual("kvkNr", company.kvk_nummer);
            Assert.AreEqual("info@teamleader.be", company.email);
            Assert.AreEqual("http://www.teamleader.be", company.website);
            Assert.AreEqual("BE", company.country);
            Assert.AreEqual("+32 9 298 06 32", company.telephone);
            Assert.AreEqual("faxNr", company.fax);
            Assert.AreEqual("ibanNr", company.iban);
            Assert.AreEqual("bicNr", company.bic);
            Assert.AreEqual("14498", company.pricelist_id);
            Assert.AreEqual("-1", company.account_manager_id);
            Assert.AreEqual("1451392101".UnixTimeToDateTime(), company.DateAdded);
            Assert.AreEqual("EN", company.language);
            Assert.AreEqual("NV", company.business_type);
            Assert.AreEqual("unknown", company.vat_liability);
            Assert.AreEqual("undefined", company.payment_term);

            Assert.AreEqual("<p>test</p>", company.background_info_html);
            Assert.AreEqual(false, company.deleted);


            //"tags":[56775]
            //"extra_addresses":{"invoicing_address":{"address_name":"Teamleader 2","street":"Visserij","number":"2","zipcode":"9000","city":"Gent","country":"BE"}}
            //custom_fields":[]}

        }

    }
}
