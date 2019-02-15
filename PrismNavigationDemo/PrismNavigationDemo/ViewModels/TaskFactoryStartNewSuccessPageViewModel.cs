using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Prism.Navigation;

namespace PrismNavigationDemo.ViewModels
{
    public class TaskFactoryStartNewSuccessPageViewModel : ViewModelBase
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

        public TaskFactoryStartNewSuccessPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Task Factory Success Page";
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);


            var taskTest = Task.Factory.StartNew(
                async () => await OnNavigatingToAsync(), 
                CancellationToken.None, 
                TaskCreationOptions.None, 
                TaskScheduler.Default
            ).Unwrap();
            taskTest.Wait();
        }


        public async Task OnNavigatingToAsync()
        {
            await Task.Delay(1000); // simulate a network activity (data loading)
            Result = "Worked But Blocked the UI Thread to Do It";

        }
    }
}
