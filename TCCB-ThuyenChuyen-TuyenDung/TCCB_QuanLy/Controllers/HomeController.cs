using System.Collections.Generic;
using System.Web.Mvc;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Controllers
{
    
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            
            return View();
        }
        [Route("quanly")]
        [HttpGet]
        public ActionResult QuanLy()
        {
            Account account = (Account)Session[Utils.Constants.USER_SESSION];
            if (account == null)
            {
                return RedirectToRoute("login");
            }
            return View();
        }
        
    }
}