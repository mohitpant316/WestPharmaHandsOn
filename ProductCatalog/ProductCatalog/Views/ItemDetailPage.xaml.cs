using ProductCatalog.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ProductCatalog.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}