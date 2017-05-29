using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamleaderDotNet.Common;

namespace TeamleaderDotNet.Tests
{
    [TestClass]
    public class ThrottlerTests
    {
        [TestMethod]
        public void ExecuteShould()
        {
            var executedTasks = 0;
            var startTime = DateTime.Now;
            for (int i = 0; i < 7; i++)
            {
                executedTasks = Throttler.ExecuteTask(() => executedTasks+1);
            }
            Assert.IsTrue(executedTasks == 7);
            Assert.IsTrue(DateTime.Now> startTime.Add(TimeSpan.FromSeconds(25)));
        }
    }
}
