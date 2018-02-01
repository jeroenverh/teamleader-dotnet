using System.Collections.Generic;
using System.Threading.Tasks;
using TeamleaderDotNet.Common;
using TeamleaderDotNet.Timetracking;

namespace TeamleaderDotNet
{
    public class TeamleaderTimetrackingApi : TeamleaderApiBase
    {
        public TeamleaderTimetrackingApi(ITeamleaderClient teamleaderClient)
            : base(teamleaderClient)
        { }

        public async Task<TimetrackingTaskListItem[]> GetTasks(int amount, int pageNumber, int[] selectedCustomFieldIds = null, int? userId = null)
        {
            var fields = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>(nameof(amount), amount.ToString()),
                new KeyValuePair<string, string>("pageno", pageNumber.ToString())
            };

            if (selectedCustomFieldIds != null)
            {
                fields.Add(new KeyValuePair<string, string>("selected_customfields", string.Join(",", selectedCustomFieldIds)));
            }

            if (userId != null)
            {
                fields.Add(new KeyValuePair<string, string>("user_id", userId.ToString()));
            }

            return await DoCall<TimetrackingTaskListItem[]>("getTasks.php", fields);
        }

        public async Task<TimetrackingTask> GetTask(int taskId)
        {
            var fields = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("task_id", taskId.ToString()),
            };

            return await DoCall<TimetrackingTask>("getTask.php", fields);
        }

        public async Task<TaskType[]> GetTaskTypes()
        {
            return await DoCall<TaskType[]>("getTaskTypes.php");
        }
    }
}
