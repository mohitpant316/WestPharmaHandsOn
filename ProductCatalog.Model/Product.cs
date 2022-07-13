using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Models
{
    public class ResponseObject
    {
        public string status { get; set; }
        public int code { get; set; }
        public int total { get; set; }
        public Product[] data { get; set; }
    }
}

