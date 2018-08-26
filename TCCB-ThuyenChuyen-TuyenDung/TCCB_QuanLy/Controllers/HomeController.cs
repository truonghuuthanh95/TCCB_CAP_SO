using System.Collections.Generic;
using System.Web.Mvc;

namespace TCCB_QuanLy.Controllers
{
    public class HomeController : Controller
    {       
        public ActionResult Index()
        {
            return RedirectToRoute("login");
        }       
    }
}