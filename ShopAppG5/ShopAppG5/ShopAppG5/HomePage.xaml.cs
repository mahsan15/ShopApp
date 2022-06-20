using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopAppG5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();
            List<Query> query = await App.Database.GetQueryAsync();
            queryList.ItemsSource = query;
        }

        async void deleteItem_Clicked(System.Object sender, System.EventArgs e)
        {
            MenuItem item = (sender as MenuItem);
            Query toDelete = item.CommandParameter as Query;
            await App.Database.DeleteQueryAsync(toDelete);

            queryList.ItemsSource = null;

            List<Query> queries = await App.Database.GetQueryAsync();
            queryList.ItemsSource = queries;
        }

        async void moveToLogin(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        async void moveToShoppingCart(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Shoppin_cart_Page());
        }

        async void moveToQueryResult(System.Object sender, System.EventArgs e)
        {
            var itemObj = queryList.SelectedItem;
            Query item = (Query)itemObj;
            await Navigation.PushAsync(new ResultsPage(item));
        }
        async void moveToResult(System.Object sender, System.EventArgs e) {
            string search = ItemSearch.Text;
            int lowBound = 0;
            int highBound = int.MaxValue;
            if (!(String.IsNullOrEmpty(lowestBound.Text)))
            {
                lowBound = Int32.Parse(lowestBound.Text);
                if (lowBound < 0)
				{
                    lowBound = 0;
                }
            }
            if (!(String.IsNullOrEmpty(highestBound.Text)))
			{
                highBound = Int32.Parse(highestBound.Text);


                if (highBound < 0)
                {
                    highBound = int.MaxValue;
                }
            }

            Query qry = new Query(search, lowBound, highBound);
            App.Database.SaveQueryAsync(qry);
            await Navigation.PushAsync(new ResultsPage(qry));
        }
    }
}