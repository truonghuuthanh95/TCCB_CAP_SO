using TCCB_QuanLy.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCCB_QuanLy.Models.DAO;
using System.Threading.Tasks;

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
            int permissionId = 1;
            Account account = (Account)Session[Utils.Constants.USER_SESSION];
            if (account == null)
            {
                return RedirectToRoute("login");
            }
            List<UserPermission> userPermission = (List<UserPermission>)Session[Utils.Constants.USER_PERMISSION_SESSION];
            if (userPermission.Where(s => s.PermissionId == permissionId).SingleOrDefault() == null)
            {
                return RedirectToRoute("login");
            }
         
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
            int permissionId = 1;
            Account account = (Account)Session[Utils.Constants.USER_SESSION];
            if (account == null)
            {
                return RedirectToRoute("login");
            }
            List<UserPermission> userPermission = (List<UserPermission>)Session[Utils.Constants.USER_PERMISSION_SESSION];
            if (userPermission.Where(s => s.PermissionId == permissionId).SingleOrDefault() == null)
            {
                return RedirectToRoute("login");
            }
            ViewBag.DanhSachDangKis = registrationInterviewRepository.GetRegistrationInterviewsDaDangKi();
            return View();
        }
        [Route("quanlychung/danhsachhoanthanh")]
        [HttpGet]
        public ActionResult DanhSachHoanThanh()
        {
            int permissionId = 1;
            Account account = (Account)Session[Utils.Constants.USER_SESSION];
            if (account == null)
            {
                return RedirectToRoute("login");
            }
            List<UserPermission> userPermission = (List<UserPermission>)Session[Utils.Constants.USER_PERMISSION_SESSION];
            if (userPermission.Where(s => s.PermissionId == permissionId).SingleOrDefault() == null)
            {
                return RedirectToRoute("login");
            }
            ViewBag.DanhSachHoanThanhs = registrationInterviewRepository.GetRegistrationInterviewsDaHoanThanh();
            return View();
        }
        [Route("quanlychung/danhsachchuahoanthanh")]
        [HttpGet]
        public ActionResult DanhSachChuaHoanThanh()
        {
            int permissionId = 1;
            Account account = (Account)Session[Utils.Constants.USER_SESSION];
            if (account == null)
            {
                return RedirectToRoute("login");
            }
            List<UserPermission> userPermission = (List<UserPermission>)Session[Utils.Constants.USER_PERMISSION_SESSION];
            if (userPermission.Where(s => s.PermissionId == permissionId).SingleOrDefault() == null)
            {
                return RedirectToRoute("login");
            }
            ViewBag.DanhSachChuaHoanThanhs = registrationInterviewRepository.GetRegistrationInterviewsChuaCapNhat();
            return View();
        }
        [Route("quanlychung/danhsachhosohople")]
        [HttpGet]
        public ActionResult DanhSachHoSoHopLe()
        {
            int permissionId = 1;
            Account account = (Account)Session[Utils.Constants.USER_SESSION];
            if (account == null)
            {
                return RedirectToRoute("login");
            }
            List<UserPermission> userPermission = (List<UserPermission>)Session[Utils.Constants.USER_PERMISSION_SESSION];
            if (userPermission.Where(s => s.PermissionId == permissionId).SingleOrDefault() == null)
            {
                return RedirectToRoute("login");
            }
            ViewBag.DanhSachHopLe = registrationInterviewRepository.GetRegistrationInterviewsHopLe();
            return View();
        }
        [Route("downloadexceltuyendung/{status}")]
        [HttpGet]
        public async Task<ActionResult> DownloadTuyenDung(string status)
        {

            int permissionId = 1;
            Account account = (Account)Session[Utils.Constants.USER_SESSION];
            if (account == null)
            {
                return RedirectToRoute("login");
            }
            List<UserPermission> userPermission = (List<UserPermission>)Session[Utils.Constants.USER_PERMISSION_SESSION];
            if (userPermission.Where(s => s.PermissionId == permissionId).SingleOrDefault() == null)
            {
                return RedirectToRoute("login");
            }
            string filePath;
            
                List<RegistrationInterview> registrationInterviews = registrationInterviewRepository.GetRegistrationInterviewsDaHoanThanhWithDetail();
                filePath = System.Web.HttpContext.Current.Server.MapPath("~/Utils/ds-hoanthanhcapnhat-tuyendung.xlsx");
                await Utils.ExportExcel.GenerateXLSRegistrationCompleted(registrationInterviews, filePath);
                return File(filePath, "application/vnd.ms-excel", "ds-hoanthanhcapnhat-tuyendung.xlsx");
            
                                        

        }
    }
}