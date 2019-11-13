using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TshirtOrderApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TshirtOrderPage : ContentPage
    {
       
        public TshirtOrderPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var tshirtItem = new TshirtItem();

            BindingContext = tshirtItem;
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var TshirtItem = (TshirtItem)BindingContext;
            await App.Database.SaveItemAsync(TshirtItem);

            await Navigation.PushAsync(new OrderedTshirtPage());
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var TshirtItem = (TshirtItem)BindingContext;
            await App.Database.DeleteItemAsync(TshirtItem);

            await Navigation.PushAsync(new OrderedTshirtPage());

        }
    }
}