using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamleaderDotNet.Users;

namespace TeamleaderDotNet.Tests.Planning
{
    [TestClass]
    public class GetPlanningTest
    {
        private MockTeamleaderClient _client;
        private TeamleaderApi _api;
        private User[] _users;

        [TestInitialize]
        public void Initialize()
        {
            _client = new MockTeamleaderClient();
            _client.LoadResultFromFile(@"Users\getUsers.txt");
            _api = new TeamleaderApi(_client);
            _users = _api.Users.GetUsers(true)
                .GetAwaiter().GetResult();
        }

        [TestMethod]
        public async Task GetPlannedTasks()
        {
            int userId = _users.First(x => x.Email == "test@example.com").Id;
            var results = await _api.Planning.GetPlannedTasks(new DateTime(2016, 8, 28), DateTime.Now, userId);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
        }

        [TestMethod]
        public async Task GetDaysOff()
        {
            var results = await _api.Planning.GetDaysOff(2016);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
        }

        [TestMethod]
        public async Task GetDaysOffByUser()
        {
            int userId = _users.First(x => x.Email == "test@example.com").Id;
            var results = await _api.Planning.GetDaysOffByUser(userId, 2016);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
        }
    }
}
