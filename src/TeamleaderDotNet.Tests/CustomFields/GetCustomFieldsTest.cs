using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamleaderDotNet.Tests.CustomFields
{
    [TestClass]
    public class GetCustomFieldsTest : TestBase
    {
        [TestMethod]
        public async Task GetCustomFields()
        {
            var results = await Client.CustomFields.GetCustomFields("todo");

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
        }
    }
}
