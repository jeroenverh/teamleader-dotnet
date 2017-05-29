using System.Collections.Generic;
using System.Threading.Tasks;
using TeamleaderDotNet.Common;
using TeamleaderDotNet.Deals;

namespace TeamleaderDotNet
{
    public class TeamleaderDealsApi : TeamleaderApiBase
    {
        public TeamleaderDealsApi(ITeamleaderClient teamleaderClient)
            : base(teamleaderClient)
        {
        }

        /// <summary>
        /// Fetches the information of a specific deal with customfields os jsonobject
        /// </summary>
        /// <param name="id">The ID of the deal</param>
        /// <returns>The detailed information of the deal</returns>
        public async Task<Deal> GetDeal(int id)
        {
            return await DoCall<Deal>("getDeal.php", new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("deal_id", id.ToString())
            });  
        }
    }
}
