using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAppG5
{
    public class NetworkAmazon
    {
        HttpClient httpClient = new HttpClient();
        //Task<List<SearchAmazon>
        public async Task<List<SearchAmazon>> getSearchResults(string keywords)
        {
            string amazonapi = "https://api.rainforestapi.com/request?api_key=780E6F45A029446B9F26A94D85541AEC&type=search&amazon_domain=amazon.com&search_term=" + keywords;

            var response = await httpClient.GetAsync(amazonapi);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<SearchAmazon>();
            }
            else
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
                var array = dic.ElementAt(3).Value;
                var finalList = JsonConvert.DeserializeObject<List<SearchAmazon>>(array.ToString());
                return finalList;
            }
        }
    }
}
