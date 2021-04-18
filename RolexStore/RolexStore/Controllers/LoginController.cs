using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RolexStore.Models;
using RolexStore.Common;

namespace RolexStore.Controllers
{
    public class LoginController : Controller
    {
        Login _db = null;
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.Email, model.Password);
                if (result)
                {
                    var user = dao.GetById(model.Email);
                    var userSession = new UserLogin();
                    userSession.Email = user.Email;
                    userSession.UserID = user.ID;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Sai thông tin đăng nhập");
                }
            }
            return View("Index");
        }
    }
}