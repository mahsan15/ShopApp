using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopAppG5
{
    public partial class App : Application
    {
        static Database database;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database();
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new ResultsPage());
            //MainPage = new MainPage();
             // MainPage = new Shoppin_cart_Page();
            // MainPage = new ResultsPage();
             MainPage = new NavigationPage(new HomePage());
           // MainPage = new Details();
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
