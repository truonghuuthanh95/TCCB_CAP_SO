using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCCB_QuanLy.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [Route("login", Name = "login")]
        public ActionResult Login()
        {
            return View();
        }
        [Route("logout")]
        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToRoute("login");
        }
    }
}