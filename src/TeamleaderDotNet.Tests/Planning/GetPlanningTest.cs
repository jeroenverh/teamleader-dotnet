using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamleaderDotNet.Tests.Planning
{
    [TestClass]
    public class GetPlanningTest : TestBase
    {
        [TestMethod]
        public async Task GetPlannedTasks()
        {
            int userId = Users.First(x => x.Email == "arne.moerman@orbitus.be").Id;
            var results = await Client.Planning.GetPlannedTasks(new DateTime(2016, 8, 28), DateTime.Now, userId);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
        }

        [TestMethod]
        public async Task GetDaysOff()
        {
            var results = await Client.Planning.GetDaysOff(2016);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
        }

        [TestMethod]
        public async Task GetDaysOffByUser()
        {
            int userId = Users.First(x => x.Email == "jeroen.decuyper@orbitus.be").Id;
            var results = await Client.Planning.GetDaysOffByUser(userId, 2016);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
        }
    }
}
