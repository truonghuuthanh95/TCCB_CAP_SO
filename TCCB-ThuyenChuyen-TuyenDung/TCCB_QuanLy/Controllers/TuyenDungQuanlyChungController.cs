using TCCB_QuanLy.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCCB_QuanLy.Models.DAO;
using System.Threading.Tasks;
using LinqToExcel;
using System.Data.Entity.Validation;
using TCCB_QuanLy.Models.DTO;

namespace TCCB_QuanLy.Controllers
{
    [RoutePrefix("tuyendung")]
    public class TuyenDungQuanlyChungController : Controller
    {
        IRegistrationInterviewRepository registrationInterviewRepository;
        ICandidateSchoolRepository candidateSchoolRepository;

        public TuyenDungQuanlyChungController(IRegistrationInterviewRepository registrationInterviewRepository, ICandidateSchoolRepository candidateSchoolRepository)
        {
            this.registrationInterviewRepository = registrationInterviewRepository;
            this.candidateSchoolRepository = candidateSchoolRepository;
        }

        //GET: TuyenDungQuanlyChung
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
            //get tuyendung by truong duyet
            ViewBag.TuyenDungs = registrationInterviewRepository.GetTuyenDungsByStatus(4);
            return View();
        }
        //[Route("quanlychung/danhsachdangki")]
        //[HttpGet]
        //public ActionResult DanhSachDangKi()
        //{
        //    int permissionId = 1;
        //    Account account = (Account)Session[Utils.Constants.USER_SESSION];
        //    if (account == null)
        //    {
        //        return RedirectToRoute("login");
        //    }
        //    List<UserPermission> userPermission = (List<UserPermission>)Session[Utils.Constants.USER_PERMISSION_SESSION];
        //    if (userPermission.Where(s => s.PermissionId == permissionId).SingleOrDefault() == null)
        //    {
        //        return RedirectToRoute("login");
        //    }
        //    ViewBag.DanhSachDangKis = registrationInterviewRepository.GetRegistrationInterviewsDaDangKi();
        //    return View();
        //}
        //[Route("quanlychung/danhsachhoanthanh")]
        //[HttpGet]
        //public ActionResult DanhSachHoanThanh()
        //{
        //    int permissionId = 1;
        //    Account account = (Account)Session[Utils.Constants.USER_SESSION];
        //    if (account == null)
        //    {
        //        return RedirectToRoute("login");
        //    }
        //    List<UserPermission> userPermission = (List<UserPermission>)Session[Utils.Constants.USER_PERMISSION_SESSION];
        //    if (userPermission.Where(s => s.PermissionId == permissionId).SingleOrDefault() == null)
        //    {
        //        return RedirectToRoute("login");
        //    }
        //    ViewBag.DanhSachHoanThanhs = registrationInterviewRepository.GetRegistrationInterviewsDaHoanThanh();
        //    return View();
        //}
        //[Route("quanlychung/danhsachchuahoanthanh")]
        //[HttpGet]
        //public ActionResult DanhSachChuaHoanThanh()
        //{
        //    int permissionId = 1;
        //    Account account = (Account)Session[Utils.Constants.USER_SESSION];
        //    if (account == null)
        //    {
        //        return RedirectToRoute("login");
        //    }
        //    List<UserPermission> userPermission = (List<UserPermission>)Session[Utils.Constants.USER_PERMISSION_SESSION];
        //    if (userPermission.Where(s => s.PermissionId == permissionId).SingleOrDefault() == null)
        //    {
        //        return RedirectToRoute("login");
        //    }
        //    ViewBag.DanhSachChuaHoanThanhs = registrationInterviewRepository.GetRegistrationInterviewsChuaCapNhat();
        //    return View();
        //}
        //[Route("quanlychung/danhsachhosohople")]
        //[HttpGet]
        //public ActionResult DanhSachHoSoHopLe()
        //{
        //    int permissionId = 1;
        //    Account account = (Account)Session[Utils.Constants.USER_SESSION];
        //    if (account == null)
        //    {
        //        return RedirectToRoute("login");
        //    }
        //    List<UserPermission> userPermission = (List<UserPermission>)Session[Utils.Constants.USER_PERMISSION_SESSION];
        //    if (userPermission.Where(s => s.PermissionId == permissionId).SingleOrDefault() == null)
        //    {
        //        return RedirectToRoute("login");
        //    }
        //    ViewBag.DanhSachHopLe = registrationInterviewRepository.GetRegistrationInterviewsHopLe();
        //    return View();
        //}
        //[Route("quanlyketquatuyendung")]
        //[HttpGet]
        //public ActionResult QuanLyKetQuaTuyenDung()
        //{

