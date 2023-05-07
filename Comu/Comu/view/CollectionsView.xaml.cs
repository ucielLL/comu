using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Comu.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CollectionsView : ContentPage
    {
        public CollectionsView()
        {
            InitializeComponent();
            collection.FadeTo(0, 10);
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await collection.FadeTo(1, 1000);
        }

    }
}