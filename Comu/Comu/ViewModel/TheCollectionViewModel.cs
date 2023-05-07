using Comu.BaseVVM;
using Comu.Helpers;
using Comu.Models;
using Comu.Repository;
using Comu.view;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Comu.ViewModel
{
     class TheCollectionViewModel: BaseViewModel
    {
        public TheCollectionViewModel()
        {
            viewAddImag = false;
            ImageSourseAdd = "Addimage.png";
            CardVisible = true;
            DesciptionOfNewCard = String.Empty;
        }
        public override async Task InitializeAsync(NavigationParameters parameters = null)
        {
            await base.InitializeAsync(parameters);
            if(parameters == null)return;
            this.CollectionName = parameters.GetValue<string>("CollectionName");
            InitCollection(this.CollectionName);

        }
        async void InitCollection(string collectionName) 
        {
            ListCard = await CardRepostory.GetInstance().GetCards(collectionName);
        }

        public async void showAddImg(View view) 
        {
            CardVisible = false;
            uint duracion = 500;
            await Task.WhenAll(
                view.TranslateTo(0,0 , duracion + 200, Easing.CubicIn)  
                );
            viewAddImag = true;
        }
        public async void AddNewCard(View view)
        {
           
            if (imageSourseAdd == "Addimage.png") 
            {
                await DisplayAlert("Error", "Es necesario agregar una imagen", "Ok");
            }
            else 
            {
                var card = new CardData()
                {
                    Collection = CollectionName,
                    pahtImage = ImageSourseAdd,
                    Description = DesciptionOfNewCard ?? " "

                };
                await CardRepostory.GetInstance().AddCardAsync(card);
                ListCard = await CardRepostory.GetInstance().GetCards(CollectionName);
            }

            await Task.WhenAll(
                view.TranslateTo(0, -400, 700, Easing.CubicIn)
                );
            DesciptionOfNewCard = String.Empty;
            ImageSourseAdd = "Addimage.png";
            viewAddImag = false;
            CardVisible = true;
        }
        public ICommand AddImgCommand => new Command(async () =>
        {
            var path = await ImageMedia.GetInstance().SearchImage();
            if (String.IsNullOrEmpty(path)) 
            {
                await DisplayAlert("Error", "Error al seleccionar la imagen", "Ok");
                return;
            }
            ImageSourseAdd = path;
        });
        public ICommand Back => new Command(async () =>
        {
            await Navigation.PopAsync();
        });

        private string collectionName = " ";
        public string CollectionName
        {
            get { return collectionName; }
            set
            {
                SetProperty(ref collectionName, value);
            }
        }
        private bool viewAddImag;
        public bool ViewAddImag 
        {
            get { return viewAddImag; }
            set { SetProperty(ref viewAddImag, value); }
        }
        private bool cardVisible;
        public bool CardVisible 
        {
            get { return cardVisible; } 
            set { SetProperty(ref cardVisible, value); }
        }
        private string imageSourseAdd;
        public string ImageSourseAdd 
        {
            get { return imageSourseAdd; }
            set { SetProperty(ref imageSourseAdd, value); }
        }

        private string desciptionOfNewCard;
        public string DesciptionOfNewCard 
        {
            get { return desciptionOfNewCard; }
            set { SetProperty(ref desciptionOfNewCard, value); }
        }


        List<CardData> listCard = new List<CardData>();   
        public List<CardData> ListCard { 
            get { return listCard; } 
            set { SetProperty(ref listCard, value); }
        } 


    }
}
