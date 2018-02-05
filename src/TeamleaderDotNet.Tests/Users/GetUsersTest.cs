using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamleaderDotNet.Tests.Users
{
    [TestClass]
    public class GetUsersTest
    {
        private MockTeamleaderClient _client;

        [TestInitialize]
        public void Initialize()
        {
            _client = new MockTeamleaderClient();
            _client.LoadResultFromFile(@"Users\getUsers.txt");
        }

        [TestMethod]
        public async Task GetUsers()
        {
            var api = new TeamleaderApi(_client);
            var results = await api.Users.GetUsers();

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
        }
    }
}
