using DataAccessAndBussinessLayer.Models.DAO;
using DataAccessAndBussinessLayer.Repositories.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;
using TCCB_ThuyenChuyen_TuyenDung.Models.DTO;

namespace TCCB_ThuyenChuyen_TuyenDung.Controllers
{
    public class DiaChiController : Controller
    {
        IWardRepository wardRepository;
        IDistrictRepository districtRepository;

        public DiaChiController(IWardRepository wardRepository, IDistrictRepository districtRepository)
        {
            this.wardRepository = wardRepository;
            this.districtRepository = districtRepository;
        }

        [Route("getWardByDistrictId/{id}")]
        [HttpGet]
        // GET: CommonsAPI
        public ActionResult GetWardByDistrictId(int id)
        {
            List<Ward> wards = wardRepository.GetWardByDistrictId(id);
            var wardsJson = JsonConvert.SerializeObject(wards,
            Formatting.None,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
            return Json(new ReturnResult(200, "success", wardsJson), JsonRequestBehavior.AllowGet);
        }

        [Route("getDistrictByProvinceId/{id}")]
        [HttpGet]
        public ActionResult GetDistrictByProvinceId(int id)
        {
            List<District> districts = districtRepository.GetDistrictByProvinceId(id);
            var districtsJson = JsonConvert.SerializeObject(districts,
          Formatting.None,
          new JsonSerializerSettings()
          {
              ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
          });
            return Json(new ReturnResult(200, "success", districtsJson), JsonRequestBehavior.AllowGet);
        }
    }
}