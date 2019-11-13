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
    public partial class OrderedTshirtPage : ContentPage
    {
        public List<TshirtItem> OrderedTshirts { get; set; }
        public OrderedTshirtPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            OrderedTshirts = await App.Database.GetItemsAsync();

            BindingContext = this;
        }

        private async void itemView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TshirtOrderPage
                {
                   BindingContext = e.SelectedItem as TshirtItem
                });
            }
        }

        private async void addItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TshirtOrderPage
            {
                BindingContext = new TshirtItem()
            });

        }
    }
}