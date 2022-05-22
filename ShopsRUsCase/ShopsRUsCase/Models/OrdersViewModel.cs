using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopsRUsCase.Models
{
    public class OrdersViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
    }
}