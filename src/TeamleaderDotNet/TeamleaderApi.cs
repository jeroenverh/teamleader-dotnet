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

        public TeamleaderApi(string apiGroup, string apiSecret)
        {
            _teamleaderClient = new TeamleaderClient(ApiUrl, apiGroup, apiSecret, GetUserAgent(), DefaultTimeout);
        }

        public TeamleaderApi(ITeamleaderClient teamleaderClient)
        {
            _teamleaderClient = teamleaderClient;
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

        public string GetUserAgent()
        {
            return string.Format("TeamleaderDotNet/{0}", Version);
        }
    }
}
