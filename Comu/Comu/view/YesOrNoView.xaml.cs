using Comu.BaseVVM;
using Comu.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Comu.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YesOrNoView : ContentPage
    {
        public YesOrNoView()
        {
            InitializeComponent();
           BindingContext = new YesOrNoViewM();
            ((BaseViewModel)BindingContext).InitializeAsync(Navigation);

        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Accelerometer.Stop();
        }
    }
}