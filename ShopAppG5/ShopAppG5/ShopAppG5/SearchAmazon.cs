using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ShopAppG5
{
    [Table("ShoppingCart")]
    public class SearchProduct
    {
        [PrimaryKey,AutoIncrement]
        public int key { get; set; }
        [Ignore]
        public int position { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public string image { get; set; }
        public string colour { get; set; }
        [OneToMany]
        public Price price { get; set; }
        public SearchProduct() {
            position = 0;
            title = "";
            link = "";
            image = "";
            price = new Price();
            colour = "white";

        }

        //for testing
        public SearchProduct(int let)
        {
            position = 1;
            title = "Test Item";
            link = "https://www.amazon.com/Acer-A515-46-R3UB-Display-Quad-Core-Processor/dp/B09HVC79PC/ref=sr_1_1?crid=3TX5F9KP3UMZT&keywords=laptop&qid=1655655306&sprefix=lap%2Caps%2C220&sr=8-1";
            image = "https://m.media-amazon.com/images/I/7189iXimfWL._AC_SX679_.jpg";
            price = new Price();
            if (link.Contains("amazon.com"))
            {
                colour = "blue";

            }
            else if (link.Contains("ebay.com"))
            {
                colour = "red";
            }
            else
            {
                colour = "white";
            }
        }
    }

    [Table("Prices")]
    public class Price
    {
        [PrimaryKey]
        public double value { get; set; }

        public string raw { get; set; }
        public string currency { get; set; }

        public string symbol { get; set; }

        public Price() { value = -1;
            //raw = "Unknown price"; uncomment this line in final version of app
            raw = "999 $";
            currency = "USD";
            symbol = "$";
        }
        
    }



}
