using DataAccessAndBussinessLayer.Repositories.Interfaces;
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
        IRegistrationInterviewRepository registrationInterviewRepository;

        public TuyenDungQuanlyChungController(IRegistrationInterviewRepository registrationInterviewRepository)
        {
            this.registrationInterviewRepository = registrationInterviewRepository;
        }

        // GET: TuyenDungQuanlyChung
        [Route("quanlychung")]
        [HttpGet]
        public ActionResult QuanLyChung()
        {
            ViewBag.DaDangKis = registrationInterviewRepository.GetRegistrationInterviewsDaDangkiSoLuong();
            ViewBag.ChuaCapNhats = registrationInterviewRepository.GetRegistrationInterviewsChuaCapNhatSoLuong();
            ViewBag.DaHoanThanhs = registrationInterviewRepository.GetRegistrationInterviewsDaHoanThanhSoLuong();
            ViewBag.HosoHopLes = registrationInterviewRepository.GetRegistrationInterviewsHopLeSoLuong();
            return View();
        }
        [Route("quanlychung/danhsachdangki")]
        [HttpGet]
        public ActionResult DanhSachDangKi()
        {
            ViewBag.DanhSachDangKis = registrationInterviewRepository.GetRegistrationInterviewsDaDangKi();
            return View();
        }
        [Route("quanlychung/danhsachhoanthanh")]
        [HttpGet]
        public ActionResult DanhSachHoanThanh()
        {
            ViewBag.DanhSachHoanThanhs = registrationInterviewRepository.GetRegistrationInterviewsDaHoanThanh();
            return View();
        }
        [Route("quanlychung/danhsachchuahoanthanh")]
        [HttpGet]
        public ActionResult DanhSachChuaHoanThanh()
        {
            ViewBag.DanhSachChuaHoanThanhs = registrationInterviewRepository.GetRegistrationInterviewsChuaCapNhat();
            return View();
        }
        [Route("quanlychung/danhsachhosohople")]
        [HttpGet]
        public ActionResult DanhSachHoSoHopLe()
        {
            ViewBag.DanhSachHopLe = registrationInterviewRepository.GetRegistrationInterviewsHopLe();
            return View();
        }
    }
}