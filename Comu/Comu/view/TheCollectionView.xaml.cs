using Comu.Helpers;
using Comu.ViewModel;
using Plugin.Media.Abstractions;
using Plugin.Media;
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
    public partial class TheCollectionView : ContentPage
    {
        public TheCollectionView()
        {
            InitializeComponent();
            PAddImg.TranslationY = -400;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            ((TheCollectionViewModel)BindingContext).showAddImg(PAddImg);
           

        }

        private void AddCrd_Clicked(object sender, EventArgs e)
        {
            ((TheCollectionViewModel)BindingContext).AddNewCard(PAddImg);
           
        }
    }
}