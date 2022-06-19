using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ShopAppG5
{
    public class SearchProduct
    {
        public int position { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public string image { get; set; }

        public Price price { get; set; }
        public SearchProduct() {
            position = 0;
            title = "";
            link = "";
            image = "";
        }
    }


    public class Price
    {
        public double value { get; set; }
        public string currency { get; set; }

        public string symbol { get; set; }

        public Price() { value = 0;
            currency = "USD";
            symbol = "$";
        }
        
    }



}
