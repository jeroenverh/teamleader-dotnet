using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamleaderDotNet.Tests.TimetrackingApi
{
    [TestClass]
    public class GetTasksTest
    {
        [TestMethod]
        public async Task GetTasks()
        {
            var client = new MockTeamleaderClient();
            client.LoadResultFromFile(@"Tasks\getTasks.txt");

            var api = new TeamleaderApi(client);
            var results = await api.Timetracking.GetTasks(3, 0);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
        }

        [TestMethod]
        public async Task GetTask()
        {
            var client = new MockTeamleaderClient();
            client.LoadResultFromFile(@"Tasks\getTask.txt");

            var api = new TeamleaderApi(client);
            var result = await api.Timetracking.GetTask(1234567);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetTaskTypes()
        {
            var client = new MockTeamleaderClient();
            client.LoadResultFromFile(@"Tasks\getTaskTypes.txt");

            var api = new TeamleaderApi(client);
            var results = await api.Timetracking.GetTaskTypes();

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
        }
    }
}
