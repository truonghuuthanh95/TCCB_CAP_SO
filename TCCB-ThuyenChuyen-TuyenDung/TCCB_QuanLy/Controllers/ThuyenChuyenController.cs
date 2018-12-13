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
    [RoutePrefix("thuyenchuyen")]
    public class ThuyenChuyenController : Controller
    {
        IDistrictRepository districtRepository;
        IWardRepository wardRepository;
        IProvinceRepository provinceRepository;
        ICapTruongRepository capTruongRepository;
        IMonDuTuyenRepository monDuTuyenRepository;
        IXepLoaiHocLucRepository xepLoaiHocLucRepository;
        IBangTotNghiepRepository bangTotNghiepRepository;
        IChuyenNganhDaoTaoRepository chuyenNganhDaoTaoRepository;
        IHinhThucDaoTaoRepository hinhThucDaoTaoRepository;
        ISchoolRepository schoolRepository;
        IThuyenChuyenRepository thuyenChuyenRepository;
        IMaNgachRepository maNgachRepository;
        IBacLuongRepository bacLuongRepository;
        ITrinhDoCaoNhatRepository trinhDoCaoNhatRepository;

        public ThuyenChuyenController(IDistrictRepository districtRepository, IWardRepository wardRepository, IProvinceRepository provinceRepository, ICapTruongRepository capTruongRepository, IMonDuTuyenRepository monDuTuyenRepository, IXepLoaiHocLucRepository xepLoaiHocLucRepository, IBangTotNghiepRepository bangTotNghiepRepository, IChuyenNganhDaoTaoRepository chuyenNganhDaoTaoRepository, IHinhThucDaoTaoRepository hinhThucDaoTaoRepository, ISchoolRepository schoolRepository, IThuyenChuyenRepository thuyenChuyenRepository, IMaNgachRepository maNgachRepository, IBacLuongRepository bacLuongRepository, ITrinhDoCaoNhatRepository trinhDoCaoNhatRepository)
        {
            this.districtRepository = districtRepository;
            this.wardRepository = wardRepository;
            this.provinceRepository = provinceRepository;
            this.capTruongRepository = capTruongRepository;
            this.monDuTuyenRepository = monDuTuyenRepository;
            this.xepLoaiHocLucRepository = xepLoaiHocLucRepository;
            this.bangTotNghiepRepository = bangTotNghiepRepository;
            this.chuyenNganhDaoTaoRepository = chuyenNganhDaoTaoRepository;
            this.hinhThucDaoTaoRepository = hinhThucDaoTaoRepository;
            this.schoolRepository = schoolRepository;
            this.thuyenChuyenRepository = thuyenChuyenRepository;
            this.maNgachRepository = maNgachRepository;
            this.bacLuongRepository = bacLuongRepository;
            this.trinhDoCaoNhatRepository = trinhDoCaoNhatRepository;
        }



        // GET: ThuyenChuyen
        [Route("dangkimoi")]
        [HttpGet]
        public ActionResult DangKimoi()
        {
            ViewBag.Districts = districtRepository.GetDistrictByProvinceId(79);
            ViewBag.Wards = wardRepository.GetWardByDistrictId(760);
            ViewBag.Provinces = provinceRepository.GetProvinceByCountryId(237);
            ViewBag.CapTruongs = capTruongRepository.GetCapTruongs();
            ViewBag.MonDays = monDuTuyenRepository.GetMonDuTuyens();
            ViewBag.HinhThucDaoTaos = hinhThucDaoTaoRepository.GetHinhThucDaoTaos();
            ViewBag.XepLoaiHocLucs = xepLoaiHocLucRepository.GetXepLoaiHocLucs();
            ViewBag.ChuyenNganhDaoTaos = chuyenNganhDaoTaoRepository.GetChuyenNganhDaoTaos();
            ViewBag.BangTotNghieps = bangTotNghiepRepository.GetBangTotNghieps();
            ViewBag.Schools = schoolRepository.GetSchoolsByDistrictAndCapHoc(760, 4);
            ViewBag.TrinhDoCaoNhats = trinhDoCaoNhatRepository.GetTrinhDoCaoNhats();
            return View();
        }
        [Route("dangkimoiPost")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKiMoiPost(ThuyenChuyenDTO thuyenChuyenDTO)
        {
            if (ModelState.IsValid)
            {
                ThuyenChuyen thuyenChuyen = new ThuyenChuyen();
                Mapper.Map(thuyenChuyenDTO, thuyenChuyen);
                ThuyenChuyen thuyenChuyenCreated = thuyenChuyenRepository.CreateThuyenChuyen(thuyenChuyen);
                return Json(new ReturnResult(200, "success", thuyenChuyen.Id), JsonRequestBehavior.AllowGet);
            }
            return Json(new ReturnResult(400, "failed", null), JsonRequestBehavior.AllowGet);
        }
        [Route("dangkithanhcong/{id}")]
        [HttpGet]
        public ActionResult DangKiThanhCong(int id)
        {
            ViewBag.ThuyenChuyen = thuyenChuyenRepository.GetThuyenChuyensById(id);
            ViewBag.Id = id;
            return View();
        }
        [Route("capnhat/{id}/{cmnd}")]
        [HttpGet]
        public ActionResult CapNhatThuyenChuyen(int id, string cmnd)
        {
            ThuyenChuyen thuyenChuyen = thuyenChuyenRepository.checkThuyenChuyenExistedByIdAndCMND(id, cmnd);
            if (thuyenChuyen == null || thuyenChuyen.StatusId != null)
            {
                return RedirectToRoute("thuyenchuyenkiemtramatruong");
            }
            ViewBag.Districts = districtRepository.GetDistrictByProvinceId(79);
            ViewBag.DistrictsNoiSinh = districtRepository.GetDistrictByProvinceId(thuyenChuyen.Ward.District.ProvinceId);
            ViewBag.WardsNoiSinh = wardRepository.GetWardByDistrictId(thuyenChuyen.Ward.DistrictID);
            ViewBag.DistrictsHKTT = districtRepository.GetDistrictByProvinceId(thuyenChuyen.Ward.District.ProvinceId);
            ViewBag.WardsHKTT = wardRepository.GetWardByDistrictId(thuyenChuyen.Ward.DistrictID);            
            ViewBag.Provinces = provinceRepository.GetProvinceByCountryId(237);
            ViewBag.CapTruongs = capTruongRepository.GetCapTruongs();
            ViewBag.MonDays = monDuTuyenRepository.GetMonDuTuyens();
            ViewBag.HinhThucDaoTaos = hinhThucDaoTaoRepository.GetHinhThucDaoTaos();
            ViewBag.XepLoaiHocLucs = xepLoaiHocLucRepository.GetXepLoaiHocLucs();
            ViewBag.ChuyenNganhDaoTaos = chuyenNganhDaoTaoRepository.GetChuyenNganhDaoTaos();
            ViewBag.BangTotNghieps = bangTotNghiepRepository.GetBangTotNghieps();
            ViewBag.SchoolsDCT = schoolRepository.GetSchoolsByDistrictAndCapHoc(thuyenChuyen.School.Ward.DistrictID, thuyenChuyen.School.CapTruongId);
            ViewBag.SchoolsCD = schoolRepository.GetSchoolsByDistrictAndCapHoc(thuyenChuyen.School1.Ward.DistrictID, thuyenChuyen.School1.CapTruongId);
            ViewBag.TrinhDoCaoNhats = trinhDoCaoNhatRepository.GetTrinhDoCaoNhats();
            ViewBag.ThuyenChuyen = thuyenChuyen;
            return View();
        }
        [Route("capnhat/kiemtrama", Name ="thuyenchuyenkiemtramatruong")]
        [HttpGet]
        public ActionResult KiemTraMa()
        {

            return View();
        }
        [Route("capnhat/kiemtramahoso/{madangki}/{cmnd}")]
        [HttpGet]
        public ActionResult KiemTraMaHopLe(int madangki, string cmnd)
        {
            ThuyenChuyen thuyenChuyen = thuyenChuyenRepository.checkThuyenChuyenExistedByIdAndCMND(madangki, cmnd);
            if (thuyenChuyen == null)
            {
                return Json(new ReturnResult(400, "Không tìm thấy", null), JsonRequestBehavior.AllowGet);
                
            }
            else if (thuyenChuyen.StatusId != null && thuyenChuyen.StatusId != 1)
            {
                return Json(new ReturnResult(400, "Hồ sơ đã được tiếp nhân. Do đó không được cập nhật", null), JsonRequestBehavior.AllowGet);
            }
            return Json(new ReturnResult(200, "success", null), JsonRequestBehavior.AllowGet);
        }
        [Route("capnhatPost")]
        [HttpPost]
        public ActionResult CapNhatPost(ThuyenChuyenDTO thuyenChuyenDTO, int id)
        {
            if (ModelState.IsValid)
            {
                ThuyenChuyen thuyenChuyen = thuyenChuyenRepository.GetThuyenChuyensById(id);
                Mapper.Map(thuyenChuyenDTO, thuyenChuyen);
                ThuyenChuyen thuyenChuyenUpdated = thuyenChuyenRepository.CapNhatThuyenChuyen(thuyenChuyen);
                if (thuyenChuyenUpdated == null)
                {
                    return Json(new ReturnResult(400, "failed", null), JsonRequestBehavior.AllowGet);
                }
                return Json(new ReturnResult(200, "success", thuyenChuyenUpdated.Id), JsonRequestBehavior.AllowGet);
            }
            return Json(new ReturnResult(400, "failed", null), JsonRequestBehavior.AllowGet);
        }

        [Route("tiendohoso")]
        [HttpGet]
        public ActionResult TienDoHoSo()
        {
            return View();
        }

        [Route("huongdan")]
        [HttpGet]
        public ActionResult HuongDan()
        {
            return View();
        }
        [Route("hosomauvaquytrinh")]
        [HttpGet]
        public ActionResult HoSoMau()
        {

            return View();
        }
        [Route("getbacluongbynhommangach")]
        [HttpPost]
        public ActionResult GetBacLuongByMaNgachId(string id)
        {
            string nhomMaNgach = maNgachRepository.GetMaNgachById(id).Nhom;
            List<BacLuong> bacLuongs = bacLuongRepository.GetBacLuongByNhomMaNgach(nhomMaNgach.Trim());
            var bacLuongsJson = JsonConvert.SerializeObject(bacLuongs,
          Formatting.None,
          new JsonSerializerSettings()
          {
              ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
          });
            return Json(new ReturnResult(200, "success", bacLuongsJson), JsonRequestBehavior.AllowGet);      
        }

    }
}