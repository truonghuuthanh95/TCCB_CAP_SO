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

        public SchoolController(ISchoolRepository schoolRepository)
        {
            this.schoolRepository = schoolRepository;
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
    }
}