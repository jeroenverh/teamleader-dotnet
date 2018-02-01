using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamleaderDotNet.Tests.TimetrackingApi
{
    [TestClass]
    public class GetTasksTest : TestBase
    {
        [TestMethod]
        public async Task GetTasks()
        {
            var results = await Client.Timetracking.GetTasks(3, 0);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
        }

        [TestMethod]
        public async Task GetTask()
        {
            var result = await Client.Timetracking.GetTask(2461696);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetTaskTypes()
        {
            var results = await Client.Timetracking.GetTaskTypes();

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
        }
    }
}
