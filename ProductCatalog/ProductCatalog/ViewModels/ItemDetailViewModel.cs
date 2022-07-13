using ProductCatalog.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace ProductCatalog.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private int itemId;
        private string text;
        private string description;
        private string image;
        private float price;
        private string[] tags;
        public ICommand Delete => new Command(OnDeleteAsync);

        private Product item;

        public int Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public string Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }

        public float Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }
      
        public string[] Tags
        {
            get => tags;
            set => SetProperty(ref tags, value);
        }
        public async void LoadItemId(int itemId)
        {
            try
            {
                item = await DataStore.GetItemAsync(itemId);
                Id = item.id;
                Text = item.name;
                Description = item.description;
                Image = item.image;
                Price = Convert.ToSingle(item.net_price);
                Tags = item.tags;
            }
            catch (Exception)
            {
                Toast.MakeToast("Failed to Load Item");
            }
        }

        private async void OnDeleteAsync(object obj)
        {
            await DataStore.DeleteItemAsync(item.id);
            await Shell.Current.GoToAsync("..");
            Toast.MakeToast("Item deleted");
        }
    }
}
