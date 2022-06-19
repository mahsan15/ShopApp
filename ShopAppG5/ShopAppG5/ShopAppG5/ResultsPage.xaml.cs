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

        List<SearchProduct> list;
        List<SearchProduct> elist;

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

            if (query.priceHigherBound == int.MaxValue && query.priceLowerBound == 0)
            {
                filteredOption.Text = "Price range: Any price";
            }
            else if (query.priceHigherBound == int.MaxValue && query.priceLowerBound != 0)
            {
                filteredOption.Text = "Price range: " + query.priceLowerBound + "and above $";
            }
            else
            {
                filteredOption.Text = "Price range: from " + query.priceLowerBound + " to " + query.priceHigherBound + "$";
            }

            //for test
            list.Add(new SearchProduct(1));
            if (list.Count > 0)
            {
                IEnumerable<SearchProduct> qryResult = list.Where(itm => (itm.price.value == -1) || (itm.price.value > query.priceLowerBound && itm.price.value < query.priceHigherBound));



                if (qryResult.Count() > 0)
                {
                    list = qryResult.ToList();
                    itemList.ItemsSource = list;


                    itemList.IsVisible = true;
                    queryResult.IsVisible = false;

                }
				else{
                    itemList.IsVisible = false;
                    queryResult.IsVisible = true;
                    queryResult.Text = "No results found in your price range";
                }
            }
            else
            {
                itemList.IsVisible = false;
                queryResult.IsVisible = true;
                queryResult.Text = "No results found for this item name";

            }



        }
        async void moveToDetails(System.Object sender, System.EventArgs e)
        {
            var itmObj = itemList.SelectedItem;
            SearchProduct item = (SearchProduct) itmObj;

            await Navigation.PushAsync(new Details(item));
        }

        async void moveToShoppingCart(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Shoppin_cart_Page());
        }
    }
}