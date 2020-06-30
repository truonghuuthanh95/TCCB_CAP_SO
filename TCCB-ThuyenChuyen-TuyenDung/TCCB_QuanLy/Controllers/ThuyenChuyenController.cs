﻿using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Models.DTO;
using TCCB_QuanLy.Repositories.Interfaces;
using TCCB_QuanLy.Services;

namespace TCCB_QuanLy.Controllers
{
    [RoutePrefix("thuyenchuyen")]
    public class ThuyenChuyenController : Controller
    {
        IDistrictRepository _districtRepository;
        IWardRepository _wardRepository;
        IProvinceRepository _provinceRepository;
        IMonDuTuyenRepository _monDuTuyenRepository;
        ICapTruongRepository _capTruongRepository;
        IHinhThucDaoTaoRepository _hinhThucDaoTaoRepository;
        IXepLoaiHocLucRepository _xepLoaiHocLucRepository;
        IChuyenNganhDaoTaoRepository _chuyenNganhDaoTaoRepository;
        IBangTotNghiepRepository _bangTotNghiepRepository;
        ISchoolRepository _schoolRepository;
        ITrinhDoCaoNhatRepository _trinhDoCaoNhatRepository;
        IThuyenChuyenRepository _thuyenChuyenRepository;

        public ThuyenChuyenController(IDistrictRepository districtRepository, IWardRepository wardRepository, IProvinceRepository provinceRepository, IMonDuTuyenRepository monDuTuyenRepository, ICapTruongRepository capTruongRepository, IHinhThucDaoTaoRepository hinhThucDaoTaoRepository, IXepLoaiHocLucRepository xepLoaiHocLucRepository, IChuyenNganhDaoTaoRepository chuyenNganhDaoTaoRepository, IBangTotNghiepRepository bangTotNghiepRepository, ISchoolRepository schoolRepository, ITrinhDoCaoNhatRepository trinhDoCaoNhatRepository, IThuyenChuyenRepository thuyenChuyenRepository)
        {
            _districtRepository = districtRepository;
            _wardRepository = wardRepository;
            _provinceRepository = provinceRepository;
            _monDuTuyenRepository = monDuTuyenRepository;
            _capTruongRepository = capTruongRepository;
            _hinhThucDaoTaoRepository = hinhThucDaoTaoRepository;
            _xepLoaiHocLucRepository = xepLoaiHocLucRepository;
            _chuyenNganhDaoTaoRepository = chuyenNganhDaoTaoRepository;
            _bangTotNghiepRepository = bangTotNghiepRepository;
            _schoolRepository = schoolRepository;
            _trinhDoCaoNhatRepository = trinhDoCaoNhatRepository;
            _thuyenChuyenRepository = thuyenChuyenRepository;
        }

        [Route("option")]
        [HttpGet]
        public ActionResult Option()
        {
            
                ViewBag.Districts = _districtRepository.GetDistrictByProvinceId(79);
            
                ViewBag.Wards = _wardRepository.GetWardByDistrictId(760);
            
                ViewBag.Provinces = _provinceRepository.GetProvinceByCountryId(237);
            
                ViewBag.CapTruongs = _capTruongRepository.GetCapTruongs();
          
                ViewBag.MonDays = _monDuTuyenRepository.GetMonDuTuyens();
            
                ViewBag.HinhThucDaoTaos = _hinhThucDaoTaoRepository.GetHinhThucDaoTaos();
           
                ViewBag.XepLoaiHocLucs = _xepLoaiHocLucRepository.GetXepLoaiHocLucs();
            
                ViewBag.ChuyenNganhDaoTaos = _chuyenNganhDaoTaoRepository.GetChuyenNganhDaoTaos();
            
                ViewBag.BangTotNghieps = _bangTotNghiepRepository.GetBangTotNghieps();
           
                ViewBag.Schools = _schoolRepository.GetSchoolsByDistrictAndCapHoc(760, 4);
         
                ViewBag.TrinhDoCaoNhats = _trinhDoCaoNhatRepository.GetTrinhDoCaoNhats();

            return View();
        }

