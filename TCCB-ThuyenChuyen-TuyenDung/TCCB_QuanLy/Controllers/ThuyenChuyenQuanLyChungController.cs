using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Models.DTO;
using TCCB_QuanLy.Services;

namespace TCCB_QuanLy.Controllers
{
    [RoutePrefix("thuyenchuyen")]
    public class ThuyenChuyenQuanLyChungController : Controller
    {

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
            using (var _thuyenChuyenService = new ThuyenChuyenRepository())
            {
                ViewBag.ThuyenChuyen = _thuyenChuyenService.GetThuyenChuyensById(mahoso);
                ViewBag.MaHoSo = mahoso;
                if (ViewBag.ThuyenChuyen == null)
                {
                    return RedirectToRoute("thuyenchuyentiepnhanhoso");
                }
                return View();
            }
            
        }
        //duyệt hồ sơ ngoài tỉnh view()
        [Route("duyethosongoaitinh/{mahoso}")]
        [HttpGet]
        public ActionResult DuyetHoSoNgoaiTinh(int mahoso)
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
            using (var _thuyenChuyenService = new ThuyenChuyenNgoaiTinhService())
            {
                ViewBag.ThuyenChuyen = _thuyenChuyenService.GetThuyenChuyensById(mahoso);
                ViewBag.MaHoSo = mahoso;
                if (ViewBag.ThuyenChuyen == null)
                {
                    return RedirectToRoute("thuyenchuyentiepnhanhoso");
                }
                return View();
            }

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
            if (mahoso.ToUpper().Contains("TCN"))
            {
                using (var _thuyenChuyenService = new ThuyenChuyenNgoaiTinhService())
                {
                    ThuyenChuyenNgoaiTinh thuyenChuyen = _thuyenChuyenService.GetThuyenChuyensByMaHoSo(mahoso.Trim());
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
            }
            else if (mahoso.ToUpper().Contains("TC"))
            {
                using (var _thuyenChuyenService = new ThuyenChuyenRepository())
                {
                    ThuyenChuyen thuyenChuyen = _thuyenChuyenService.GetThuyenChuyensByMaHoSo(mahoso.Trim());
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
            }            
            else
            {
                return Json(new ReturnResult(404, "Không tìm thấy", null), JsonRequestBehavior.AllowGet);
            }                 
        }
        [Route("chitiethoso/{mahoso}")]
        [HttpGet]
        public ActionResult ChiTietHoSo(int mahoso)
        {
            using (var _thuyenChuyenService = new ThuyenChuyenRepository())
            {
                ViewBag.ThuyenChuyen = _thuyenChuyenService.GetThuyenChuyensById(mahoso);
                return View();
            }
            
        }
        [Route("chitiethosongoaitinh/{mahoso}")]
        [HttpGet]
        public ActionResult ChiTietHoSoNgoaiTinh(int mahoso)
        {
            using (var _thuyenChuyenService = new ThuyenChuyenNgoaiTinhService())
            {
                ViewBag.ThuyenChuyen = _thuyenChuyenService.GetThuyenChuyensById(mahoso);
                return View();
            }

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
            using (var _thuyenChuyenService = new ThuyenChuyenRepository())
            {
                ThuyenChuyen thuyenChuyen = _thuyenChuyenService.GetThuyenChuyensById(mahoso);
                if (thuyenChuyen == null)
                {
                    return Json(new ReturnResult(400, "Không tìm thấy hồ sơ", null), JsonRequestBehavior.AllowGet);
                }
                if (thuyenChuyen.StatusId != null )
                {
                    return Json(new ReturnResult(400, "Hồ sơ đã được tiếp nhận trước đó", null), JsonRequestBehavior.AllowGet);
                }
                _thuyenChuyenService.TiepNhanHoSo(thuyenChuyen, 1, account.Id);
                return Json(new ReturnResult(200, "success", null), JsonRequestBehavior.AllowGet);
            }
                      
        }
        [Route("nhanhosothuyenchuyenngoaitinh/{mahoso}")]
        [HttpGet]
        public ActionResult NhanHoSoThuyenChuyenNgoaiTinh(int mahoso)
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
            using (var _thuyenChuyenService = new ThuyenChuyenNgoaiTinhService())
            {
                ThuyenChuyenNgoaiTinh thuyenChuyen = _thuyenChuyenService.GetThuyenChuyensById(mahoso);
                if (thuyenChuyen == null)
                {
                    return Json(new ReturnResult(400, "Không tìm thấy hồ sơ", null), JsonRequestBehavior.AllowGet);
                }
                if (thuyenChuyen.StatusId != null)
                {
                    return Json(new ReturnResult(400, "Hồ sơ đã được tiếp nhận trước đó", null), JsonRequestBehavior.AllowGet);
                }
                _thuyenChuyenService.TiepNhanHoSo(thuyenChuyen, 1, account.Id);
                return Json(new ReturnResult(200, "success", null), JsonRequestBehavior.AllowGet);
            }

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
                using (var _thuyenChuyenService = new ThuyenChuyenRepository())
                {
                    ViewBag.ThuyenChuyens = _thuyenChuyenService.GetThuyenChuyenByStatusAndDvqlAndYear(id, account.DvqlId, year);
                }
                
            }
            using (var _statusThuyenChuyen = new TrangThaiHoSoService())
            {
                ViewBag.StatusThuyenChuyen = _statusThuyenChuyen.GetStatusThuyenChuyens();
            }
            ViewBag.StatusId = id;
            ViewBag.Year = year;
            return View();
        }
        [Route("trangthaihosongoaitinh/{id}/{year}")]
        [HttpGet]
        public ActionResult TrangThaiHoSoNgoaiTinh(int id, int year)
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
            
            else
            {
                using (var _thuyenChuyenService = new ThuyenChuyenNgoaiTinhService())
                {
                    ViewBag.ThuyenChuyens = _thuyenChuyenService.GetThuyenChuyenByStatusAndDvqlAndYear(id, account.DvqlId, year);
                }

            }
            using (var _statusThuyenChuyen = new TrangThaiHoSoService())
            {
                ViewBag.StatusThuyenChuyen = _statusThuyenChuyen.GetStatusThuyenChuyens();
            }
            ViewBag.StatusId = id;
            ViewBag.Year = year;
            return View();
        }
        [Route("capnhattrangthai/{maHoSo}/{trangThaiId}/{date}")]
        [HttpGet]
        public ActionResult CapNhatTrangThai(int maHoSo, int trangThaiId, DateTime date)
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
                    _thuyenChuyen.CapNhatTrangThaiHoSo(thuyenChuyen, trangThaiId);
                    return Json(new ReturnResult(200, trangthai, null), JsonRequestBehavior.AllowGet);
                }
                
            }

        }
        [Route("capnhattrangthaingoatinh/{maHoSo}/{trangThaiId}/{date}")]
        [HttpGet]
        public ActionResult CapNhatTrangThaiNgoaiTinh(int maHoSo, int trangThaiId, DateTime date)
        {

            using (var _thuyenChuyen = new ThuyenChuyenNgoaiTinhService())
            {
                ThuyenChuyenNgoaiTinh thuyenChuyen = _thuyenChuyen.GetThuyenChuyensById(maHoSo);
                if (thuyenChuyen == null)
                {
                    return Json(new ReturnResult(400, "failed", null), JsonRequestBehavior.AllowGet);
                }
                _thuyenChuyen.CapNhatTrangThaiHoSo(thuyenChuyen, trangThaiId);
                return Json(new ReturnResult(200, "success", null), JsonRequestBehavior.AllowGet);
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
            else
            {
                using (var _thuyenChuyenNgoaiTinhService = new ThuyenChuyenNgoaiTinhService())
                {
                    List<ThuyenChuyenNgoaiTinh> thuyenChuyenNgoaiTinhs = _thuyenChuyenNgoaiTinhService.GetThuyenChuyensByYearDaTiepNhan(year);
                    using (var _thuyenChuyenService = new ThuyenChuyenRepository())
                    {
                        List<ThuyenChuyen> thuyenChuyens = _thuyenChuyenService.GetThuyenChuyensByYearDaTiepNhan(year);
                        List<ThuyenChuyenContainNgoaiTinhDTO> thuyenChuyenContainNgoais = new List<ThuyenChuyenContainNgoaiTinhDTO>();
                        foreach (var item in thuyenChuyenNgoaiTinhs)
                        {
                            ThuyenChuyenContainNgoaiTinhDTO thuyenChuyenContainNgoaiTinhDTO = new ThuyenChuyenContainNgoaiTinhDTO();
                            thuyenChuyenContainNgoaiTinhDTO.CMND = item.CMND;
                            thuyenChuyenContainNgoaiTinhDTO.HoTen = item.HoTen;
                            thuyenChuyenContainNgoaiTinhDTO.Id = item.Id;
                            thuyenChuyenContainNgoaiTinhDTO.NamSinh = item.NamSinh.Value;
                            thuyenChuyenContainNgoaiTinhDTO.NgayTiepNhan = item.NgayTiepNhan.Value;
                            thuyenChuyenContainNgoaiTinhDTO.TienTo = item.TienTo;
                            thuyenChuyenContainNgoaiTinhDTO.DangCongTac = item.DVDCTTenTruong + " (" + item.Province.Type + " " + item.Province.Name + ")";
                            thuyenChuyenContainNgoaiTinhDTO.XinChuyenDen = item.School.TenTruong;
                            thuyenChuyenContainNgoais.Add(thuyenChuyenContainNgoaiTinhDTO);
                        }
                        foreach (var item in thuyenChuyens)
                        {
                            ThuyenChuyenContainNgoaiTinhDTO thuyenChuyenContainNgoaiTinhDTO = new ThuyenChuyenContainNgoaiTinhDTO();
                            thuyenChuyenContainNgoaiTinhDTO.CMND = item.CMND;
                            thuyenChuyenContainNgoaiTinhDTO.HoTen = item.HoTen;
                            thuyenChuyenContainNgoaiTinhDTO.Id = item.Id;
                            thuyenChuyenContainNgoaiTinhDTO.NamSinh = item.NamSinh.Value;
                            thuyenChuyenContainNgoaiTinhDTO.NgayTiepNhan = item.NgayTiepNhan.Value;
                            thuyenChuyenContainNgoaiTinhDTO.TienTo = item.TienTo;
                            thuyenChuyenContainNgoaiTinhDTO.DangCongTac = item.School.TenTruong;
                            thuyenChuyenContainNgoaiTinhDTO.XinChuyenDen = item.School1.TenTruong;
                            thuyenChuyenContainNgoais.Add(thuyenChuyenContainNgoaiTinhDTO);
                        }
                        ViewBag.ThuyenChuyens = thuyenChuyenContainNgoais.OrderByDescending(s => s.NgayTiepNhan);
                    }
                }                
            }            
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
            using (var _thuyenChuyenService = new ThuyenChuyenRepository())
            {
                List<ThuyenChuyen> thuyenChuyens = _thuyenChuyenService.GetThuyenChuyenByStatusAndDvqlAndYear(statusId, account.DvqlId, year);
                string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Utils/ds-thuyenchuyen.xlsx");
                using (var _statusThuyenChuyen = new TrangThaiHoSoService())
                {
                    StatusThuyenChuyen statusThuyenChuyen = _statusThuyenChuyen.GetStatusThuyenChuyensById(statusId);
                    await Utils.ExportExcel.GenerateXLSThuyenChuyen(thuyenChuyens, filePath, statusThuyenChuyen.Name);
                    return File(filePath, "application/vnd.ms-excel", "ds-thuyenchuyen.xlsx");
                }
                
            }
            
        }
        [Route("downloadexcelthuyenchuyenngoaitinh/{statusId}/{year}")]
        [HttpGet]
        public async Task<ActionResult> DownloadThuyenChuyenNgoaiTinh(int statusId, int year)
        {

            Account account = (Account)Session[Utils.Constants.USER_SESSION];
            if (account == null)
            {
                return RedirectToRoute("login");
            }
            using (var _thuyenChuyenService = new ThuyenChuyenNgoaiTinhService())
            {
                List<ThuyenChuyenNgoaiTinh> thuyenChuyens = _thuyenChuyenService.GetThuyenChuyenByStatusAndDvqlAndYear(statusId, account.DvqlId, year);
                string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Utils/ds-thuyenchuyenngoaitinh.xlsx");
                using (var _statusThuyenChuyen = new TrangThaiHoSoService())
                {
                    StatusThuyenChuyen statusThuyenChuyen = _statusThuyenChuyen.GetStatusThuyenChuyensById(statusId);
                    await Utils.ExportExcel.GenerateXLSThuyenChuyenNgoaiTinh(thuyenChuyens, filePath, statusThuyenChuyen.Name);
                    return File(filePath, "application/vnd.ms-excel", "ds-thuyenchuyenngoaitinh.xlsx");
                }

            }

        }
    }
}