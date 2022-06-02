using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SwagOrderingApp.Models;

namespace SwagOrderingApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //var order = new SwagItemHistory();
            BindingContext = new SwagItem(); 
        }

        private async  void Button_Add(object sender, EventArgs e)
        {
            var swagItem = (SwagItem)BindingContext;
            SwagDatabase database = await SwagDatabase.Instance;
            await database.SaveItemAsync(swagItem);
            await Navigation.PopAsync();
        }
        private async void Button_Delete(object sender, EventArgs e)
        {
            var swagItem = (SwagItem)BindingContext;
            SwagDatabase database = await SwagDatabase.Instance;
            await database.DeleteItemAsync(swagItem);
            await Navigation.PopAsync();
        }

        private async void History_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SwagItemHistory());
        }
    }
}
