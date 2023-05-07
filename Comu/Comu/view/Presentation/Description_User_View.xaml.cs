using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Comu.view.Presentation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Description_User_View : ContentView
    {
        public Description_User_View()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new LoginView());
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
           // Application.Current.MainPage = new NavigationPage(new YesOrNoView());
        }
    }
}