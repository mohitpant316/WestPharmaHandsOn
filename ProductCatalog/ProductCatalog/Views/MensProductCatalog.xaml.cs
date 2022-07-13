using ProductCatalog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProductCatalog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MensProductCatalog : ContentPage
    {
        ItemsViewModel _viewModel;
        public MensProductCatalog()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
            _viewModel.LoadItemsCommand.Execute(null);
        }
    }
}