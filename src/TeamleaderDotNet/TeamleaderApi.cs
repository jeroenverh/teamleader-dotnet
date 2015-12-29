using System;
using System.Collections.Generic;
using System.Linq;
using TeamleaderDotNet.Crm;
using TeamleaderDotNet.Utils;

namespace TeamleaderDotNet
{
    public class TeamleaderApi
    {
        private readonly string _apiGroup;
        private readonly string _apiSecret;

        public TeamleaderApi(string apiGroup, string apiSecret)
        {
            _apiGroup = apiGroup;
            _apiSecret = apiSecret;
        }

        private TeamleaderContactsApi _contactsApi;
        private TeamleaderCompaniesApi _companiesApi;

        public TeamleaderContactsApi Contacts
        {
            get
            {
                if (_contactsApi == null)
                {
                    _contactsApi = new TeamleaderContactsApi(_apiGroup, _apiSecret);
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
                    _companiesApi = new TeamleaderCompaniesApi(_apiGroup, _apiSecret);
                }
                return _companiesApi;
            }
        }
    }
}
