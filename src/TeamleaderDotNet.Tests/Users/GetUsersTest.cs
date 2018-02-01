using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamleaderDotNet.Tests.Users
{
    [TestClass]
    public class GetUsersTest : TestBase
    {
        [TestMethod]
        public async Task GetUsers()
        {
            var results = await Client.Users.GetUsers();

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
        }
    }
}
