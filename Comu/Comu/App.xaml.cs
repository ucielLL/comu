using Comu.BaseVVM;
using Comu.view;
using Comu.view.Presentation;
using Comu.ViewModel;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Comu
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Build();
           
            MainPage = new NavigationPage(new PresentationView());
        }
        private void Build() 
        {
            ContainerPage.Current.RegisterForNavigation<CollectionsViewModel, CollectionsView>();
            ContainerPage.Current.RegisterForNavigation<TheCollectionViewModel, TheCollectionView>();
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
