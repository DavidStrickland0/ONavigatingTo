using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Prism.Navigation;

namespace PrismNavigationDemo.ViewModels
{
    public class ExistingSuccessPageViewModel : ViewModelBase
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

        public ExistingSuccessPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Existing Success Page";
        }

        public override async void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);

            await Task.Delay(10000); // simulate a network activity (data loading)
            Result = "ExistingSuccessPageViewModel Got its Data";

        }
    }
}
