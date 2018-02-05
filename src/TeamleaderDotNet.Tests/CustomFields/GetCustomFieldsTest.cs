using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamleaderDotNet.Tests.CustomFields
{
    [TestClass]
    public class GetCustomFieldsTest
    {
        [TestMethod]
        public async Task GetCustomFields()
        {
            var client = new MockTeamleaderClient();
            client.LoadResultFromFile(@"CustomFields\getCustomFields.txt");

            var api = new TeamleaderApi(client);
            var results = await api.CustomFields.GetCustomFields("todo");

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
        }
    }
}
