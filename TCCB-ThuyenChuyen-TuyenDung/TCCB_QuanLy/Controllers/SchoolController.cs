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

        public SchoolController(ISchoolRepository schoolRepository, ICandidateSchoolRepository candidateSchoolRepository, IStatusTiepNhanRepository statusTiepNhanRepository)
        {
            this.schoolRepository = schoolRepository;
            this.candidateSchoolRepository = candidateSchoolRepository;
            this.statusTiepNhanRepository = statusTiepNhanRepository;
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

        [Route("truongquanlyungvien")]
        [HttpGet]
        public ActionResult TruongQuanLyUngVien()
        {
            AccountSchool accountSchool = (AccountSchool)Session[Utils.Constants.USER_SCHOOL_SESSION];
            if (accountSchool == null)
            {
                return RedirectToRoute("schoolLogin");
            }
            List<StatusTiepNhan> statusTiepNhans = statusTiepNhanRepository.GetStatusTiepNhans();
            List<CandidateSchool> candidateSchools = candidateSchoolRepository.GetCandidateBySchoolId(accountSchool.Id);
            ViewBag.CandidateSchools = candidateSchools;
            ViewBag.StatusTiepNhans = statusTiepNhans;
            return View();
        }

        [Route("postcapnhattiepnhan")]
        [HttpPost]
        public ActionResult PostCapNhatTiepNhan(int candidateSchoolId, int statusTiepNhanId, string ghiChu = "")
        {
            CandidateSchool candidateSchool = candidateSchoolRepository.GetCandidateSchoolById(candidateSchoolId);
            if (candidateSchool == null)
            {
                return Json(new ReturnResult(404, "không tim thấy ứng viên", null), JsonRequestBehavior.AllowGet);
            }
            candidateSchool.StatusTiepNhanId = statusTiepNhanId;
            candidateSchool.GhiChu = ghiChu;
            candidateSchoolRepository.UpdateStatusCandidate(candidateSchool);
            return Json(new ReturnResult(200, "success", null), JsonRequestBehavior.AllowGet);
        }
    }
}