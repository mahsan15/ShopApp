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
        public async Task<List<SearchProduct>> getSearchResults(string keywords)
        {
        
            string amazonapi = "https://api.countdownapi.com/request?api_key=8C1D5A761F1D4A78B659624BB1218953&type=search&ebay_domain=ebay.com&search_term=" + keywords;
            List<SearchProduct> list = new List<SearchProduct>();

            var response = await httpClient.GetAsync(amazonapi);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                
            }
            else
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
                if (!jsonString.Contains("\"success\":false"))
                {
                    var array = dic.ElementAt(3).Value;
                    list = JsonConvert.DeserializeObject<List<SearchProduct>>(array.ToString());
                }
                
      
            }

            string amazonapi2 = "https://api.rainforestapi.com/request?api_key=66B0E667B1524819B5025C371F6510C7&type=search&amazon_domain=amazon.com&search_term=" + keywords;

            var response2 = await httpClient.GetAsync(amazonapi2);
            if (response2.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return list;
            }
            else
            {
                try
                {
                    var jsonString = await response2.Content.ReadAsStringAsync();
                    var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
					//validation
					if (jsonString.Contains("\"success\":false")) {
                        return list;
                    }

					var array = dic.ElementAt(3).Value;
                    var finalList = JsonConvert.DeserializeObject<List<SearchProduct>>(array.ToString());
                    foreach (SearchProduct itm in finalList)
                    {
                        list.Add(itm);
                    }

                    list = list.OrderBy(o => o.price.value).ToList();
				}
				catch(Exception e) {
                    return list;
                }
                return list;
            }
        }


    }
}
