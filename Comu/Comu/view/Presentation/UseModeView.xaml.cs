using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Comu.view.Presentation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UseModeView : ContentView
    {
        public UseModeView()
        {
            InitializeComponent();
        }
        private void GoToAppHome(object sender, EventArgs e)
        {
            Preferences.Set("IsNoRepiteInfo", true);
            Application.Current.MainPage = new NavigationPage(new YesOrNoView());
        }
    }
}