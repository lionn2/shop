using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Product
    {
        public int productID { get; set; }
        public string name { get; set; }
        public int price { get; set; }

        public virtual Category category { get; set; }
        public virtual Maker maker { get; set; }
    }
}