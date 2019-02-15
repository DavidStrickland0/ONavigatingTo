using Prism;
using Prism.AppModel;
using Prism.Behaviors;
using Prism.Common;
using Prism.DryIoc;
using Prism.Events;
using Prism.Ioc;
using Prism.Logging;
using Prism.Modularity;
using Prism.Navigation;
using Prism.Services;
using PrismNavigationDemo.ViewModels;
using PrismNavigationDemo.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DependencyService = Xamarin.Forms.DependencyService;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PrismNavigationDemo
{
    public partial class App:PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();

            containerRegistry.RegisterForNavigation<TaskFactoryStartNewSuccessPage, TaskFactoryStartNewSuccessPageViewModel>();
            containerRegistry.RegisterForNavigation<TaskFactoryStartNewFailedPage, TaskFactoryStartNewFailedPageViewModel>();

            containerRegistry.RegisterForNavigation<ExistingSuccessPage, ExistingSuccessPageViewModel>();
            containerRegistry.RegisterForNavigation<ExistingFailedPage, ExistingFailedPageViewModel>();


            containerRegistry.RegisterForNavigation<DeadLockPage, DeadLockPageViewModel>();
        }


    }
}
