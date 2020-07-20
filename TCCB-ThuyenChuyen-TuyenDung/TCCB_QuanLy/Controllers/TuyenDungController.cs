using AutoMapper;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TCCB_QuanLy.Models.DTO;
using System.Linq;
using System.Threading.Tasks;

namespace TCCB_QuanLy.Controllers
{
    [RoutePrefix("tuyendung")]
    public class TuyenDungController : Controller
    {
        IRegistrationInterviewRepository registrationInterviewRepository;
        IProvinceRepository provinceRepository;
        IDistrictRepository districtRepository;
        IWardRepository wardRepository;       
        IHinhThucDaoTaoRepository hinhThucDaoTaoRepository;       
        IBangTotNghiepRepository bangTotNghiepRepository;       
        IChuyenNganhDaoTaoRepository chuyenNganhDaoTaoRepository;       
        ITrinhDoCaoNhatRepository trinhDoCaoNhatRepository;      
        ILamViecTrongNganhRepository lamViecTrongNganhRepository;
        ITrinhDoTinHocRepository trinhDoTinHocRepository;        
        ITrinhDoNgoaiNguRepository trinhDoNgoaiNguRepository;      
        IMonDuTuyenRepository monDuTuyenRepository;      
        IXepLoaiHocLucRepository xepLoaiHocLucRepository;     
        ICapTruongRepository capTruongRepository;
        ITonGiaoRepository tonGiaoRepository;
        IDanTocRepository danTocRepository;
        IDoiTuongUuTienRepository doiTuongUuTienRepository;
        IThanhPhanBanThanHienTaiRepository thanhPhanBanThanHienTaiRepository;
        ITruongHopDacBietRepository truongHopDacBietRepository;
        ITrinhDoNgoaiNguKhacReposittory trinhDoNgoaiNguKhacReposittory;
        IChungChiNghiepVuSuPhamRepository chungChiNghiepVuSuPhamRepository;
        IDiemThiTuyenRepository diemThiTuyenRepository;
        ITruongMonDuTuyenRepository truongMonDuTuyenRepository;

        public TuyenDungController(IRegistrationInterviewRepository registrationInterviewRepository, IProvinceRepository provinceRepository, IDistrictRepository districtRepository, IWardRepository wardRepository, IHinhThucDaoTaoRepository hinhThucDaoTaoRepository, IBangTotNghiepRepository bangTotNghiepRepository, IChuyenNganhDaoTaoRepository chuyenNganhDaoTaoRepository, ITrinhDoCaoNhatRepository trinhDoCaoNhatRepository, ILamViecTrongNganhRepository lamViecTrongNganhRepository, ITrinhDoTinHocRepository trinhDoTinHocRepository, ITrinhDoNgoaiNguRepository trinhDoNgoaiNguRepository, IMonDuTuyenRepository monDuTuyenRepository, IXepLoaiHocLucRepository xepLoaiHocLucRepository, ICapTruongRepository capTruongRepository, ITonGiaoRepository tonGiaoRepository, IDanTocRepository danTocRepository, IDoiTuongUuTienRepository doiTuongUuTienRepository, IThanhPhanBanThanHienTaiRepository thanhPhanBanThanHienTaiRepository, ITruongHopDacBietRepository truongHopDacBietRepository, ITrinhDoNgoaiNguKhacReposittory trinhDoNgoaiNguKhacReposittory, IChungChiNghiepVuSuPhamRepository chungChiNghiepVuSuPhamRepository, IDiemThiTuyenRepository diemThiTuyenRepository, ITruongMonDuTuyenRepository truongMonDuTuyenRepository)
        {
            this.registrationInterviewRepository = registrationInterviewRepository;
            this.provinceRepository = provinceRepository;
            this.districtRepository = districtRepository;
            this.wardRepository = wardRepository;
            this.hinhThucDaoTaoRepository = hinhThucDaoTaoRepository;
            this.bangTotNghiepRepository = bangTotNghiepRepository;
            this.chuyenNganhDaoTaoRepository = chuyenNganhDaoTaoRepository;
            this.trinhDoCaoNhatRepository = trinhDoCaoNhatRepository;
            this.lamViecTrongNganhRepository = lamViecTrongNganhRepository;
            this.trinhDoTinHocRepository = trinhDoTinHocRepository;
            this.trinhDoNgoaiNguRepository = trinhDoNgoaiNguRepository;
            this.monDuTuyenRepository = monDuTuyenRepository;
            this.xepLoaiHocLucRepository = xepLoaiHocLucRepository;
            this.capTruongRepository = capTruongRepository;
            this.tonGiaoRepository = tonGiaoRepository;
            this.danTocRepository = danTocRepository;
            this.doiTuongUuTienRepository = doiTuongUuTienRepository;
            this.thanhPhanBanThanHienTaiRepository = thanhPhanBanThanHienTaiRepository;
            this.truongHopDacBietRepository = truongHopDacBietRepository;
            this.trinhDoNgoaiNguKhacReposittory = trinhDoNgoaiNguKhacReposittory;
            this.chungChiNghiepVuSuPhamRepository = chungChiNghiepVuSuPhamRepository;
            this.diemThiTuyenRepository = diemThiTuyenRepository;
            this.truongMonDuTuyenRepository = truongMonDuTuyenRepository;
        }