        [Route("create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKiMoiPost(ThuyenChuyenDTO2020 thuyenChuyenDTO)
        {
            if (ModelState.IsValid)
            {
                ThuyenChuyen2020 thuyenChuyen = new ThuyenChuyen2020();
                Mapper.Map(thuyenChuyenDTO, thuyenChuyen);
                thuyenChuyen.TienTo = "TC";
                ThuyenChuyen2020 thuyenChuyenCreated = _thuyenChuyenRepository.CreateThuyenChuyen(thuyenChuyen);
                
                return Json(new ReturnResult(200, "success", thuyenChuyen.Id), JsonRequestBehavior.AllowGet);

            }
            return Json(new ReturnResult(400, "failed", null), JsonRequestBehavior.AllowGet);
        }

        [Route("dangkithanhcong/{id}")]
        [HttpGet]
        public ActionResult DangKiThanhCong(int id)
        {
            
                ViewBag.ThuyenChuyen = _thuyenChuyenRepository.GetThuyenChuyensById(id);
                ViewBag.Id = id;
                return View();           

        }
        //[Route("capnhat/{id}/{cmnd}")]
        //[HttpGet]
        //public ActionResult CapNhatThuyenChuyen(string id, string cmnd)
        //{
        //    using (var _thuyenchuyenService = new ThuyenChuyenRepository())
        //    {
        //        ThuyenChuyen thuyenChuyen = _thuyenchuyenService.CheckThuyenChuyenExistedByIdAndCMND(id, cmnd);
        //        if (thuyenChuyen == null || (thuyenChuyen.StatusId != 5 && thuyenChuyen.StatusId != null))
        //        {
        //            return RedirectToRoute("thuyenchuyenkiemtramatruong");
        //        }

        //        using (var _districtService = new DistrictRepository())
        //        {
        //            ViewBag.DistrictsNoiSinh = _districtService.GetDistrictByProvinceId(thuyenChuyen.Ward.District.ProvinceId);
        //            ViewBag.DistrictsHKTT = _districtService.GetDistrictByProvinceId(thuyenChuyen.Ward1.District.ProvinceId);
        //            ViewBag.Districts = _districtService.GetDistrictByProvinceId(79);
        //        }
        //        using (var _wardService = new WardRepository())
        //        {
        //            ViewBag.WardsNoiSinh = _wardService.GetWardByDistrictId(thuyenChuyen.Ward.DistrictID);
        //            ViewBag.WardsHKTT = _wardService.GetWardByDistrictId(thuyenChuyen.Ward1.DistrictID);

        //        }
        //        using (var _provinceService = new ProvinceRepository())
        //        {
        //            ViewBag.Provinces = _provinceService.GetProvinceByCountryId(237);
        //        }
        //        using (var _CapTruongService = new CapTruongRepository())
        //        {
        //            ViewBag.CapTruongs = _CapTruongService.GetCapTruongs();
        //        }
        //        using (var _monDuTuyen = new MonDuTuyenRepository())
        //        {
        //            ViewBag.MonDays = _monDuTuyen.GetMonDuTuyens();
        //        }
        //        using (var _hinhThucDaoTao = new HinhThucDaoTaoRepository())
        //        {
        //            ViewBag.HinhThucDaoTaos = _hinhThucDaoTao.GetHinhThucDaoTaos();
        //        }
        //        using (var _xepLoaiHocLuc = new XepLoaiHocLucRepository())
        //        {
        //            ViewBag.XepLoaiHocLucs = _xepLoaiHocLuc.GetXepLoaiHocLucs();
        //        }
        //        using (var _chuyenNghanhDaoTao = new ChuyenNganhDaoTaoRepository())
        //        {
        //            ViewBag.ChuyenNganhDaoTaos = _chuyenNghanhDaoTao.GetChuyenNganhDaoTaos();
        //        }
        //        using (var _bangTotNghiep = new BangTotNghiepRepository())
        //        {
        //            ViewBag.BangTotNghieps = _bangTotNghiep.GetBangTotNghieps();
        //        }
        //        using (var _schoolService = new SchoolRepository())
        //        {
        //            ViewBag.SchoolsDCT = _schoolService.GetSchoolsByDistrictAndCapHoc(thuyenChuyen.School.Ward.DistrictID, thuyenChuyen.School.CapTruongId);
        //            ViewBag.SchoolsCD = _schoolService.GetSchoolsByDistrictAndCapHoc(thuyenChuyen.School1.Ward.DistrictID, thuyenChuyen.School1.CapTruongId);
        //        }
        //        using (var _trinhdoDaoTao = new TrinhDoCaoNhatRepository())
        //        {
        //            ViewBag.TrinhDoCaoNhats = _trinhdoDaoTao.GetTrinhDoCaoNhats();
        //        }
        //        ViewBag.ThuyenChuyen = thuyenChuyen;
        //        return View();
        //    }

        //}
        //[Route("capnhat/kiemtrama", Name ="thuyenchuyenkiemtramatruong")]
        //[HttpGet]
        //public ActionResult KiemTraMa()
        //{

        //    return View();
        //}
        //[Route("capnhat/kiemtramahoso/{madangki}/{cmnd}")]
        //[HttpGet]
        //public ActionResult KiemTraMaHopLe(string madangki, string cmnd)
        //{
        //    if (madangki.ToUpper().Contains("TCN"))
        //    {
        //        using (var _thuyenChuyenService = new ThuyenChuyenNgoaiTinhService())
        //        {
        //            ThuyenChuyenNgoaiTinh thuyenChuyen = _thuyenChuyenService.CheckThuyenChuyenExistedByIdAndCMND(madangki, cmnd);
        //            if (thuyenChuyen == null)
        //            {
        //                return Json(new ReturnResult(400, "Không tìm thấy", null), JsonRequestBehavior.AllowGet);

        //            }
        //            else if (thuyenChuyen.StatusId != null && thuyenChuyen.StatusId != 5)
        //            {
        //                return Json(new ReturnResult(400, "Hồ sơ đã được tiếp nhân. Do đó không được cập nhật", null), JsonRequestBehavior.AllowGet);
        //            }
        //            var thuyenChuyenJson = JsonConvert.SerializeObject(thuyenChuyen,
        //          Formatting.None,
        //          new JsonSerializerSettings()
        //          {
        //              ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        //          });
        //            return Json(new ReturnResult(200, "success", thuyenChuyenJson), JsonRequestBehavior.AllowGet);
        //        }

        //    }
        //    else if (madangki.ToUpper().Contains("TC"))
        //    {
        //        using (var _thuyenChuyenService = new ThuyenChuyenRepository())
        //        {
        //            ThuyenChuyen thuyenChuyen = _thuyenChuyenService.CheckThuyenChuyenExistedByIdAndCMND(madangki, cmnd);
        //            if (thuyenChuyen == null)
        //            {
        //                return Json(new ReturnResult(400, "Không tìm thấy", null), JsonRequestBehavior.AllowGet);

        //            }
        //            else if (thuyenChuyen.StatusId != null && thuyenChuyen.StatusId != 5)
        //            {
        //                return Json(new ReturnResult(400, "Hồ sơ đã được tiếp nhân. Do đó không được cập nhật", null), JsonRequestBehavior.AllowGet);
        //            }
        //            var thuyenChuyenJson = JsonConvert.SerializeObject(thuyenChuyen,
        //          Formatting.None,
        //          new JsonSerializerSettings()
        //          {
        //              ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        //          });
        //            return Json(new ReturnResult(200, "success", thuyenChuyenJson), JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    else
        //    {
        //        return Json(new ReturnResult(400, "Không tìm thấy", null), JsonRequestBehavior.AllowGet);
        //    }

        //}
        //[Route("capnhatPost")]
        //[HttpPost]
        //public ActionResult CapNhatPost(ThuyenChuyenDTO thuyenChuyenDTO, int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var _thuyenChuyenService = new ThuyenChuyenRepository())
        //        {
        //            ThuyenChuyen thuyenChuyen = _thuyenChuyenService.GetThuyenChuyensById(id);
        //            Mapper.Map(thuyenChuyenDTO, thuyenChuyen);
        //            ThuyenChuyen thuyenChuyenUpdated = _thuyenChuyenService.CapNhatThuyenChuyen(thuyenChuyen);
        //            if (thuyenChuyenUpdated == null)
        //            {
        //                return Json(new ReturnResult(400, "failed", null), JsonRequestBehavior.AllowGet);
        //            }
        //            return Json(new ReturnResult(200, "success", thuyenChuyenUpdated.Id), JsonRequestBehavior.AllowGet);
        //        }
        //    }

        //    return Json(new ReturnResult(400, "failed", null), JsonRequestBehavior.AllowGet);
        //}



        [Route("tiendogiaiquyethoso")]
        [HttpGet]
        public ActionResult TienDoHoSo()
        {

            return View();
        }
        //[Route("tiendogiaiquyethoso/{madangki}/{cmnd}")]
        //[HttpGet]
        //public ActionResult TienDoHoSoJson(string madangki, string cmnd)
        //{
        //    if (madangki.ToUpper().Contains("TCN"))
        //    {
        //        using (var _thuyenChuyenService = new ThuyenChuyenNgoaiTinhService())
        //        {
        //            ThuyenChuyenNgoaiTinh thuyenChuyen = _thuyenChuyenService.CheckThuyenChuyenExistedByIdAndCMND(madangki, cmnd);
        //            if (thuyenChuyen == null)
        //            {
        //                return Json(new ReturnResult(400, "Không tìm thấy", null), JsonRequestBehavior.AllowGet);

        //            }

        //            var thuyenChuyenJson = JsonConvert.SerializeObject(thuyenChuyen,
        //          Formatting.None,
        //          new JsonSerializerSettings()
        //          {
        //              ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        //          });
        //            return Json(new ReturnResult(200, "success", thuyenChuyenJson), JsonRequestBehavior.AllowGet);
        //        }

        //    }
        //    else if (madangki.ToUpper().Contains("TC"))
        //    {
        //        using (var _thuyenChuyenService = new ThuyenChuyenRepository())
        //        {
        //            ThuyenChuyen thuyenChuyen = _thuyenChuyenService.CheckThuyenChuyenExistedByIdAndCMND(madangki, cmnd);
        //            if (thuyenChuyen == null)
        //            {
        //                return Json(new ReturnResult(400, "Không tìm thấy", null), JsonRequestBehavior.AllowGet);

        //            }

        //            var thuyenChuyenJson = JsonConvert.SerializeObject(thuyenChuyen,
        //          Formatting.None,
        //          new JsonSerializerSettings()
        //          {
        //              ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        //          });
        //            return Json(new ReturnResult(200, "success", thuyenChuyenJson), JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    else
        //    {
        //        return Json(new ReturnResult(400, "Không tìm thấy", null), JsonRequestBehavior.AllowGet);
        //    }           
        //}

        //[Route("huongdan")]
        //[HttpGet]
        //public ActionResult HuongDan()
        //{
        //    return View();
        //}
        //[Route("hosomauvaquytrinh")]
        //[HttpGet]
        //public ActionResult HoSoMau()
        //{

        //    return View();
        //}
        //[Route("getbacluongbynhommangach")]
        //[HttpPost]
        //public ActionResult GetBacLuongByMaNgachId(string id)
        //{
        //    using (var _maNgachService = new MaNgachRepository())
        //    {
        //        string nhomMaNgach = _maNgachService.GetMaNgachById(id).Nhom;
        //        using (var _bacLuongService = new BacLuongRepository())
        //        {
        //            List<BacLuong> bacLuongs = _bacLuongService.GetBacLuongByNhomMaNgach(nhomMaNgach.Trim());
        //            var bacLuongsJson = JsonConvert.SerializeObject(bacLuongs,
        //          Formatting.None,
        //          new JsonSerializerSettings()
        //          {
        //              ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        //          });
        //            return Json(new ReturnResult(200, "success", bacLuongsJson), JsonRequestBehavior.AllowGet);
        //        }

        //    }

        //}
        //[Route("downloadtailieu/{tentailieu}")]
        //[HttpPost]
        //public ActionResult DownloadDocument(string tentailieu)
        //{            
        //    string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Utils/Files/" + tentailieu);           
        //    return File(filePath, "application/vnd.ms-excel", tentailieu);            
        //}

    }
}