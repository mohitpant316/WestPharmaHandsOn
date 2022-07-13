using ProductCatalog.Services;
using ProductCatalog.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProductCatalog
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<ProductService>();
            DependencyService.Register<IToast>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
