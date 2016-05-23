using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<Department> GetDepartments()
        {
            return DoCall<List<Department>>("getDepartments.php", null);
        }

    }
}
