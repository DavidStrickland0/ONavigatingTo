using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Prism.Navigation;

namespace PrismNavigationDemo.ViewModels
{
    public class ExistingFailedPageViewModel : ViewModelBase
    {
        private string _result = "Wait For It";
        public string Result
        {
            get => _result;
            set
            {
                SetProperty(ref _result, value);
            }
        }

        public ExistingFailedPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Existing Exception Page";
        }

        public  override async void OnNavigatingTo(NavigationParameters parameters)
        {

            await Task.Delay(1000); // simulate a network activity (data loading)
            throw new Exception("TaskFactoryStartNewSuccessPage OnNavigatingToAsync threw an exception");
        }
    }
}
