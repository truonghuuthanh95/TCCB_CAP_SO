using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCCB_QuanLy.Controllers
{
    [RoutePrefix("tuyendung")]
    public class TuyenDungQuanlyChungController : Controller
    {
        // GET: TuyenDungQuanlyChung
        [Route("quanlychung")]
        [HttpGet]
        public ActionResult QuanLyChung()
        {
            return View();
        }
        [Route("quanlychung/danhsachdangki")]
        [HttpGet]
        public ActionResult DanhSachDangKi()
        {

            return View();
        }
        [Route("quanlychung/danhsachhoanthanh")]
        [HttpGet]
        public ActionResult DanhSachHoanThanh()
        {

            return View();
        }
        [Route("quanlychung/danhsachchuahoanthanh")]
        [HttpGet]
        public ActionResult DanhSachChuaHoanThanh()
        {

            return View();
        }
        [Route("quanlychung/danhsachhosohople")]
        [HttpGet]
        public ActionResult DanhSachHoSoHopLe()
        {

            return View();
        }
    }
}