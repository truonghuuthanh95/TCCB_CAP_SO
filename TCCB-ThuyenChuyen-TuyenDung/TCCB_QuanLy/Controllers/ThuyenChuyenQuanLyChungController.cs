using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Models.DTO;
using TCCB_QuanLy.Repositories.Interfaces;
using TCCB_QuanLy.Services;

namespace TCCB_QuanLy.Controllers
{
    [RoutePrefix("thuyenchuyen")]
    public class ThuyenChuyenQuanLyChungController : Controller
    {
        IThuyenChuyenRepository _thuyenChuyenRepository;

        public ThuyenChuyenQuanLyChungController(IThuyenChuyenRepository thuyenChuyenRepository)
        {
            _thuyenChuyenRepository = thuyenChuyenRepository;
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
            
                ViewBag.ThuyenChuyen = _thuyenChuyenRepository.GetThuyenChuyensById(mahoso);
                ViewBag.MaHoSo = mahoso;
                if (ViewBag.ThuyenChuyen == null)
                {
                    return RedirectToRoute("thuyenchuyentiepnhanhoso");
                }
                return View();
            
            
        }
        
        //kiểm tra hồ sơ có hợp lệ sua đó trả về json thông báo
        [Route("kiemtramahoso/{mahoso}")]
        [HttpGet]
        public ActionResult KiemTraMaHoSo(string mahoso)
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

            //ThuyenChuyen2020 thuyenChuyen = _thuyenChuyenRepository.GetThuyenChuyensByMaHoSo(mahoso.ToUpper().Trim());
            using (var _db = new TCCBDB())
            {
                var maHoSoId = _db.Database.SqlQuery<int>($"SELECT [Id] FROM [ThuyenChuyen2020] WHERE [TienTo] + CAST([Id] as nvarchar) = '{mahoso.ToUpper()}'").FirstOrDefault();

                if (maHoSoId == 0)
                {
                    return Json(new ReturnResult(404, "Không tìm thấy", null), JsonRequestBehavior.AllowGet);
                }
                //else if (thuyenChuyen.School.DVQLId != account.DvqlId)
                //{
                //    return Json(new ReturnResult(400, "Hồ sơ thuộc về " + thuyenChuyen.School.DVQL.TenDayDu, null), JsonRequestBehavior.AllowGet);
                //}

               // var thuyenChuyenJson = JsonConvert.SerializeObject(thuyenChuyen,
               //Formatting.None,
               //new JsonSerializerSettings()
               //{
               //    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
               //});
                return Json(new ReturnResult(200, "success", maHoSoId), JsonRequestBehavior.AllowGet);
            }                 
                       
        }
        [Route("chitiethoso/{mahoso}")]
        [HttpGet]
        public ActionResult ChiTietHoSo(int mahoso)
        {
            
                ViewBag.ThuyenChuyen = _thuyenChuyenRepository.GetThuyenChuyensById(mahoso);
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
           
                ThuyenChuyen2020 thuyenChuyen = _thuyenChuyenRepository.GetThuyenChuyensById(mahoso);
                if (thuyenChuyen == null)
                {
                    return Json(new ReturnResult(400, "Không tìm thấy hồ sơ", null), JsonRequestBehavior.AllowGet);
                }
                if (thuyenChuyen.StatusId != null )
                {
                    return Json(new ReturnResult(400, "Hồ sơ đã được tiếp nhận trước đó", null), JsonRequestBehavior.AllowGet);
                }
                _thuyenChuyenRepository.TiepNhanHoSo(thuyenChuyen, 1, account.Id);
                return Json(new ReturnResult(200, "success", null), JsonRequestBehavior.AllowGet);
            
                      
        }
        

        [Route("trangthaihoso/{id}/{year}")]
        [HttpGet]
        public ActionResult TrangThaiHoSo(int id, int year)
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
                using (var _thuyenChuyenService = new ThuyenChuyenRepository())
                {
                    ViewBag.ThuyenChuyens = _thuyenChuyenService.GetThuyenChuyensByDVQLAndYear(account.DvqlId, year);
                }
                
            }
            else
            {
                
                    ViewBag.ThuyenChuyens = _thuyenChuyenRepository.GetThuyenChuyenByStatusAndYear(id, year);
                               
            }
            using (var _statusThuyenChuyen = new TrangThaiHoSoService())
            {
                ViewBag.StatusThuyenChuyen = _statusThuyenChuyen.GetStatusThuyenChuyens();
            }
            ViewBag.StatusId = id;
            ViewBag.Year = year;
            return View();
        }
        
        [Route("capnhattrangthai")]
        [HttpPost]
        public ActionResult CapNhatTrangThai(int maHoSo, int trangThaiId, DateTime date, string ghiChu = " ")
        {
            using (var _thuyenChuyen = new ThuyenChuyenRepository())
            {
                ThuyenChuyen thuyenChuyen = _thuyenChuyen.GetThuyenChuyensById(maHoSo);
                if (thuyenChuyen == null)
                {
                    return Json(new ReturnResult(400, "failed", null), JsonRequestBehavior.AllowGet);
                }
                using (var _trangthai = new TrangThaiHoSoService())
                {
                    string trangthai = _trangthai.GetStatusThuyenChuyensById(trangThaiId).Name;
                    _thuyenChuyen.CapNhatTrangThaiHoSo(thuyenChuyen, trangThaiId, ghiChu);
                    return Json(new ReturnResult(200, trangthai, null), JsonRequestBehavior.AllowGet);
                }
                
            }

        }
        
        [Route("danhsachhosodatiepnhan/{year}")]
        [HttpGet]
        public ActionResult DanhSachHoSoDaTiepNhan(int year)
        {
            int permisstionId = 5;
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
                ViewBag.ThuyenChuyens = _thuyenChuyenRepository.GetThuyenChuyensByYear(year);                                                                     
            ViewBag.Year = year;
            return View();
        }

        [Route("downloadexcelthuyenchuyen/{statusId}/{year}")]
        [HttpGet]
        public async Task<ActionResult> DownloadThuyenChuyen(int statusId, int year)
        {

            Account account = (Account)Session[Utils.Constants.USER_SESSION];
            if (account == null)
            {
                return RedirectToRoute("login");
            }
           
                List<ThuyenChuyen2020> thuyenChuyens = _thuyenChuyenRepository.GetThuyenChuyenByStatusAndYear(statusId, year);
                string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Utils/ds-thuyenchuyen.xlsx");
                using (var _statusThuyenChuyen = new TrangThaiHoSoService())
                {
                    StatusThuyenChuyen statusThuyenChuyen = _statusThuyenChuyen.GetStatusThuyenChuyensById(statusId);
                    await Utils.ExportExcel.GenerateXLSThuyenChuyen(thuyenChuyens, filePath, statusThuyenChuyen.Name);
                    return File(filePath, "application/vnd.ms-excel", "ds-thuyenchuyen.xlsx");
                }
                           
            
        }
        
    }
}