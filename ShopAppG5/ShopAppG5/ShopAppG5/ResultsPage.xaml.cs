using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopAppG5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsPage : ContentPage
    {
        NetworkAmazon networkAmazon = new NetworkAmazon();

        public Query query { get; set; }

        List<SearchAmazon> list;

        public class Item
        {
            public string title { get; set; }
            public int price { get; set; }
            public string detail { get; set; }
            public string imageURL { get; set; }
            public Item(string ti, int pr, string det, string img)
            {
                title = ti;
                price = pr;
                detail = "Price: " + price + " \n" + det;
                imageURL = img;

            }
        }

        Collection<Item> itemsResult = new Collection<Item>
        {
           new Item("Product1", 300, "Product description goes here", "https://free-images.com/sm/9cb8/sunset_sundown_da_nang.jpg"),
           new Item("Product2", 60, "Product description goes here", "https://free-images.com/sm/2b9d/bird_wildlife_sky_clouds.jpg"),
           new Item("Product3", 900, "Product description goes here", "https://free-images.com/sm/86a4/aroma_aromatic_beverage_bio.jpg"),
           new Item("Product4", 37, "Product description goes here", "https://free-images.com/sm/4432/hand_key_house_keys.jpg"),
           new Item("Product5", 12, "Product description goes here", "https://free-images.com/sm/4138/artistic_conception_green_689793.jpg")
        };
        public ResultsPage()
        {
            InitializeComponent();
            
        }
        public ResultsPage(Query qry)
        {
            InitializeComponent();
            query = qry;

        }
        override async protected void OnAppearing()
        {
           list = await networkAmazon.getSearchResults(query.searchLine);
            if (list.Count > 0)
            {
                IEnumerable<SearchAmazon> qryResult = list.Where(itm => itm.price.value > query.priceLowerBound && itm.price.value < query.priceHigherBound);
                
                if (qryResult.Count() > 0)
                {
                    list = qryResult.ToList();
                    itemList.ItemsSource = list;
                }
				else{
                    queryResult.Text = "No results found";
                }
            }
            
        }
        async void moveToDetails(System.Object sender, System.EventArgs e)
        {
            var itmObj = itemList.SelectedItem;
            SearchAmazon item = (SearchAmazon) itmObj;

            await Navigation.PushAsync(new Details(item));
        }

        async void moveToShoppingCart(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Shoppin_cart_Page());
        }
    }
}