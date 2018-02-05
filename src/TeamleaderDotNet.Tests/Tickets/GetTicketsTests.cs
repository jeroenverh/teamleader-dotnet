using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamleaderDotNet.Tickets;

namespace TeamleaderDotNet.Tests.Tickets
{
    [TestClass]
    public class GetTicketsTests
    {
        [TestMethod]
        public async Task GetTickets()
        {
            var client = new MockTeamleaderClient();
            client.LoadResultFromFile(@"Tickets\getTickets.txt");

            var api = new TeamleaderApi(client);
            var results = await api.Tickets.GetTickets(TicketStatusTypes.Closed);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
        }

        [TestMethod]
        public async Task GetTicket()
        {
            var client = new MockTeamleaderClient();
            client.LoadResultFromFile(@"Tickets\getTicket.txt");

            var api = new TeamleaderApi(client);
            var result = await api.Tickets.GetTicket(54321);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetTicketMessages()
        {
            var client = new MockTeamleaderClient();
            client.LoadResultFromFile(@"Tickets\getTicketMessages.txt");

            var api = new TeamleaderApi(client);
            var results = await api.Tickets.GetTicketMessages(54321, true, true);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
        }

        [TestMethod]
        public async Task GetTicketMessage()
        {
            var client = new MockTeamleaderClient();
            client.LoadResultFromFile(@"Tickets\getTicketMessage.txt");

            var api = new TeamleaderApi(client);
            var result = await api.Tickets.GetTicketMessage(123456);

            Assert.IsNotNull(result);
        }
    }
}
