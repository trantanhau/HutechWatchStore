using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RolexStore.Models;
using RolexStore.Common;

namespace RolexStore.Controllers
{
    public class AccountController : Controller
    {
        WatchModel _db = new WatchModel();
        AccountQuery query = new AccountQuery();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost, ActionName("SignUp")]
        public ActionResult SignUp(Customer acc)
        {
            acc.AccountType = 2;
            _db.Customers.Add(acc);
            _db.SaveChanges();
            return RedirectToAction("Login", "Account");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost, ActionName("Login")]
        public ActionResult Login(Customer acc)
        {
            if (query.TryLogin(acc.Email, acc.Password))
            {
                Customer a = query.getAccount(acc.Email);
                Session["user"] = a;
                Session["name"] = a.CustomerName;
                Session["username"] = a.CustomerName;
                Session["acc_id"] = a.CustomerID;
                //Session["message"] = "Đăng nhập thành công";
                ViewBag.message = "Login succesfully!";
                return RedirectToAction("Index", "Watch");
            }
            Session["message"] = "Login failed!";
            ViewBag.message = "Login failed!";
            return View();
        }
        public ActionResult LogOut()
        {
            Session["user"] = null;
            Session["name"] = null;
            Session["username"] = null;
            Session["acc_id"] = null;
            Session["message"] = null;
            return RedirectToAction("Index", "Watch");
        }

    }
}