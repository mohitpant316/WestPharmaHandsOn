using ProductCatalog.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProductCatalog.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string productName;
        private string description;
        private string price;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {

            return !String.IsNullOrWhiteSpace(productName)
                && !String.IsNullOrWhiteSpace(description)
                && !string.IsNullOrWhiteSpace(Convert.ToString(price));
            
        }

        public string ProductName
        {
            get => productName;
            set => SetProperty(ref productName, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            var newItem = new Product()
            {
                name = productName,
                description = Description,
                net_price = Convert.ToSingle(price)
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
