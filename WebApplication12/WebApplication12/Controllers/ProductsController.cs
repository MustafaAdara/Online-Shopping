using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication12.Data;
using System.IO;

namespace WebApplication12.Controllers
{
    public class ProductsController : Controller
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
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = dp.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = dp.Products.Find(id);
            Disease disease = dp.Diseases.Find(id);

            dp.Products.Remove(product);
            dp.Diseases.Remove(disease);
            dp.SaveChanges();
            return RedirectToAction("Index");


        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dp.Dispose();
            }
            base.Dispose(disposing);
        }
        [HttpPost]
        public ActionResult CreateProduct(Product products,HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                string path = " ";
                if (img.FileName.Length >0)
                {
                    path = "~/images/" + Path.GetFileName(img.FileName);
                    img.SaveAs(Server.MapPath(path));
                }
                products.image = path;
                dp.Products.Add(products);
                dp.SaveChanges();
                RedirectToAction("Index");

            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = dp.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,Price,ProductType,Description")] Product product, HttpPostedFileBase img)
        {
            
            if (ModelState.IsValid)
            {
                string path = " ";
                if (img.FileName.Length > 0)
                {
                    path = "~/images/" + Path.GetFileName(img.FileName);
                    img.SaveAs(Server.MapPath(path));
                }
                product.image = path; 
                dp.Entry(product).State = EntityState.Modified;
                dp.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);

        }

    }
}