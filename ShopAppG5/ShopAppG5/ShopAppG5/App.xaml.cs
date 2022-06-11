using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopAppG5
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new MainPage();
            //   MainPage = new Shoppin_cart_Page();
            // MainPage = new ResultsPage();
            //MainPage = new NavigationPage(new HomePage());
            
            MainPage = new NavigationPage(new HomePage());


        }

           

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