        //    return View();
        //}
        //[Route("quanlychung/phannhiemso")]
        //[HttpGet]
        //public ActionResult PhanNhiemSo()
        //{
        //    int permissionId = 1;
        //    Account account = (Account)Session[Utils.Constants.USER_SESSION];
        //    if (account == null)
        //    {
        //        return RedirectToRoute("login");
        //    }
        //    List<UserPermission> userPermission = (List<UserPermission>)Session[Utils.Constants.USER_PERMISSION_SESSION];
        //    if (userPermission.Where(s => s.PermissionId == permissionId).SingleOrDefault() == null)
        //    {
        //        return RedirectToRoute("login");
        //    }
        //    var listCandidateSchool = candidateSchoolRepository.GetAllCandidatesSchool();
        //    ViewBag.CandidatesSchool = listCandidateSchool;
        //    return View();
        //}
        //[Route("uploadketqua")]
        //[HttpGet]
        //public ActionResult UploadKetQua(HttpPostedFileBase FileUpload)
        //{
        //    ////string userSession = (String)Session["USERSESSION"];
        //    ////if (String.IsNullOrWhiteSpace(userSession))
        //    ////{
        //    ////    return RedirectToRoute("dangnhap");
        //    ////}
        //    //if (FileUpload != null)
        //    //{
        //    //    string filename = FileUpload.FileName;
        //    //    // tdata.ExecuteCommand("truncate table OtherCompanyAssets");  
        //    //    if (filename.EndsWith(".xls") || filename.EndsWith(".xlsx"))
        //    //    {
        //    //        string targetpath = Server.MapPath("~/Doc/");
        //    //        FileUpload.SaveAs(targetpath + filename);
        //    //        string pathToExcelFile = targetpath + filename;
        //    //        var connectionString = "";
        //    //        if (filename.EndsWith(".xls"))
        //    //        {
        //    //            connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", pathToExcelFile);
        //    //        }
        //    //        else if (filename.EndsWith(".xlsx"))
        //    //        {
        //    //            connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", pathToExcelFile);
        //    //        }

        //    //        //var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
        //    //        //var ds = new DataSet();

        //    //        //adapter.Fill(ds, "ExcelTable");

        //    //        //DataTable dtable = ds.Tables["ExcelTable"];

        //    //        //string sheetName = "Sheet1";

        //    //        var excelQueryFactory = new ExcelQueryFactory(pathToExcelFile);
        //    //        excelQueryFactory.AddMapping<DiemHsGioi>(x => x.STT, "STT");
        //    //        excelQueryFactory.AddMapping<DiemHsGioi>(x => x.Mon, "MON");
        //    //        excelQueryFactory.AddMapping<DiemHsGioi>(x => x.SBD, "SBD");
        //    //        excelQueryFactory.AddMapping<DiemHsGioi>(x => x.Phong, "PHONG");
        //    //        excelQueryFactory.AddMapping<DiemHsGioi>(x => x.Ho, "HO");
        //    //        excelQueryFactory.AddMapping<DiemHsGioi>(x => x.Ten, "TEN");
        //    //        excelQueryFactory.AddMapping<DiemHsGioi>(x => x.Lop, "LOP");
        //    //        excelQueryFactory.AddMapping<DiemHsGioi>(x => x.Truong, "TRUONG");
        //    //        excelQueryFactory.AddMapping<DiemHsGioi>(x => x.MaTruong, "MA TRUONG");
        //    //        excelQueryFactory.AddMapping<DiemHsGioi>(x => x.DiemV1, "DIEM V1");
        //    //        excelQueryFactory.AddMapping<DiemHsGioi>(x => x.DiemV2, "DIEM V2");
        //    //        excelQueryFactory.AddMapping<DiemHsGioi>(x => x.Tong, "TONG");
        //    //        excelQueryFactory.AddMapping<DiemHsGioi>(x => x.XepGiai, "XEP GIAI");
        //    //        excelQueryFactory.AddMapping<DiemHsGioi>(x => x.GhiChu, "GHI CHU");
        //    //        var diemExcel = from a in excelQueryFactory.Worksheet<DiemHsGioi>(0) select a;

