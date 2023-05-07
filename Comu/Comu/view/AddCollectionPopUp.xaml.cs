using Comu.Models;
using Comu.Repository;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
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
    public partial class AddCollectionPopUp : PopupPage
    {
        public AddCollectionPopUp()
        {
            InitializeComponent();
        }

        private async void Button_CreateCollection(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EntNameCollectrion.Text))
            {
                await DisplayAlert("Error", "Es necesario definir un nombre", "Ok");
                return;
            }
            var collection = new Collections() { NameCollection = EntNameCollectrion.Text };
            await CollectionDataRepository.GetInstance().AddCollection(collection);
            FinishCreateCollection();
            await PopupNavigation.Instance.PopAsync(true);
        }

        public delegate void FinishTask();
        public FinishTask FinishCreateCollection;
    }
}