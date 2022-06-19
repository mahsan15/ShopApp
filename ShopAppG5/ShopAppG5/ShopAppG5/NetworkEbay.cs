using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopAppG5
{
    public class NetworkEbay
    {
        HttpClient httpClient = new HttpClient();

        public async Task<List<SearchEbay>> getSearchResults(string keywords)
        {
            string ebayapi = "https://api.countdownapi.com/request?api_key=8C167945C255424A9CC80CBECDFB4C4B&type=search&ebay_domain=ebay.ca&search_term= " + keywords;

            var response = await httpClient.GetAsync(ebayapi);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<SearchEbay>();
            }
            else
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
                var array = dic.ElementAt(3).Value;
                var finalList = JsonConvert.DeserializeObject<List<SearchEbay>>(array.ToString());
                return finalList;
            }
        }
    }
}
