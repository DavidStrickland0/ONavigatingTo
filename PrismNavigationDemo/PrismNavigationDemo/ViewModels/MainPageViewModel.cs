using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Navigation;
using Xamarin.Forms;

namespace PrismNavigationDemo.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ICommand NavigateToExistingFailedPageCommand { get; }
        public ICommand NavigateToExistingSuccessPageCommand { get; }

        public ICommand NavigateToTaskFactoryStartNewFailedPageCommand { get; }
        public ICommand NavigateToTaskFactoryStartNewSuccessPageCommand { get; }

        public ICommand NavigateToDeadLockPageCommand { get; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";

            NavigateToTaskFactoryStartNewFailedPageCommand = new Command(async () => await NavigateToTaskFactoryStartNewFailedPage());
            NavigateToTaskFactoryStartNewSuccessPageCommand = new Command(async () => await NavigateToTaskFactoryStartNewSuccessPage());
            NavigateToExistingFailedPageCommand = new Command(async () => await NavigateToExistingFailedPage());
            NavigateToExistingSuccessPageCommand = new Command(async () => await NavigateToExistingSuccessPage());


            NavigateToDeadLockPageCommand = new Command(async () => await NavigateToDeadLockPageAsync());
        }
        private async Task NavigateToDeadLockPageAsync()
        {
            try
            {
                await NavigationService.NavigateAsync("DeadLockPage");
            }
            catch (Exception e)
            {
                NavigateToPageCommandResult = e.Message;
            }
        }
        private async Task NavigateToTaskFactoryStartNewFailedPage()
        {
            try
            {
                await NavigationService.NavigateAsync("TaskFactoryStartNewFailedPage");
            }
            catch (Exception e)
            {
                NavigateToPageCommandResult =e.Message;
            }
        }

        private async Task NavigateToTaskFactoryStartNewSuccessPage()
        {
            try
            {
                await NavigationService.NavigateAsync("TaskFactoryStartNewSuccessPage");
            }
            catch (Exception e)
            {
                NavigateToPageCommandResult = e.Message;
            }
        }

        private async Task NavigateToExistingFailedPage()
        {
            try
            {
                await NavigationService.NavigateAsync("ExistingFailedPage");
            }
            catch (Exception e)
            {
                NavigateToPageCommandResult = e.Message;
            }
        }

        private async Task NavigateToExistingSuccessPage()
        {
            try
            {
                await NavigationService.NavigateAsync("ExistingSuccessPage");
            }
            catch (Exception e)
            {
                NavigateToPageCommandResult = e.Message;
            }
        }

        private string _navigateToPageCommandResult = "Not yet executed";
        public string NavigateToPageCommandResult
        {
            get => _navigateToPageCommandResult;
            set
            {
                SetProperty(ref _navigateToPageCommandResult, value);
            }
        } 
    }
}