        [Route("kiemtracmnd", Name = "kiemtracmnd")]
        [HttpGet]
        public ActionResult KiemTraCMND()
        {
            return View();
        }

        [Route("kiemtracmndPost")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostKiemTraCMND(string cmnd)
        {
            TuyenDung2020 tuyenDung = registrationInterviewRepository.GetTuyenDungByCMND(cmnd);
            if (tuyenDung != null)
            {
                return Json(new ReturnResult(200, "success", tuyenDung.IdentifyCard));
            }
            else
            {              
                return Json(new ReturnResult(404, "not found", cmnd));
                }          
        }


        // GET: TuyenDung
        [Route("kiemtramadangki/{cmnd}", Name = "kiemtramadangki")]
        [HttpGet]
        public ActionResult KiemTraMaDangKi(string cmnd)
        {
            TuyenDung2020 tuyenDung = registrationInterviewRepository.GetTuyenDungByCMND(cmnd.Trim());
            if (tuyenDung == null)
            {
                return RedirectToRoute("kiemtracmnd");
            }
            ViewBag.CMND = cmnd;
            return View();
        }

        [Route("kiemtramadangkicmnd/{madangki}/{cmnd}")]
        [HttpGet]
        public ActionResult KiemTraMaDangKi(string madangki, string cmnd)
        {
            TuyenDung2020 registrationInterview = registrationInterviewRepository.GetTuyenDungByIdAndIdentifyCard(madangki.ToUpper(), cmnd.Trim());

            if (registrationInterview == null)
            {
                return Json(new ReturnResult(404, "Sai mã đăng kí", null), JsonRequestBehavior.AllowGet);
            }
            
            //var registrationInterviewJson = JsonConvert.SerializeObject(registrationInterview,
            //Formatting.None,
            //new JsonSerializerSettings()
            //{
            //    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //});
            return Json(new ReturnResult(200, "success", null), JsonRequestBehavior.AllowGet);
        }
        [Route("taomoihosoungtuyen/{cmnd}")]
        [HttpGet]
        public ActionResult TaoMoiHoSoUngTuyen(string cmnd)
        {
            TuyenDung2020 tuyenDung = registrationInterviewRepository.GetTuyenDungByCMND(cmnd.Trim());
            if (tuyenDung != null)
            {
                return RedirectToRoute("kiemtracmnd");
            }
            List<Province> province = provinceRepository.GetProvinceByCountryId(237);
            List<District> nohnQuanHuyen = districtRepository.GetDistrictByProvinceId(79);
            List<Ward> nohnPhuongXa = wardRepository.GetWardByDistrictId(nohnQuanHuyen[0].Id);
            List<District> hkttQuanHuyen = districtRepository.GetDistrictByProvinceId(79);
            List<Ward> hkttPhuongXa = wardRepository.GetWardByDistrictId(hkttQuanHuyen[0].Id);
            List<HinhThucDaoTao> hinhThucDaoTaos = hinhThucDaoTaoRepository.GetHinhThucDaoTaos();
            List<BangTotNghiep> bangTotNghieps = bangTotNghiepRepository.GetBangTotNghieps();
            List<ChuyenNganhDaoTao> chuyenNganhDaoTaos = chuyenNganhDaoTaoRepository.GetChuyenNganhDaoTaos();
            List<TrinhDoCaoNhat> trinhDoCaoNhats = trinhDoCaoNhatRepository.GetTrinhDoCaoNhats();
            List<LamViecTrongNganh> lamViecTrongNganhs = lamViecTrongNganhRepository.GetLamViecTrongNganhs();
            List<TrinhDoTinHoc> trinhDoTinHocs = trinhDoTinHocRepository.GetTrinhDoTinHocs();
            List<TrinhDoNgoaiNgu> trinhDoNgoaiNgus = trinhDoNgoaiNguRepository.GetTrinhDoNgoaiNgus();
            List<MonDuTuyen> monDuTuyens = monDuTuyenRepository.GetMonDuTuyens();
            List<XepLoaiHocLuc> xepLoaiHocLucs = xepLoaiHocLucRepository.GetXepLoaiHocLucs();
            List<District> HCMDistrict = districtRepository.GetDistrictByProvinceId(79);
            CandidateModelInOneView candidateModelInOneView = new CandidateModelInOneView(province, nohnQuanHuyen, nohnPhuongXa, hkttQuanHuyen, hkttPhuongXa, null, hinhThucDaoTaos, bangTotNghieps, trinhDoCaoNhats, chuyenNganhDaoTaos, lamViecTrongNganhs, trinhDoTinHocs, trinhDoNgoaiNgus, monDuTuyens, xepLoaiHocLucs, HCMDistrict);
            ViewBag.DoiTuongUuTiens = doiTuongUuTienRepository.GetDoiTuongUuTiens();
            ViewBag.ChungChiNghiepVuSuPhams = chungChiNghiepVuSuPhamRepository.GetChungChiNghiepVuSuPhams();
            ViewBag.TonGiaos = tonGiaoRepository.GetTonGiaos();
            ViewBag.DanTocs = danTocRepository.GetDanTocs();
            ViewBag.ThanhPhanBanThanHienTais = thanhPhanBanThanHienTaiRepository.GetThanhPhanBanThanHienTais();
            ViewBag.TruongHopDacBiets = truongHopDacBietRepository.GetTruongHopDacBiets();
            ViewBag.TrinhDoNgoaiNguKhas = trinhDoNgoaiNguKhacReposittory.GetTrinhDoNgoaiNguKhacs();
            ViewBag.CMND = cmnd;
            ViewBag.TruongMonDuTuyens = truongMonDuTuyenRepository.GetTruongByMonDuTuyen(monDuTuyens[0].Id);
            return View(candidateModelInOneView);
        }

        [Route("submittaomoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitTaoMoi(RegistrationInterviewDTO registrationInterviewDTO)
        {
            if (ModelState.IsValid)
            {
                TuyenDung2020 registrationInterview = new TuyenDung2020();
                
                registrationInterview.CreatedAt = DateTime.Now;
                Mapper.Map(registrationInterviewDTO, registrationInterview);
                if (registrationInterviewDTO.IsNienChe == false)
                {
                    registrationInterview.DiemLuanVan = null;
                }
                registrationInterview.TienTo = "TD";
                TuyenDung2020 registrationInterviewAfterUpdated = registrationInterviewRepository.TaoMoiUngVien(registrationInterview);
                if (registrationInterviewAfterUpdated == null)
                {
                    return Json(new ReturnResult(400, "failed", null));
                }
                return Json(new ReturnResult(200, "success", registrationInterviewAfterUpdated.Id));
            }
            return Json(new ReturnResult(400, "failed", null));
        }
        [Route("capnhathosoungtuyen/{madangki}/{cmnd}")]
        [HttpGet]
        public ActionResult CapNhatHoSoUngTuyen(string madangki, string cmnd)
        {
            TuyenDung2020 registrationInterview = registrationInterviewRepository.GetTuyenDungByIdAndIdentifyCard(madangki.ToUpper(), cmnd.Trim());
            if (registrationInterview == null)
            {
                return RedirectToRoute("kiemtracmnd");
            }
            List<Province> province = provinceRepository.GetProvinceByCountryId(237);
            List<District> nohnQuanHuyen = districtRepository.GetDistrictByProvinceId(registrationInterview.Ward.District.ProvinceId);
            List<Ward> nohnPhuongXa = wardRepository.GetWardByDistrictId(registrationInterview.Ward.DistrictID);
            List<District> hkttQuanHuyen = districtRepository.GetDistrictByProvinceId(registrationInterview.Ward1.District.ProvinceId);
            List<Ward> hkttPhuongXa = wardRepository.GetWardByDistrictId(registrationInterview.Ward1.DistrictID);
            List<HinhThucDaoTao> hinhThucDaoTaos = hinhThucDaoTaoRepository.GetHinhThucDaoTaos();
            List<BangTotNghiep> bangTotNghieps = bangTotNghiepRepository.GetBangTotNghieps();
            List<ChuyenNganhDaoTao> chuyenNganhDaoTaos = chuyenNganhDaoTaoRepository.GetChuyenNganhDaoTaos();
            List<TrinhDoCaoNhat> trinhDoCaoNhats = trinhDoCaoNhatRepository.GetTrinhDoCaoNhats();
            List<LamViecTrongNganh> lamViecTrongNganhs = lamViecTrongNganhRepository.GetLamViecTrongNganhs();
            List<TrinhDoTinHoc> trinhDoTinHocs = trinhDoTinHocRepository.GetTrinhDoTinHocs();
            List<TrinhDoNgoaiNgu> trinhDoNgoaiNgus = trinhDoNgoaiNguRepository.GetTrinhDoNgoaiNgus();
            List<MonDuTuyen> monDuTuyens = monDuTuyenRepository.GetMonDuTuyens();
            List<XepLoaiHocLuc> xepLoaiHocLucs = xepLoaiHocLucRepository.GetXepLoaiHocLucs();
            List<District> HCMDistrict = districtRepository.GetDistrictByProvinceId(79);
            CandidateModelInOneView candidateModelInOneView = new CandidateModelInOneView(province, nohnQuanHuyen, nohnPhuongXa, hkttQuanHuyen, hkttPhuongXa, registrationInterview, hinhThucDaoTaos, bangTotNghieps, trinhDoCaoNhats, chuyenNganhDaoTaos, lamViecTrongNganhs, trinhDoTinHocs, trinhDoNgoaiNgus, monDuTuyens, xepLoaiHocLucs, HCMDistrict);
            ViewBag.DoiTuongUuTiens = doiTuongUuTienRepository.GetDoiTuongUuTiens();
            ViewBag.TonGiaos = tonGiaoRepository.GetTonGiaos();
            ViewBag.DanTocs = danTocRepository.GetDanTocs();
            ViewBag.ThanhPhanBanThanHienTais = thanhPhanBanThanHienTaiRepository.GetThanhPhanBanThanHienTais();
            ViewBag.TruongHopDacBiets = truongHopDacBietRepository.GetTruongHopDacBiets();
            ViewBag.TrinhDoNgoaiNguKhas = trinhDoNgoaiNguKhacReposittory.GetTrinhDoNgoaiNguKhacs();
            ViewBag.ChungChiNghiepVuSuPhams = chungChiNghiepVuSuPhamRepository.GetChungChiNghiepVuSuPhams();
            ViewBag.TruongMonDuTuyens = truongMonDuTuyenRepository.GetTruongByMonDuTuyen(registrationInterview.MonDuTuyenId);
            return View(candidateModelInOneView);
        }

        [Route("submitcapnhat")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitCapNhat(int Id, RegistrationInterviewDTO registrationInterviewDTO)
        {
            if (ModelState.IsValid)
            {
                TuyenDung2020 registrationInterview = registrationInterviewRepository.GetTuyenDungById(Id);
                
                registrationInterview.UpdatedAt = DateTime.Now;
                Mapper.Map(registrationInterviewDTO, registrationInterview);
                if (registrationInterviewDTO.IsNienChe == false)
                {
                    registrationInterview.DiemLuanVan = null;
                }
                TuyenDung2020 registrationInterviewAfterUpdated = registrationInterviewRepository.CapNhatTuyenDung(registrationInterview);
                if (registrationInterviewAfterUpdated == null)
                {
                    return Json(new ReturnResult(400, "failed", null));
                }
                return Json(new ReturnResult(200, "success", registrationInterviewAfterUpdated.Id));
            }
            return Json(new ReturnResult(400, "failed", null));
        }
        [Route("inhosoungtuyen/{madangki}")]
        [HttpGet]
        public ActionResult InHoSoUngTuyen(int madangki)
        {
            TuyenDung2020 registrationInterview = registrationInterviewRepository.GetTuyenDungByIdWithDetail(madangki);
            return View(registrationInterview);
        }

        [Route("downloadfile/{name}")]
        [HttpGet]
        public  ActionResult DownloadFile(string name)
        {              
            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Utils/ds-truong-tuyendung.xlsx");               
                return File(filePath, "application/vnd.ms-excel", "ds-truong-tuyendung.xlsx");
            
        }


        [Route("trangthaidangky")]
        [HttpGet]
        public ActionResult TrangThaiDangKy()
        {
            List<SoLuongDangKi> soLuongDangKis = registrationInterviewRepository.GetTinhHinhDangKi();
            ViewBag.TinhHinhDangKi = soLuongDangKis;
            ViewBag.MonDuTuyens = monDuTuyenRepository.GetMonDuTuyens();
            return View();
        }

        //[Route("ketquatuyendung")]
        //[HttpGet]
        //public ActionResult KetQuaTuyenDung()
        //{

        //    return View();
        //}
        //[Route("getdiemtuyendung/{cmnd}/{mavong2}")]
        //[HttpGet]
        //public ActionResult GetDiemTuyenDung(string cmnd, string mavong2)
        //{

        //    string dateValidShowResultTuyenDung = System.Configuration.ConfigurationManager.AppSettings["DateValidShowResultTuyenDung"];
        //    DateTime dateShowResult = DateTime.Parse(dateValidShowResultTuyenDung);
        //    if (DateTime.Now < dateShowResult)
        //    {
        //        return Json(new ReturnResult(400, "Chưa tới ngày công bố kết quả", null), JsonRequestBehavior.AllowGet);
        //    }
        //    DiemThiTuyen diemThiTuyen = diemThiTuyenRepository.GetDiemThiTuyenByMaVong2AndCmnd(mavong2.Trim(), cmnd.Trim());
        //    if (diemThiTuyen == null)
        //    {
        //        return Json(new ReturnResult(404, "Không tìm thấy vui lòng kiểm tra lại", null), JsonRequestBehavior.AllowGet);
        //    }
        //    var diemThiTuyenJson = JsonConvert.SerializeObject(diemThiTuyen,
        //          Formatting.None,
        //          new JsonSerializerSettings()
        //          {
        //              ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        //          });
        //    return Json(new ReturnResult(200, "success", diemThiTuyenJson), JsonRequestBehavior.AllowGet);

        //}
    }
}