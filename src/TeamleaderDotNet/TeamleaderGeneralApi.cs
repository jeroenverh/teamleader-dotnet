using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamleaderDotNet.Common;
using TeamleaderDotNet.Crm;
using TeamleaderDotNet.CustomFields;
using TeamleaderDotNet.General;
using TeamleaderDotNet.Utils;

namespace TeamleaderDotNet
{
    public class TeamleaderGeneralApi : TeamleaderApiBase
    {
        public TeamleaderGeneralApi(ITeamleaderClient teamleaderClient)
            : base(teamleaderClient)
        {
        }

        /// <summary>
        /// Getting all departments
        /// </summary>
        /// <returns>A list of all departments</returns>
        public async Task<List<Department>> GetDepartments()
        {
            return await DoCall<List<Department>>("getDepartments.php", null);
        }

        public async Task<List<BookkeepingAccount>> GetBookkeepingAccounts(int departmentId)
        {
            return await DoCall<List<BookkeepingAccount>>("getBookkeepingAccounts.php", 
                    new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("sys_department_id", departmentId.ToString())
                    });
        }

    }
}
