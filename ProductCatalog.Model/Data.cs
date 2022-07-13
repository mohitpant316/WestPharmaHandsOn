using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProductCatalog.Models
{
    public class Product : INotifyPropertyChanged
    {
        public Image[] _images;
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public Image[] images { get => _images; set { _images = value; OnPropertyChanged("images"); } }
        public float net_price { get; set; }
        public string taxes { get; set; }
        public string price { get; set; }
        public string[] categories { get; set; }
        public string[] tags { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

