using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication12.Areas.Admin.Models;
using WebApplication12.Services;
namespace WebApplication12.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account/Login
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult LoginCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel logininfo)
        {
            var AdminServices = new AdminServices();
            var isLoggedin = AdminServices.login(logininfo.UserName, logininfo.Password);
            var isLoggedinCustomer = AdminServices.LoginCustomer(logininfo.UserName, logininfo.Password);

            if (isLoggedin)
            {
                return RedirectToAction("index", "DefaultAdmin");
            }
            else if (isLoggedinCustomer)
            {
                return RedirectToAction("LoginCustomer", "Account");
            }
            {
                logininfo.Massage = "UserName or Password is wrong ";
                return View(logininfo);
            }
        }
    }
}