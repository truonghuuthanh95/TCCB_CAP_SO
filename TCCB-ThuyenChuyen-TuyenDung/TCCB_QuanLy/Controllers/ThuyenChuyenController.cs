using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCCB_QuanLy.Controllers
{
    [RoutePrefix("thuyenchuyen")]
    public class ThuyenChuyenController : Controller
    {
        // GET: ThuyenChuyen
        [Route("dangkimoi")]
        public ActionResult DangKimoi()
        {
            return View();
        }
        [Route("tiendohoso")]
        [HttpGet]
        public ActionResult TienDoHoSo()
        {
            return View();
        }

        [Route("huongdan")]
        [HttpGet]
        public ActionResult HuongDan()
        {
            return View();
        }
        [Route("hosomau")]
        [HttpGet]
        public ActionResult HoSoMau()
        {
            return View();
        }
    }
}