using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication12.Data;
namespace WebApplication12.Controllers
{
    
    public class DefaultController : Controller
    {
        private SoftwareProject_DBEntity db = new SoftwareProject_DBEntity();
        // GET: Default
        public ActionResult Index()
        {
            var ProductRec = db.Products.ToList();
            return View(ProductRec);

        }


    }
}