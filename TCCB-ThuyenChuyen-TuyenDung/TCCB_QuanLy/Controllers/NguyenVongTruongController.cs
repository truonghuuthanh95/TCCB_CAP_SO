using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCCB_QuanLy.Controllers
{
    [RoutePrefix("tuyendung")]
    public class NguyenVongTruongController : Controller
    {
        // GET: NguyenVongTruong
        [Route("nguyenvongtruong")]
        [HttpGet]
        public ActionResult NguyenVongTruong()
        {
            return View();
        }
        [Route("nguyenvongtruong/capnhat")]
        [HttpGet]
        public ActionResult CapNhatNguyenVongTruong()
        {
            return View();
        }
    }
}