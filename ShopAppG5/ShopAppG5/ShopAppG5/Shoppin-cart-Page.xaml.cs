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
            List<ShoppingCart> shoppingCart = await App.Database.GetShoppingAsync();
            shoppingCartList.ItemsSource = shoppingCart;
            double total = 0;
            foreach (var val in shoppingCart)
			{
                if (!string.IsNullOrEmpty(val.price))
                {
                    string tempstr = val.price.Remove(0,1);
                    total += double.Parse(tempstr);
                }
			}
            shoppingCartTotal.Text = "Total: " + total + "$";
        }

        async void deleteItem_Clicked(System.Object sender, System.EventArgs e)
        {
            MenuItem item = (sender as MenuItem);
            ShoppingCart toDelete = item.CommandParameter as ShoppingCart;
            await App.Database.DeleteShoppingAsync(toDelete);

            shoppingCartList.ItemsSource = null;

            List<ShoppingCart> shoppingCart = await App.Database.GetShoppingAsync();
            shoppingCartList.ItemsSource = shoppingCart;

            double total = 0;
            foreach (var val in shoppingCart)
            {
                string tempstr = val.price.Remove(0);
                total += double.Parse(tempstr);
            }
            shoppingCartTotal.Text = "Total: " + total + "$";
        }

        //async void moveToDetails(System.Object sender, System.EventArgs e)
        //{
        //    var itmObj = shoppingCartList.SelectedItem;
        //    SearchProduct item = (SearchProduct) itmObj;

        //    await Navigation.PushAsync(new Details(item));
        //}
    }
}