using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Comu.BaseVVM
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnpropertyChanged([CallerMemberName] string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);

            return true;
        }
        public void InitializeAsync(INavigation navigation)
        {
            Navigation = navigation;
        }
        public virtual Task InitializeAsync(NavigationParameters parameters = null)
        {
            return Task.FromResult(false);
        }

        public async void NavigateTo(Page page)
        {
            await Navigation.PushAsync(page);
        }

        public async Task NavigationTo(BaseViewModel viewmodel, NavigationParameters parameters = null)
        {
            var type = viewmodel.GetType();
            if (!ContainerPage.Current.Mappings.ContainsKey(type))
            {
                throw new KeyNotFoundException($"No map for ${type} was found on navigation mappings");

            }
            var typepage = ContainerPage.Current.Mappings[type];
            Page page = Activator.CreateInstance(typepage) as Page;
            page.BindingContext = viewmodel;
            ((BaseViewModel)page.BindingContext).InitializeAsync(page.Navigation);
            await ((BaseViewModel)page.BindingContext).InitializeAsync(parameters);
           
            await Navigation.PushAsync(page);
        }
        #region properties

        private ImageSource foto;
        public ImageSource Foto
        {
            get { return foto; }
            set
            {
                foto = value;
                OnpropertyChanged();
            }
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                SetProperty(ref _title, value);
            }
        }
        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                SetProperty(ref _isBusy, value);
            }
        }

        #endregion


    }
}
