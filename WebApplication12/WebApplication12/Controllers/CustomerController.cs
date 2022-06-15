using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication12.Data;
namespace WebApplication12.Controllers
{
    public class CustomerController : Controller
    {
        private SoftwareProject_DBEntity dp = new SoftwareProject_DBEntity();
        // GET: Customer
        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(Customer customer)
        {
            if (ModelState.IsValid)
            {

                dp.Customers.Add(customer);
                dp.SaveChanges();
                
     

            }
            return RedirectToAction("index", "Default");
        }
        public ActionResult Search(string search)
        {
            if (search != null)
            {
                search = search.ToLower();
            }
            return View(dp.Diseases.Where(x => x.DiseaseName.Contains(search)).ToList());
        }
    }
}