using System.Collections.Generic;
using System.Threading.Tasks;
using TeamleaderDotNet.Common;
using TeamleaderDotNet.Users;

namespace TeamleaderDotNet
{
    public class TeamleaderUsersApi : TeamleaderApiBase
    {
        public TeamleaderUsersApi(ITeamleaderClient teamleaderClient)
            : base(teamleaderClient)
        { }

        public async Task<User[]> GetUsers(bool showInactiveUsers = false)
        {
            var fields = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("show_inactive_users", showInactiveUsers ? "1" : "0")
            };

            return await DoCall<User[]>("getUsers.php", fields);
        }
    }
}
