using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string name { get; set; }

        public virtual List<Product> products { get; set; }
        
    }
}