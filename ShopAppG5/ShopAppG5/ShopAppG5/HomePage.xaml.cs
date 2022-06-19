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
        List<string> apis = new List<string>();
        string selectedApi = "Amazon and eBay";
        public HomePage()
        {
            InitializeComponent();
            apis.Add("Amazon");
            apis.Add("eBay");
            apis.Add("Amazon and eBay");

            apiFilter.ItemsSource = apis;
        }

        void apiFilter_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            var picker = (Picker)sender;
            if (picker.SelectedIndex == 0)
            {
                selectedApi = "Amazon";
            }
            else if (picker.SelectedIndex == 1)
            {
                selectedApi = "eBay";
            }
            else
            {
                selectedApi = "Amazon and eBay";
            }
        }

        async void moveToLogin(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }


        async void moveToResult(System.Object sender, System.EventArgs e) {
            string search = ItemSearch.Text;
            string api = selectedApi;
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
            Query qry = new Query(search, api, lowBound, highBound);
            await Navigation.PushAsync(new ResultsPage(qry));
        }
    }
}