using AutoMapper;
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
    public class SchoolController : Controller
    {
        ISchoolRepository schoolRepository;
        ICandidateSchoolRepository candidateSchoolRepository;
        IStatusTiepNhanRepository statusTiepNhanRepository;
        ITruongMonDuTuyenRepository truongMonDuTuyenRepository;
        IRegistrationInterviewRepository registrationInterviewRepository;
        ITruongNhiemVuThamGiaHDTDRepository truongNhiemVuThamGiaHDTDRepository;

        public SchoolController(ISchoolRepository schoolRepository, ICandidateSchoolRepository candidateSchoolRepository, IStatusTiepNhanRepository statusTiepNhanRepository, ITruongMonDuTuyenRepository truongMonDuTuyenRepository, IRegistrationInterviewRepository registrationInterviewRepository, ITruongNhiemVuThamGiaHDTDRepository truongNhiemVuThamGiaHDTDRepository)
        {
            this.schoolRepository = schoolRepository;
            this.candidateSchoolRepository = candidateSchoolRepository;
            this.statusTiepNhanRepository = statusTiepNhanRepository;
            this.truongMonDuTuyenRepository = truongMonDuTuyenRepository;
            this.registrationInterviewRepository = registrationInterviewRepository;
            this.truongNhiemVuThamGiaHDTDRepository = truongNhiemVuThamGiaHDTDRepository;
        }





        // GET: School
        [Route("getschoolbydistrictandcaphoc/{schoolId}/{caphocId}")]
        [HttpGet]
        public ActionResult GetSchoolByDistrictAndCapHoc(int schoolid, int caphocId)
        {
            List<School> schools = schoolRepository.GetSchoolsByDistrictAndCapHoc(schoolid, caphocId);
            var schoolsJson = JsonConvert.SerializeObject(schools,
         Formatting.None,
         new JsonSerializerSettings()
         {
             ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
         });
            return Json(new ReturnResult(200, "success", schoolsJson), JsonRequestBehavior.AllowGet);           
        }
        [Route("getschoolbymondutuyen/{monDuTuyenId}")]
        [HttpGet]
        public ActionResult GetSchoolByMonDuTuyenId(int monDuTuyenId)
        {
            List<School> schools = truongMonDuTuyenRepository.GetTruongByMonDuTuyen(monDuTuyenId);
            var schoolsJson = JsonConvert.SerializeObject(schools,
         Formatting.None,
         new JsonSerializerSettings()
         {
             ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
         });
            return Json(new ReturnResult(200, "success", schoolsJson), JsonRequestBehavior.AllowGet);
        }
        [Route("truongquanlyungvien", Name = "truongquanlyungvien")]
        [HttpGet]
        public ActionResult TruongQuanLyUngVien()
        {
            School accountSchool = (School)Session[Utils.Constants.USER_SCHOOL_SESSION];
            if (accountSchool == null)
            {
                return RedirectToRoute("loginsoption");
            }
            List<StatusTiepNhan> statusTiepNhans = statusTiepNhanRepository.GetStatusTiepNhans();
            ViewBag.School = accountSchool;
            ViewBag.CandidateSchools = registrationInterviewRepository.GetTuyenDungBySchoolID(accountSchool.Id);
            ViewBag.StatusTiepNhans = statusTiepNhans;
            return View();
        }

        [Route("capnhattiepnhantuyendung/{tuyenDungId}/{statusTiepNhanId}")]
        [HttpGet]
        public ActionResult CapNhatTiepNhanTuyenDung(int tuyenDungId, int statusTiepNhanId)
        {
            TuyenDung2021 tuyenDung2020 = registrationInterviewRepository.GetTuyenDungById(tuyenDungId);
            if (tuyenDung2020 == null)
            {
                return Json(new ReturnResult(404, "không tim thấy ứng viên", null), JsonRequestBehavior.AllowGet);
            }
            if (statusTiepNhanId == 99)
            {
                tuyenDung2020.TrangThaiHosoTuyenDungId = null;
            }
            else
            {
                tuyenDung2020.TrangThaiHosoTuyenDungId = statusTiepNhanId;
                
            }
            registrationInterviewRepository.CapNhatTuyenDung(tuyenDung2020);

            return Json(new ReturnResult(200, "success", null), JsonRequestBehavior.AllowGet);
        }


        [Route("canbothamgiahoidongthi", Name = "canbothamgiahoidongthi")]
        [HttpGet]
        public ActionResult TruongNhapCanBoThamGia()
        {
            School accountSchool = (School)Session[Utils.Constants.USER_SCHOOL_SESSION];
            if (accountSchool == null)
            {
                return RedirectToRoute("loginsoption");
            }
            ViewBag.TruongNhiemVuThamGiaHDTDs = truongNhiemVuThamGiaHDTDRepository.GetNhiemVuThamGiaHDTDsBySchoolId(accountSchool.Id);
            return View();
        }
        [Route("capnhatcanbothamgiahoidong", Name = "capnhatcanbothamgiahoidong")]
        [HttpPost]
        
        public ActionResult CapNhatCanBoThamGiaHoiDong(string canBoThamGiaHoiDongDTO)
        {
            School accountSchool = (School)Session[Utils.Constants.USER_SCHOOL_SESSION];
            if (accountSchool == null)
            {
                return Json(new ReturnResult(403, "access denied", null), JsonRequestBehavior.AllowGet);
            }
            List<CanBoThamGiaHoiDongDTO> canBoThamGiaHoiDongDTOs = JsonConvert.DeserializeObject<List<CanBoThamGiaHoiDongDTO>>(canBoThamGiaHoiDongDTO) as List<CanBoThamGiaHoiDongDTO>;
            List<TruongNhiemVuThamGiaHDTD> truongNhiemVuThamGiaHDTDs = new List<TruongNhiemVuThamGiaHDTD>(); 
            foreach (var item in canBoThamGiaHoiDongDTOs)
            {
                TruongNhiemVuThamGiaHDTD truongNhiemVuThamGiaHDTD = new TruongNhiemVuThamGiaHDTD();
                Mapper.Map(item, truongNhiemVuThamGiaHDTD);
                truongNhiemVuThamGiaHDTD.SchoolId = accountSchool.Id;
                truongNhiemVuThamGiaHDTDs.Add(truongNhiemVuThamGiaHDTD);
            }

            bool flag = truongNhiemVuThamGiaHDTDRepository.UpdateTruongNhiemVuThamGiaHDTD(truongNhiemVuThamGiaHDTDs);
            if (flag)
            {
                return Json(new ReturnResult(200, "success", null), JsonRequestBehavior.AllowGet);
            }
            return Json(new ReturnResult(400, "failed", null), JsonRequestBehavior.AllowGet);
        }
        [Route("indanhsachthamgiahoidongtuyendung")]
        public ActionResult InDanhSachThamGiaHDTD()
        {
            School accountSchool = (School)Session[Utils.Constants.USER_SCHOOL_SESSION];
            if (accountSchool == null)
            {
                return RedirectToRoute("loginsoption");
            }
            ViewBag.School = accountSchool;
            ViewBag.TruongNhiemVuThamGiaHDTDs = truongNhiemVuThamGiaHDTDRepository.GetNhiemVuThamGiaHDTDsBySchoolId(7852);
            return View();
        }
        }
}