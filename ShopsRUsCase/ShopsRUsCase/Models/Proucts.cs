using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopsRUsCase.Models
{
    public class Products
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int StockAmount { get; set; }
        public bool IsShoppingCentre { get; set; }
    }
}