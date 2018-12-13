using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Models.DTO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Controllers
{
    [RoutePrefix("thuyenchuyen")]
    public class ThuyenChuyenQuanLyChungController : Controller
    {
        IThuyenChuyenRepository thuyenChuyenRepository;

        public ThuyenChuyenQuanLyChungController(IThuyenChuyenRepository thuyenChuyenRepository)
        {
            this.thuyenChuyenRepository = thuyenChuyenRepository;
        }

        // GET: ThuyenChuyenQuanLyChung

        [Route("tiepnhanhoso", Name = "thuyenchuyentiepnhanhoso")]
        [HttpGet]
        public ActionResult TiepNhanHoSo()
        {
            int permisstionId = 3;
            Account account = (Account)Session[Utils.Constants.USER_SESSION];
            if (account == null)
            {
                return RedirectToRoute("login");
            }
            List<UserPermission> userPermission = (List<UserPermission>)Session[Utils.Constants.USER_PERMISSION_SESSION];
            if (userPermission.Where(s => s.PermissionId == permisstionId).SingleOrDefault() == null)
            {
                return RedirectToRoute("login");
            }
            return View();
        }
        [Route("duyethoso/{mahoso}")]
        [HttpGet]
        public ActionResult DuyetHoSo(int mahoso)
        {
            int permisstionId = 3;
            Account account = (Account)Session[Utils.Constants.USER_SESSION];
            if (account == null)
            {
                return RedirectToRoute("login");
            }
            List<UserPermission> userPermission = (List<UserPermission>)Session[Utils.Constants.USER_PERMISSION_SESSION];
            if (userPermission.Where(s => s.PermissionId == permisstionId).SingleOrDefault() == null)
            {
                return RedirectToRoute("login");
            }
            ViewBag.ThuyenChuyen = thuyenChuyenRepository.GetThuyenChuyensById(mahoso);
            ViewBag.MaHoSo = mahoso;
            if (ViewBag.ThuyenChuyen == null)
            {
                return RedirectToRoute("thuyenchuyentiepnhanhoso");
            }
            return View();
        }
        [Route("kiemtramahoso/{mahoso}")]
        [HttpGet]
        public ActionResult KiemTraMaHoSo(int mahoso)
        {
            int permisstionId = 3;
            Account account = (Account)Session[Utils.Constants.USER_SESSION];
            if (account == null)
            {
                return Json(new ReturnResult(403, "access denied", null), JsonRequestBehavior.AllowGet);
            }
            List<UserPermission> userPermission = (List<UserPermission>)Session[Utils.Constants.USER_PERMISSION_SESSION];
            if (userPermission.Where(s => s.PermissionId == permisstionId).SingleOrDefault() == null)
            {
                return Json(new ReturnResult(403, "access denied", null), JsonRequestBehavior.AllowGet);
            }
            ThuyenChuyen thuyenChuyen = thuyenChuyenRepository.GetThuyenChuyensById(mahoso);
            if (thuyenChuyen == null)
            {
                return Json(new ReturnResult(404, "Không tìm thấy", null), JsonRequestBehavior.AllowGet);
            }
            else if (thuyenChuyen.School.DVQLId != account.DvqlId)
            {
                return Json(new ReturnResult(400, "Hồ sơ thuộc về " + thuyenChuyen.School.DVQL.TenDayDu, null), JsonRequestBehavior.AllowGet);
            }           
            var thuyenChuyenJson = JsonConvert.SerializeObject(thuyenChuyen,
           Formatting.None,
           new JsonSerializerSettings()
           {
               ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
           });
            return Json(new ReturnResult(200, "success", thuyenChuyenJson), JsonRequestBehavior.AllowGet);        
        }
        [Route("chitiethoso/{mahoso}")]
        [HttpGet]
        public ActionResult ChiTietHoSo(int mahoso)
        {
            ViewBag.ThuyenChuyen = thuyenChuyenRepository.GetThuyenChuyensById(mahoso);
            return View();
        }
        [Route("nhanhosothuyenchuyen/{mahoso}")]
        [HttpGet]
        public ActionResult NhanHoSoThuyenChuyen (int mahoso)
        {
            int permisstionId = 3;
            Account account = (Account)Session[Utils.Constants.USER_SESSION];
            if (account == null)
            {
                return Json(new ReturnResult(403, "access denied", null), JsonRequestBehavior.AllowGet);
            }
            List<UserPermission> userPermission = (List<UserPermission>)Session[Utils.Constants.USER_PERMISSION_SESSION];
            if (userPermission.Where(s => s.PermissionId == permisstionId).SingleOrDefault() == null)
            {
                return Json(new ReturnResult(403, "access denied", null), JsonRequestBehavior.AllowGet);
            }

            ThuyenChuyen thuyenChuyen = thuyenChuyenRepository.GetThuyenChuyensById(mahoso);
            if (thuyenChuyen == null || thuyenChuyen.StatusId != null)
            {
                return Json(new ReturnResult(400, "Không tìm thấy hồ sơ", null), JsonRequestBehavior.AllowGet);
            }
            if (thuyenChuyen.StatusId != null)
            {
                return Json(new ReturnResult(400, "Hồ sơ đã được tiếp nhận", null), JsonRequestBehavior.AllowGet);
            }
            thuyenChuyenRepository.CapNhatTrangThaiHoSo(thuyenChuyen, 1);
            return Json(new ReturnResult(200, "success", null), JsonRequestBehavior.AllowGet);           
        }

        
        [Route("trangthaihoso/{id}")]
        [HttpGet]
        public ActionResult TrangThaiHoSo(int id)
        {
            int permisstionId = 4;
            Account account = (Account)Session[Utils.Constants.USER_SESSION];
            if (account == null)
            {
                return RedirectToRoute("login");
            }
            List<UserPermission> userPermission = (List<UserPermission>)Session[Utils.Constants.USER_PERMISSION_SESSION];
            if (userPermission.Where(s => s.PermissionId == permisstionId).SingleOrDefault() == null)
            {
                return RedirectToRoute("login");
            }
            if (id == 100)
            {
                ViewBag.ThuyenChuyens = thuyenChuyenRepository.GetThuyenChuyens(account.DvqlId);
            }
            else
            {
                ViewBag.ThuyenChuyens = thuyenChuyenRepository.GetThuyenChuyenByStatusAndDvql(id, account.DvqlId);
            }
            ViewBag.StatusId = id;
            return View();
        }
    }
}