using ShopsRUsCase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopsRUsCase.Models
{
    public class GeneralDBContext : DbContext
    {
        public GeneralDBContext() : base("name=MyConnectionString") { }

        public DbSet<Personel> personels { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<Customers> customers { get; set; }
        public DbSet<Products> products { get; set; }
    }
}