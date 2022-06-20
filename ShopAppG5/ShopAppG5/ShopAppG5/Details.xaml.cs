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
    public partial class Details : ContentPage
    {
        SearchProduct item;
        public Details(SearchProduct itm)
        {
            InitializeComponent();

            item = itm;

            itmImgSource.Source = item.image;
            itmName.Text = item.title;
            if (itm.price.raw == "Unknown price")
            {
                itmPrice.Text = "No price info";
                cartButton.IsVisible = false;
            }
            else
            {
                itmPrice.Text = item.price.raw;
            }
            itmDescription.Text = item.link;
        }

        async void addToCart(System.Object sender, System.EventArgs e)
        {
            ShoppingCart cart = new ShoppingCart(item.title, item.link, item.image, item.price.raw);
            App.Database.SaveShoppingAsync(cart);
            await Navigation.PushAsync(new Shoppin_cart_Page());
        }
        async void moveToShoppingCart(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Shoppin_cart_Page());
        }
    }
}