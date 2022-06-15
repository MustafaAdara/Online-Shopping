using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication12.Areas.Admin.Models
{
    public class AddItem
    {
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public float price { get; set; }
        public string description { get; set; }
    }
}