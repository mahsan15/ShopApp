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

            


            PriceFilter.Items.Add("Less than $10");
            PriceFilter.Items.Add("$10 - $25");
            PriceFilter.Items.Add("$25 - $50");
            PriceFilter.Items.Add("$50 - $100");
            PriceFilter.Items.Add("$100 - $250");
            PriceFilter.Items.Add("$250 - $500");
            PriceFilter.Items.Add("$500 - $1,000");
            PriceFilter.Items.Add("More than $1,000");
        }

        async void moveToLogin(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());

            //await Navigation.PushAsync(new MainPage());
        }

        async void moveToDetails(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Details());

            
        }

    }
}