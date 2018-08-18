using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCCB_QuanLy.Controllers
{
    [RoutePrefix("quanlytaikhoan")]
    public class QuanLyTaiKhoanController : Controller
    {
        // GET: QuanLyTaiKhoan
        [Route("")]
        public ActionResult TaiKhoan()
        {

            return View();
        }
    }
}