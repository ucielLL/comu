using Comu.BaseVVM;
using Comu.Models;
using Comu.Repository;
using Comu.view;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Comu.ViewModel
{
    internal class CollectionsViewModel : BaseViewModel
    {
        public CollectionsViewModel()
        {
            
            InitCollectionsAsync();
        }

        async void InitCollectionsAsync()
        {
            ListCollections = await CollectionDataRepository.GetInstance().GetCollectionsAsycn();

        }
        public ICommand CreateColleccionCommand => new Command(async () =>
        {
            var popup = new AddCollectionPopUp();
            popup.FinishCreateCollection = async () =>
            { ListCollections = await CollectionDataRepository.GetInstance().GetCollectionsAsycn(); };
            await PopupNavigation.Instance.PushAsync(popup);
        });
        public ICommand DeleteColleccionCommand => new Command(async (Object collection) =>
        {
            var name = collection.ToString();
            await CollectionDataRepository.GetInstance().DeleteCollectionAsync(name);
            ListCollections = await CollectionDataRepository.GetInstance().GetCollectionsAsycn();
        });

        public ICommand GoToCollectionCommad => new Command(async (collecction) =>
        {
            if (collecction != null)
            {
                var name = (collecction as Collections).NameCollection;
                if (String.IsNullOrEmpty(name)) return;
                await NavigationTo(new TheCollectionViewModel(), new NavigationParameters("CollectionName", name));
            }

        });

        public ICommand RefreshingCommand => new Command(async () => 
        {
                ListCollections = await CollectionDataRepository.GetInstance().GetCollectionsAsycn();
              
        });

        public ICommand Back => new Command(async () => 
        {
            await Navigation.PopAsync();
        });

        List<Collections> listcollections = new List<Collections>();
        public List<Collections> ListCollections
        {
            get { return listcollections; }
            set { SetProperty(ref listcollections, value);

            }
        }

       

    }
}
