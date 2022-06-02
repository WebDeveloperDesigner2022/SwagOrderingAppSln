using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SwagOrderingApp.Models;

namespace SwagOrderingApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwagItemHistory : ContentPage
    {

        public List<SwagItem> SwagItems { get; set; }

        public SwagItemHistory()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            SwagDatabase database = await SwagDatabase.Instance;
            SwagItems = await database.GetItemsAsync();

            BindingContext = this;

        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage
            {
                BindingContext = new SwagItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new MainPage
                {
                    BindingContext = e.SelectedItem as SwagItem
                });
            }
        }
    }
}