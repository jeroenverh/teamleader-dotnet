using TeamleaderDotNet.Common;

namespace TeamleaderDotNet
{
    public class TeamleaderApi
    {
        private const string ApiUrl = "https://www.teamleader.be/api";
        private const string Version = "1.0.0";
        private const int DefaultTimeout = 30;

        private readonly ITeamleaderClient _teamleaderClient;
        private TeamleaderContactsApi _contactsApi;
        private TeamleaderCompaniesApi _companiesApi;
        private TeamleaderDealsApi _dealsApi;
        private TeamleaderCustomFieldsApi _customFieldsApi;
        private TeamleaderInvoicesApi _invoicesApi;
        private TeamleaderPlanningApi _planningApi;
        private TeamleaderTimetrackingApi _timetrackingApi;
        private TeamleaderUsersApi _usersApi;
        private TeamleaderGeneralApi _generalApi;
        private TeamleaderTicketsApi _ticketsApi;

        public TeamleaderApi(string apiGroup, string apiSecret)
        {
            _teamleaderClient = new TeamleaderClient(ApiUrl, apiGroup, apiSecret, GetUserAgent(), DefaultTimeout);
        }

        public TeamleaderApi(ITeamleaderClient teamleaderClient)
        {
            _teamleaderClient = teamleaderClient;
        }

        public TeamleaderGeneralApi General
        {
            get
            {
                if (_generalApi == null)
                {
                    _generalApi = new TeamleaderGeneralApi(_teamleaderClient);
                }
                return _generalApi;
            }
        }

        public TeamleaderInvoicesApi Invoices
        {
            get
            {
                if (_invoicesApi == null)
                {
                    _invoicesApi = new TeamleaderInvoicesApi(_teamleaderClient);
                }
                return _invoicesApi;
            }
        }

        public TeamleaderPlanningApi Planning
        {
            get
            {
                if (_planningApi == null)
                {
                    _planningApi = new TeamleaderPlanningApi(_teamleaderClient);
                }
                return _planningApi;
            }
        }

        public TeamleaderTimetrackingApi Timetracking
        {
            get
            {
                if (_timetrackingApi == null)
                {
                    _timetrackingApi = new TeamleaderTimetrackingApi(_teamleaderClient);
                }
                return _timetrackingApi;
            }
        }

        public TeamleaderUsersApi Users
        {
            get
            {
                if (_usersApi == null)
                {
                    _usersApi = new TeamleaderUsersApi(_teamleaderClient);
                }
                return _usersApi;
            }
        }

        public TeamleaderTicketsApi Tickets
        {
            get
            {
                if (_ticketsApi == null)
                {
                    _ticketsApi = new TeamleaderTicketsApi(_teamleaderClient);
                }
                return _ticketsApi;
            }
        }

        public TeamleaderContactsApi Contacts
        {
            get
            {
                if (_contactsApi == null)
                {
                    _contactsApi = new TeamleaderContactsApi(_teamleaderClient);
                }
                return _contactsApi;
            }
        }

        public TeamleaderCompaniesApi Companies
        {
            get
            {
                if (_companiesApi == null)
                {
                    _companiesApi = new TeamleaderCompaniesApi(_teamleaderClient);
                }
                return _companiesApi;
            }
        }

        public TeamleaderDealsApi Deals => _dealsApi ?? (_dealsApi = new TeamleaderDealsApi(_teamleaderClient));

        public TeamleaderCustomFieldsApi CustomFields
        {
            get
            {
                if (_customFieldsApi == null)
                {
                    _customFieldsApi = new TeamleaderCustomFieldsApi(_teamleaderClient);
                }
                return _customFieldsApi;
            }
        }

        public string GetUserAgent()
        {
            return string.Format("TeamleaderDotNet/{0}", Version);
        }
    }
}
