﻿using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Models.DTO;
using TCCB_QuanLy.Services;

namespace TCCB_QuanLy.Controllers
{
    [RoutePrefix("thuyenchuyenngoaitinh")]
    public class ThuyenChuyenNgoaiTinhController : Controller
    {
        // GET: ThuuyenChuyenNgoaiTinh
        [Route("dangkimoi")]
        public ActionResult Index()
        {
            using (var _districtService = new DistrictRepository())
            {
                ViewBag.Districts = _districtService.GetDistrictByProvinceId(79);
            }
            using (var _wardService = new WardRepository())
            {
                ViewBag.Wards = _wardService.GetWardByDistrictId(760);
            }
            using (var _provinceService = new ProvinceRepository())
            {
                ViewBag.Provinces = _provinceService.GetProvinceByCountryId(237);
            }
            using (var _CapTruongService = new CapTruongRepository())
            {
                ViewBag.CapTruongs = _CapTruongService.GetCapTruongs();
            }
            using (var _monDuTuyen = new MonDuTuyenRepository())
            {
                ViewBag.MonDays = _monDuTuyen.GetMonDuTuyens();
            }
            using (var _hinhThucDaoTao = new HinhThucDaoTaoRepository())
            {
                ViewBag.HinhThucDaoTaos = _hinhThucDaoTao.GetHinhThucDaoTaos();
            }
            using (var _xepLoaiHocLuc = new XepLoaiHocLucRepository())
            {
                ViewBag.XepLoaiHocLucs = _xepLoaiHocLuc.GetXepLoaiHocLucs();
            }
            using (var _chuyenNghanhDaoTao = new ChuyenNganhDaoTaoRepository())
            {
                ViewBag.ChuyenNganhDaoTaos = _chuyenNghanhDaoTao.GetChuyenNganhDaoTaos();
            }
            using (var _bangTotNghiep = new BangTotNghiepRepository())
            {
                ViewBag.BangTotNghieps = _bangTotNghiep.GetBangTotNghieps();
            }
            using (var _schoolService = new SchoolRepository())
            {
                ViewBag.Schools = _schoolService.GetSchoolsByDistrictAndCapHoc(760, 4);
            }
            using (var _trinhdoDaoTao = new TrinhDoCaoNhatRepository())
            {
                ViewBag.TrinhDoCaoNhats = _trinhdoDaoTao.GetTrinhDoCaoNhats();
            }
            
            return View();
        }
        [Route("dangkimoiPost")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKiMoiPost(ThuyenChuyenNgoaiTinhDTO thuyenChuyenDTO)
        {
            if (ModelState.IsValid)
            {
                ThuyenChuyenNgoaiTinh thuyenChuyen = new ThuyenChuyenNgoaiTinh();
                Mapper.Map(thuyenChuyenDTO, thuyenChuyen);
                using (var _thuyenChuyenNgoaiTinhService = new ThuyenChuyenNgoaiTinhService())
                {
                    ThuyenChuyenNgoaiTinh thuyenChuyenCreated = _thuyenChuyenNgoaiTinhService.CreateThuyenChuyen(thuyenChuyen);
                    return Json(new ReturnResult(200, "success", thuyenChuyen.Id), JsonRequestBehavior.AllowGet);
                }

            }
            return Json(new ReturnResult(400, "failed", null), JsonRequestBehavior.AllowGet);
        }
        [Route("dangkithanhcong/{id}")]
        [HttpGet]
        public ActionResult DangKiThanhCong(int id)
        {
            using (var _thuyenChuyenService = new ThuyenChuyenNgoaiTinhService())
            {
                ViewBag.ThuyenChuyen = _thuyenChuyenService.GetThuyenChuyensById(id);
                ViewBag.Id = id;
                return View();
            }

        }
        [Route("capnhat/{id}/{cmnd}")]
        [HttpGet]
        public ActionResult CapNhatThuyenChuyen(string id, string cmnd)
        {
            using (var _thuyenchuyenService = new ThuyenChuyenNgoaiTinhService())
            {
                ThuyenChuyenNgoaiTinh thuyenChuyen = _thuyenchuyenService.CheckThuyenChuyenExistedByIdAndCMND(id.Trim(), cmnd.Trim());
                if (thuyenChuyen == null || (thuyenChuyen.StatusId != 5 && thuyenChuyen.StatusId != null))
                {
                    return RedirectToRoute("thuyenchuyenkiemtramatruong");
                }

                using (var _districtService = new DistrictRepository())
                {
                    ViewBag.DistrictsNoiSinh = _districtService.GetDistrictByProvinceId(thuyenChuyen.Ward.District.ProvinceId);
                    ViewBag.DistrictsHKTT = _districtService.GetDistrictByProvinceId(thuyenChuyen.Ward.District.ProvinceId);
                    ViewBag.Districts = _districtService.GetDistrictByProvinceId(79);
                }
                using (var _wardService = new WardRepository())
                {
                    ViewBag.WardsNoiSinh = _wardService.GetWardByDistrictId(thuyenChuyen.Ward.DistrictID);
                    ViewBag.WardsHKTT = _wardService.GetWardByDistrictId(thuyenChuyen.Ward.DistrictID);

                }
                using (var _provinceService = new ProvinceRepository())
                {
                    ViewBag.Provinces = _provinceService.GetProvinceByCountryId(237);
                }
                using (var _CapTruongService = new CapTruongRepository())
                {
                    ViewBag.CapTruongs = _CapTruongService.GetCapTruongs();
                }
                using (var _monDuTuyen = new MonDuTuyenRepository())
                {
                    ViewBag.MonDays = _monDuTuyen.GetMonDuTuyens();
                }
                using (var _hinhThucDaoTao = new HinhThucDaoTaoRepository())
                {
                    ViewBag.HinhThucDaoTaos = _hinhThucDaoTao.GetHinhThucDaoTaos();
                }
                using (var _xepLoaiHocLuc = new XepLoaiHocLucRepository())
                {
                    ViewBag.XepLoaiHocLucs = _xepLoaiHocLuc.GetXepLoaiHocLucs();
                }
                using (var _chuyenNghanhDaoTao = new ChuyenNganhDaoTaoRepository())
                {
                    ViewBag.ChuyenNganhDaoTaos = _chuyenNghanhDaoTao.GetChuyenNganhDaoTaos();
                }
                using (var _bangTotNghiep = new BangTotNghiepRepository())
                {
                    ViewBag.BangTotNghieps = _bangTotNghiep.GetBangTotNghieps();
                }
                using (var _schoolService = new SchoolRepository())
                {
                    
                    ViewBag.SchoolsCD = _schoolService.GetSchoolsByDistrictAndCapHoc(thuyenChuyen.School.Ward.DistrictID, thuyenChuyen.School.CapTruongId);
                }
                using (var _trinhdoDaoTao = new TrinhDoCaoNhatRepository())
                {
                    ViewBag.TrinhDoCaoNhats = _trinhdoDaoTao.GetTrinhDoCaoNhats();
                }
                ViewBag.ThuyenChuyen = thuyenChuyen;
                return View();
            }

        }       
        [Route("capnhat/kiemtramahoso/{madangki}/{cmnd}")]
        [HttpGet]
        public ActionResult KiemTraMaHopLe(string madangki, string cmnd)
        {
            using (var _thuyenChuyenService = new ThuyenChuyenNgoaiTinhService())
            {
                ThuyenChuyenNgoaiTinh thuyenChuyen = _thuyenChuyenService.CheckThuyenChuyenExistedByIdAndCMND(madangki.Trim(), cmnd.Trim());
                if (thuyenChuyen == null)
                {
                    return Json(new ReturnResult(400, "Không tìm thấy", null), JsonRequestBehavior.AllowGet);

                }
                else if (thuyenChuyen.StatusId != null && thuyenChuyen.StatusId != 5)
                {
                    return Json(new ReturnResult(400, "Hồ sơ đã được tiếp nhân. Do đó không được cập nhật", null), JsonRequestBehavior.AllowGet);
                }
                return Json(new ReturnResult(200, "success", null), JsonRequestBehavior.AllowGet);
            }

        }
        [Route("capnhatPost")]
        [HttpPost]
        public ActionResult CapNhatPost(ThuyenChuyenNgoaiTinhDTO thuyenChuyenDTO, int id)
        {
            if (ModelState.IsValid)
            {
                using (var _thuyenChuyenService = new ThuyenChuyenNgoaiTinhService())
                {
                    ThuyenChuyenNgoaiTinh thuyenChuyen = _thuyenChuyenService.GetThuyenChuyensById(id);
                    Mapper.Map(thuyenChuyenDTO, thuyenChuyen);
                    thuyenChuyen.UpdateAt = DateTime.Now;
                    ThuyenChuyenNgoaiTinh thuyenChuyenUpdated = _thuyenChuyenService.CapNhatThuyenChuyen(thuyenChuyen);                    
                    if (thuyenChuyenUpdated == null)
                    {
                        return Json(new ReturnResult(400, "failed", null), JsonRequestBehavior.AllowGet);
                    }
                    return Json(new ReturnResult(200, "success", thuyenChuyenUpdated.Id), JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new ReturnResult(400, "failed", null), JsonRequestBehavior.AllowGet);
        }
        [Route("capnhattrangthai/{maHoSo}/{trangThaiId}")]
        [HttpGet]
        public ActionResult CapNhatTrangThai(int maHoSo, int trangThaiId)
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


    }
}