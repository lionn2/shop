using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string login { get; set; }
        public string pass { get; set; }
        public int securityLevel { get; set; }
    }
}