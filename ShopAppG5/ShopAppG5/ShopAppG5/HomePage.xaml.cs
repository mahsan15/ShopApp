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

        async void moveToLogin(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
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
            await Navigation.PushAsync(new ResultsPage(qry));
        }
    }
}