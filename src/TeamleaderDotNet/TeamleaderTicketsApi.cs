using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using TeamleaderDotNet.Common;
using TeamleaderDotNet.Tickets;

namespace TeamleaderDotNet
{
    public class TeamleaderTicketsApi : TeamleaderApiBase
    {
        public TeamleaderTicketsApi(ITeamleaderClient teamleaderClient)
            : base(teamleaderClient)
        { }

        private string TicketStatusTypesToString(TicketStatusTypes statusType)
        {
            switch (statusType)
            {
                case TicketStatusTypes.New: return "new";
                case TicketStatusTypes.Open: return "open";
                case TicketStatusTypes.WaitingForClient: return "waiting_for_client";
                case TicketStatusTypes.EscalatedThirdParty: return "escalated_thirdparty";
                case TicketStatusTypes.NotClosed: return "not_closed";
                case TicketStatusTypes.Closed: return "closed";

                default:
                    throw new InvalidEnumArgumentException(nameof(statusType));
            }
        }

        public async Task<TicketListItem[]> GetTickets(TicketStatusTypes statusType, string contactOrCompany = null, int? contactOrCompanyId = null, bool? deepSearch = null, int? projectId = null)
        {
            string status = TicketStatusTypesToString(statusType);

            var fields = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("type", status)
            };

            // TODO: add optional params

            return await DoCall<TicketListItem[]>("getTickets.php", fields);
        }

        public async Task<Ticket> GetTicket(int ticketId, bool returnDetailedTimeTracking = false)
        {
            var fields = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("ticket_id", ticketId.ToString()),
                new KeyValuePair<string, string>("return_detailed_timetracking", returnDetailedTimeTracking ? "1" : "0")
            };

            return await DoCall<Ticket>("getTicket.php", fields);
        }

        public async Task<TicketMessageListItem[]> GetTicketMessages(int ticketId, bool includeInternalMessage, bool includeThirdPartyMessage)
        {
            var fields = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("ticket_id", ticketId.ToString()),
                new KeyValuePair<string, string>("include_internal_message", includeInternalMessage ? "1" : "0"),
                new KeyValuePair<string, string>("include_third_party_message", includeThirdPartyMessage ? "1" : "0")
            };

            return await DoCall<TicketMessageListItem[]>("getTicketMessages.php", fields);
        }

        public async Task<TicketMessage> GetTicketMessage(int messageId)
        {
            var fields = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("message_id", messageId.ToString())
            };

            return await DoCall<TicketMessage>("getTicketMessage.php", fields);
        }
    }
}
