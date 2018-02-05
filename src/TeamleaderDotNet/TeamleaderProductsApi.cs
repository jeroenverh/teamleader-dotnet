using System.Collections.Generic;
using System.Threading.Tasks;
using TeamleaderDotNet.Common;
using TeamleaderDotNet.Products;

namespace TeamleaderDotNet
{
    public class TeamleaderProductsApi : TeamleaderApiBase
    {
        public TeamleaderProductsApi(ITeamleaderClient teamleaderClient)
            : base(teamleaderClient)
        {
        }

        /// <summary>
        /// Get all products from teamleader.
        /// </summary>
        /// <returns>A list of maximum 100 products from teamleader</returns>
        public async Task<List<Product>> GetProducts()
        {
            return await DoCall<List<Product>>("getProducts.php", new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("amount", "100"),
                new KeyValuePair<string, string>("pageno", "0")
            });  
        }
    }
}
