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
    public partial class PresentationView : ContentPage
    {
        public PresentationView()
        {
            InitializeComponent();
            
        }
        protected override void OnAppearing()
        {
           
            base.OnAppearing();
            Init();
        }
        void Init() 
        {
            if(!Preferences.ContainsKey("IsNoRepiteInfo")) return;
            if (Preferences.Get("IsNoRepiteInfo", false)) 
            {
                Application.Current.MainPage = new NavigationPage(new YesOrNoView());
            }
        }
    }
}