        //    //        foreach (var a in diemExcel)
        //    //        {
        //    //            try
        //    //            {
        //    //                if (!String.IsNullOrWhiteSpace(a.MaTruong)
        //    //                    && !String.IsNullOrWhiteSpace(a.SBD))
        //    //                {
        //    //                    DiemHsGioi diem = new DiemHsGioi();
        //    //                    diem.DiemV1 = a.DiemV1 == null ? "" : a.DiemV1.Trim();
        //    //                    diem.DiemV2 = a.DiemV2 == null ? "" : a.DiemV2.Trim();
        //    //                    diem.GhiChu = a.GhiChu == null ? "" : a.GhiChu.Trim();
        //    //                    diem.Ho = a.Ho.Trim();
        //    //                    diem.Lop = a.Lop.Trim();
        //    //                    diem.MaTruong = a.MaTruong.Trim();
        //    //                    diem.Mon = a.Mon.Trim();
        //    //                    diem.Phong = a.Phong.Trim();
        //    //                    diem.SBD = a.SBD.Trim();
        //    //                    diem.STT = a.STT.Trim();
        //    //                    diem.Ten = a.Ten.Trim();
        //    //                    diem.Tong = a.Tong.Trim();
        //    //                    diem.Truong = a.Truong.Trim();
        //    //                    diem.XepGiai = a.XepGiai == null ? "" : a.XepGiai.Trim();
        //    //                    db.DiemHsGiois.Add(diem);
        //    //                }
        //    //                else
        //    //                {

        //    //                    return Json(new ReturnResult(400, "SBD hoặc Mã Trường bị bỏ trống ở STT: " + a.STT + ", Vui lòng kiểm tra lại", null), JsonRequestBehavior.AllowGet);
        //    //                }

        //    //            }
        //    //            catch (DbEntityValidationException ex)
        //    //            {
        //    //                foreach (var entityValidationErrors in ex.EntityValidationErrors)
        //    //                {

        //    //                    foreach (var validationError in entityValidationErrors.ValidationErrors)
        //    //                    {

        //    //                        Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
        //    //                    }
        //    //                }
        //    //                return Json(new ReturnResult(400, "Có lỗi trong quá trình thêm vào. Vui lòng thử lại", null), JsonRequestBehavior.AllowGet);
        //    //            }
        //    //        }

        //    //        var alldiem = from d in db.DiemHsGiois select d;
        //    //        db.DiemHsGiois.RemoveRange(alldiem);
        //    //        db.SaveChanges();
        //    //        //deleting excel file from folder  
        //    //        if ((System.IO.File.Exists(pathToExcelFile)))
        //    //        {
        //    //            System.IO.File.Delete(pathToExcelFile);
        //    //        }
        //    //        return Json(new ReturnResult(200, "success", db.DiemHsGiois.ToList()), JsonRequestBehavior.AllowGet);
        //    //    }
        //    //    else
        //    //    {
        //    //        //alert message for invalid file format  

        //    //        return Json(new ReturnResult(400, "Vui lòng chọn file .xlsx hoặc .xls", null), JsonRequestBehavior.AllowGet);
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    return Json(new ReturnResult(400, "Vui lòng chọn file", null), JsonRequestBehavior.AllowGet);
        //    //}
        //    return View();
        //}
        //[Route("downloadexceltuyendung/{status}")]
        //[HttpGet]
        //public async Task<ActionResult> DownloadTuyenDung(string status)
        //{

        //    int permissionId = 1;
        //    Account account = (Account)Session[Utils.Constants.USER_SESSION];
        //    if (account == null)
        //    {
        //        return RedirectToRoute("login");
        //    }
        //    List<UserPermission> userPermission = (List<UserPermission>)Session[Utils.Constants.USER_PERMISSION_SESSION];
        //    if (userPermission.Where(s => s.PermissionId == permissionId).SingleOrDefault() == null)
        //    {
        //        return RedirectToRoute("login");
        //    }
        //    string filePath;
        //    if (status == "hople")
        //    {
        //        List<HoSoHopLe> hoSoHopLes = registrationInterviewRepository.GetRegistrationInterviewsHopLeWithDetail();
        //        filePath = System.Web.HttpContext.Current.Server.MapPath("~/Utils/ds-hople-tuyendung.xlsx");
        //        await Utils.ExportExcel.GenerateXLSRegistrationIsAccepted(hoSoHopLes, filePath);
        //        return File(filePath, "application/vnd.ms-excel", "ds-hople-tuyendung.xlsx");
        //    }
        //    else
        //    {
        //        List<RegistrationInterview> registrationInterviews = registrationInterviewRepository.GetRegistrationInterviewsDaHoanThanhWithDetail();
        //        filePath = System.Web.HttpContext.Current.Server.MapPath("~/Utils/ds-hoanthanhcapnhat-tuyendung.xlsx");
        //        await Utils.ExportExcel.GenerateXLSRegistrationCompleted(registrationInterviews, filePath);
        //        return File(filePath, "application/vnd.ms-excel", "ds-hoanthanhcapnhat-tuyendung.xlsx");
        //    }






        //}


    }
}