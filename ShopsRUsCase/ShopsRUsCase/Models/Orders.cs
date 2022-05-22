using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopsRUsCase.Models
{
    public class Orders
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int? PersonelID { get; set; }
        public DateTime OrdersDate { get; set; }
    }
}