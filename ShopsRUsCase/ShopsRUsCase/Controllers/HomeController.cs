using ShopsRUsCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ShopsRUs.Controllers
{
    public class HomeController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Home/Index")]
        //Route'a ek olarak ?type=json yazdığımızda json çıktısı alabiliyoruz
        public JsonResult Index()
        {
            var endViewModelList = new List<OrdersViewModel>();
            var viewModelList = new List<OrdersViewModel>();
            var context = new GeneralDBContext();
            var customers = context.customers
   .Where(p => p.ID == 3)
   .FirstOrDefault();


            var orders = new Orders { CustomerID = customers.ID, OrdersDate = DateTime.Now, PersonelID = customers.PersonelID };
            context.orders.Add(orders);
            context.SaveChanges();


            int[] list = new int[] { 1, 2, 3 };
            foreach (var item in list)
            {
                var products = context.products
   .Where(p => p.ID == item)
   .FirstOrDefault();
                var viewmode = new OrdersViewModel()
                {
                    ProductName = products.ProductName,
                    Price = products.Price,
                };
                viewModelList.Add(viewmode);
                double endPrice = 0;
                var personel = new Personel();
                if (customers.PersonelID == null)
                {
                    personel = context.personels
.Where(p => p.PersonelID == 0)
.FirstOrDefault();
                    DateTime date = DateTime.Now;
                    var Order = context.orders.Where(p => p.CustomerID == customers.ID).FirstOrDefault();
                    TimeSpan SonTarih = date - Order.OrdersDate;
                    var GunHesapla = SonTarih.Days;
                    if (personel == null && products.IsShoppingCentre == true && products.Price >= 100)
                    {
                        foreach (var i in viewModelList)
                        {
                            var x = (i.Price * 5) / 100;
                            endPrice = i.Price - x;
                        }
                    }
                    else if (personel == null && products.IsShoppingCentre == true && products.Price < 100 && GunHesapla >= 730)
                    {
                        foreach (var i in viewModelList)
                        {
                            var x = (i.Price * 5) / 100;
                            endPrice = i.Price - x;
                        }
                    }
                }
                else
                {
                    personel = context.personels
.Where(p => p.PersonelID == customers.PersonelID)
.FirstOrDefault();
                    if (personel.IsStoreStaff == true && personel != null && products.IsShoppingCentre == true)
                    {
                        foreach (var i in viewModelList)
                        {
                            var x = (i.Price * 30) / 100;
                            endPrice = i.Price - x;
                        }
                    }
                    else if (personel.IsStoreStaff == false && personel != null && products.IsShoppingCentre == true)
                    {
                        foreach (var y in viewModelList)
                        {
                            var x = (y.Price * 10) / 100;
                            endPrice = y.Price - x;
                        }
                    }
                }
                if (products.IsShoppingCentre == false)
                {
                    foreach (var y in viewModelList)
                    {
                        endPrice = y.Price;
                    }
                }
                var viewmodel = new OrdersViewModel()
                {
                    ProductName = products.ProductName,
                    Price = endPrice,
                };
                endViewModelList.Add(viewmodel);
            }
            double fiyat = 0;

            foreach (var item in endViewModelList)
            {
                fiyat += item.Price;
            }
            return new JsonResult()
            {
                Data = fiyat,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}
