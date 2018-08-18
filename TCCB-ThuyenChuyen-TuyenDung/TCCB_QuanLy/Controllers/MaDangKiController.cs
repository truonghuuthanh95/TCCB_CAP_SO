using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCCB_QuanLy.Controllers
{
    [RoutePrefix("tuyendung")]
    public class MaDangKiController : Controller
    {
        // GET: MaDangKi
        [Route("madangki")]
        public ActionResult MaDangKi()
        {
            return View();
        }
    }
}