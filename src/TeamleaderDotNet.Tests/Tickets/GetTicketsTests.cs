using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamleaderDotNet.Tickets;

namespace TeamleaderDotNet.Tests.Tickets
{
    [TestClass]
    public class GetTicketsTests : TestBase
    {
        [TestMethod]
        public async Task GetTickets()
        {
            var results = await Client.Tickets.GetTickets(TicketStatusTypes.Closed);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
        }

        [TestMethod]
        public async Task GetTicket()
        {
            var result = await Client.Tickets.GetTicket(39764);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetTicketMessages()
        {
            var results = await Client.Tickets.GetTicketMessages(39764, true, true);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
        }

        [TestMethod]
        public async Task GetTicketMessage()
        {
            var result = await Client.Tickets.GetTicketMessage(136015);

            Assert.IsNotNull(result);
        }
    }
}
