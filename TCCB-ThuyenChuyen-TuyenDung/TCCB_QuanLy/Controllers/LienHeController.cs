using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCCB_QuanLy.Controllers
{
    public class LienHeController : Controller
    {
        // GET: LienHe
        [Route("lienhe")]
        [HttpGet]
        public ActionResult LienHe()
        {
            return View();
        }
    }
}