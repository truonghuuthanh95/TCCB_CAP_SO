using DataAccessAndBussinessLayer.Models.DAO;
using DataAccessAndBussinessLayer.Repositories.Interfaces;
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
                    return Json(new ReturnResult(400, "Ứng viên đã đăng kí trước đó, mã đăng kí là: " + daDangKi.Id, null), JsonRequestBehavior.AllowGet);
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
            registrationInterview.NguoiTaoHoaDon = 2;
            registrationInterview.DOB = DateTime.Now;
            registrationInterview.CreatedAt = DateTime.Now;
            registrationInterview.IsActive = true;
            registrationInterview.HKTTWardId = 26740;
            registrationInterview.NOHNWardId = 26740;
            registrationInterviewRepository.TaoMoiUngVien(registrationInterview);
            return Json(new ReturnResult(200, "success", registrationInterview.Id));
        }

        [Route("inmadangki/{madangki}")]
        public ActionResult InMaDangKi(int madangki)
        {
            RegistrationInterview registrationInterview = registrationInterviewRepository.GetRegistrationInterviewById(madangki);
            return View(registrationInterview);
        }
    }
}