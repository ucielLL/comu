using System;
using System.Collections.Generic;
using System.Text;

namespace Comu.BaseVVM
{
    public class ContainerPage
    {
        internal Dictionary<Type, Type> Mappings;
        static Lazy<ContainerPage> LazyContainer = new Lazy<ContainerPage>(() => new ContainerPage());
        public static ContainerPage Current => LazyContainer.Value;

        public ContainerPage()
        {
            Mappings = new Dictionary<Type, Type>();
        }

        public void RegisterForNavigation<TViewModel, TView>()
           where TView : Xamarin.Forms.Page
           where TViewModel : BaseViewModel
        {
            Mappings.Add(typeof(TViewModel), typeof(TView));

        }
    }
}
