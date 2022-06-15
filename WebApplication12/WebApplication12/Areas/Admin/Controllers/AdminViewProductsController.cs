using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication12.Data;
namespace WebApplication12.Areas
{
    public class AdminViewProductsController : Controller
    { 
        private SoftwareProject_DBEntity dp = new SoftwareProject_DBEntity();
        [HttpGet]
        public ActionResult Index()
        {
            List<Product> products = dp.Products.ToList();

            return View(products);
        }
        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product products)
        {
            if (ModelState.IsValid)
            {
                dp.Products.Add(products);
                dp.SaveChanges();
                RedirectToAction("Index");

            }
            return View();
        }
    }
}