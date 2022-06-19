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
    public partial class Shoppin_cart_Page : ContentPage
    {
        public Shoppin_cart_Page()
        {
            InitializeComponent();
        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();
            List<SearchProduct> shoppingCart = await App.Database.GetProductAsync();
            shoppingCartList.ItemsSource = shoppingCart;
        }

        async void deleteItem_Clicked(System.Object sender, System.EventArgs e)
        {
            MenuItem item = (sender as MenuItem);
            SearchProduct toDelete = item.CommandParameter as SearchProduct;
            await App.Database.DeleteProductAsync(toDelete);

            shoppingCartList.ItemsSource = null;

            List<SearchProduct> shoppingCart = await App.Database.GetProductAsync();
            shoppingCartList.ItemsSource = shoppingCart;
        }
    }
}