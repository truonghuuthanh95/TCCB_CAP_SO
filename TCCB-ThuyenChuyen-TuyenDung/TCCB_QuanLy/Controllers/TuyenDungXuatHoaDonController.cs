using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCCB_QuanLy.Models.DTO;

namespace TCCB_QuanLy.Controllers
{
    [RoutePrefix("tuyendung")]
    public class TuyenDungXuatHoaDonController : Controller
    {
        IRegistrationInterviewRepository registrationInterviewRepository;

        public TuyenDungXuatHoaDonController(IRegistrationInterviewRepository registrationInterviewRepository)
        {
            this.registrationInterviewRepository = registrationInterviewRepository;
        }

        // GET: TuyenDungXuatHoaDon
        [Route("xuatmadangki")]
        [HttpGet]
        public ActionResult Index()
        {
            int permisstionId = 6;
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
        [Route("kiemtrahoplecmnd/{cmnd}")]
        [HttpGet]
        public ActionResult KiemTraHopLeCMND(string cmnd)
        {
            List<RegistrationInterview> registrationInterviews = registrationInterviewRepository.GetRegistrationInterviewsByCmnd(cmnd.Trim());
            if (registrationInterviews.Count != 0)
            {
                if (registrationInterviews.Any(s => s.IsActive == true))
                {
                    RegistrationInterview daDangKi = registrationInterviews.Where(s => s.IsActive == true).FirstOrDefault();
                    return Json(new ReturnResult(400, "Ứng viên đã đăng kí trước đó, mã đăng kí là: " + daDangKi.TienTo + daDangKi.Id, null), JsonRequestBehavior.AllowGet);
                }
                else if (registrationInterviews.Any(s => s.IsPass == true))
                {
                    RegistrationInterview daDauTruocDo = registrationInterviews.Where(s => s.IsPass == true).FirstOrDefault();
                    return Json(new ReturnResult(400, "Ứng viên đã đậu kì thi tuyển năm " + daDauTruocDo.NgayRaXoat.Value.Year, null), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new ReturnResult(200, "Hợp lệ", null), JsonRequestBehavior.AllowGet);
        }
        [Route("taomoiungvien")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoMoiUngVien(string cmnd, string hoVaTen)
        {
            int permisstionId = 6;
            Account account = (Account)Session[Utils.Constants.USER_SESSION];
            if (account == null)
            {
                return Json(new ReturnResult(403, "Access denied", null), JsonRequestBehavior.AllowGet);
            }
            List<UserPermission> userPermission = (List<UserPermission>)Session[Utils.Constants.USER_PERMISSION_SESSION];
            if (userPermission.Where(s => s.PermissionId == permisstionId).SingleOrDefault() == null)
            {
                return Json(new ReturnResult(403, "Access denied", null), JsonRequestBehavior.AllowGet);
            }
            RegistrationInterview registrationInterview = new RegistrationInterview();
            string[] arrListStr = hoVaTen.Trim().Split(' ');//tách trong chuỗi str trên khi gặp ký tự ' '           
            registrationInterview.FirstName = arrListStr[arrListStr.Length - 1].Trim();
            string candidateLastName = "";
            for (int i = 0; i < arrListStr.Length - 1; i++)
            {
                candidateLastName = candidateLastName + arrListStr[i] + " ";
            }
            registrationInterview.LastName = candidateLastName.Trim();
            registrationInterview.IdentifyCard = cmnd.Trim();
            registrationInterview.NguoiTaoHoaDon = account.Id;
            registrationInterview.DOB = DateTime.Now;
            registrationInterview.CreatedAt = DateTime.Now;
            registrationInterview.IsActive = true;
            registrationInterview.HKTTWardId = 26740;
            registrationInterview.NOHNWardId = 26740;
            registrationInterview.CMNDNgayCap = DateTime.Now;
            //create default working status because in 2019 we do not need this propertise field. So I set this thing to 1.
            registrationInterview.LamViecTrongNganhId = 1;            
            registrationInterview.TienTo = "TD";
            registrationInterview.TrinhDoVanHoa = "Tốt nghiệp THPT";
            registrationInterview.DoiTuongUuTien = 1;
            registrationInterview.TruongHopDacBietId = 1;
            registrationInterview.DanTocId = 1;
            registrationInterview.TrinhDoNgoaiNguKhacId = 1;
            registrationInterviewRepository.TaoMoiUngVien(registrationInterview);
            return Json(new ReturnResult(200, "success", registrationInterview.Id));
        }

        [Route("inmadangki/{madangki}")]
        public ActionResult InMaDangKi(int madangki)
        {
            int permisstionId = 6;
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
            RegistrationInterview registrationInterview = registrationInterviewRepository.GetRegistrationInterviewById(madangki);
            return View(registrationInterview);
        }
    }
}