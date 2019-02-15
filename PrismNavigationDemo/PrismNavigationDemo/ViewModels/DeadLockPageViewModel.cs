using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Prism.Navigation;

namespace PrismNavigationDemo.ViewModels
{
    public class DeadLockPageViewModel : ViewModelBase
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

        public DeadLockPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Failed Page";
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);

            Result = SimulateFailedNetworkcall().Result;


        }


        public async Task<string> SimulateFailedNetworkcall()
        {
            await Task.Delay(1000); // simulate a network activity (data loading)
            throw new Exception("Hello from Dave's async Method.");
        }
    }
}
