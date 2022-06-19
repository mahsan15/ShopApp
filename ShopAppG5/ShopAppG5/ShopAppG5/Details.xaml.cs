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
            itmPrice.Text = item.price.symbol + item.price.value.ToString();
            itmDescription.Text = item.link;
        }

        async void moveToShoppingCart(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Shoppin_cart_Page());
        }
    }
}