using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using TeamleaderDotNet.Common;
using TeamleaderDotNet.Planning;

namespace TeamleaderDotNet
{
    public class TeamleaderPlanningApi : TeamleaderApiBase
    {
        public TeamleaderPlanningApi(ITeamleaderClient teamleaderClient)
            : base(teamleaderClient)
        { }

        public async Task<PlanningTask[]> GetPlannedTasks(DateTime dateFrom, DateTime dateTo, int? userId = null, int? projectId = null)
        {
            var fields = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("date_from", dateFrom.ToString(CultureInfo.InvariantCulture)),
                new KeyValuePair<string, string>("date_to", dateTo.ToString(CultureInfo.InvariantCulture))
            };

            if (userId != null)
            {
                fields.Add(new KeyValuePair<string, string>("user_id", userId.ToString()));
            }

            if (projectId != null)
            {
                fields.Add(new KeyValuePair<string, string>("project_id", projectId.ToString()));
            }

            return await DoCall<PlanningTask[]>("getPlannedTasks.php", fields);
        }

        public async Task<DayOff[]> GetDaysOff(int year)
        {
            var fields = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>(nameof(year), year.ToString())
            };

            return await DoCall<DayOff[]>("getDaysOff.php", fields);
        }

        public async Task<DayOffByUser[]> GetDaysOffByUser(int userId, int year)
        {
            var fields = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_id", userId.ToString()),
                new KeyValuePair<string, string>(nameof(year), year.ToString())
            };

            return await DoCall<DayOffByUser[]>("getDaysOffByUser.php", fields);
        }
    }
}
