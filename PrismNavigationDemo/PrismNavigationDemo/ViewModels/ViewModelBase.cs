using Prism.Mvvm;
using Prism.Navigation;

namespace PrismNavigationDemo.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        private string _title;

        protected INavigationService NavigationService { get; private set; }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
        }

        public virtual void Destroy()
        {
        }
    }
}
