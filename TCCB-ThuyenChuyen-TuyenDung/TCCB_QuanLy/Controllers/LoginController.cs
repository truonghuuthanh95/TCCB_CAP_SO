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
        [Route("login")]
        public ActionResult Login()
        {

            return View();
        }
    }
}