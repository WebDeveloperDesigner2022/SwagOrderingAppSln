using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SwagOrderingApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwagHomePage : ContentPage
    {
        public SwagHomePage()
        {
            InitializeComponent();

            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(1200);
            await Navigation.PushAsync(new MainPage());
        }
    }
}