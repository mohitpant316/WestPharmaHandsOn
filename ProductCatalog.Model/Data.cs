using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProductCatalog.Models
{
    public class Product
    {
       
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public Image[] images { get; set; }
        public float net_price { get; set; }
        public string taxes { get; set; }
        public string price { get; set; }
        public string[] categories { get; set; }
        public string[] tags { get; set; }

       
    }

}

