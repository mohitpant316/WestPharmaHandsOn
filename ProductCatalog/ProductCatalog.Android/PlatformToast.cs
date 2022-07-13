using ProductCatalog.Services;
using Android.Widget;
using Xamarin.Essentials;
using System.Runtime.CompilerServices;
using ProductCatalog.Droid;


namespace ProductCatalog.Droid
{
    public class PlatformToast : IToast
    {
        public void MakeToast(string message)
        {
            Toast.MakeText(Platform.AppContext, message, ToastLength.Long).Show();
        }
    }


}