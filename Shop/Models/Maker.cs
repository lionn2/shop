using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Maker
    {
        public int MakerID { get; set; }
        public string name { get; set; }
        public virtual List<Product> products { get; set; }
    }
}