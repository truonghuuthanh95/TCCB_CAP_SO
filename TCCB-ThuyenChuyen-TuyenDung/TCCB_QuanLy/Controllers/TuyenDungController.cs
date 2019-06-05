using AutoMapper;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TCCB_QuanLy.Models.DTO;
using System.Linq;
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

        public TuyenDungController(IRegistrationInterviewRepository registrationInterviewRepository, IProvinceRepository provinceRepository, IDistrictRepository districtRepository, IWardRepository wardRepository, IHinhThucDaoTaoRepository hinhThucDaoTaoRepository, IBangTotNghiepRepository bangTotNghiepRepository, IChuyenNganhDaoTaoRepository chuyenNganhDaoTaoRepository, ITrinhDoCaoNhatRepository trinhDoCaoNhatRepository, ILamViecTrongNganhRepository lamViecTrongNganhRepository, ITrinhDoTinHocRepository trinhDoTinHocRepository, ITrinhDoNgoaiNguRepository trinhDoNgoaiNguRepository, IMonDuTuyenRepository monDuTuyenRepository, IXepLoaiHocLucRepository xepLoaiHocLucRepository, ICapTruongRepository capTruongRepository, ITonGiaoRepository tonGiaoRepository, IDanTocRepository danTocRepository, IDoiTuongUuTienRepository doiTuongUuTienRepository, IThanhPhanBanThanHienTaiRepository thanhPhanBanThanHienTaiRepository, ITruongHopDacBietRepository truongHopDacBietRepository, ITrinhDoNgoaiNguKhacReposittory trinhDoNgoaiNguKhacReposittory)
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
        }



        // GET: TuyenDung
        [Route("capnhatphieudutuyen", Name = "capnhatphieudutuyen")]
        [HttpGet]
        public ActionResult KiemTraMaDangKi()
        {
            return View();
        }
        [Route("kiemtramadangki/{madangki}/{cmnd}")]
        [HttpGet]
        public ActionResult KiemTraMaDangKi(string madangki, string cmnd)
        {
            RegistrationInterview registrationInterview = registrationInterviewRepository.GetRegistrationInterviewByIdAndIdentifyCard(madangki.ToUpper(), cmnd.Trim());

            if (registrationInterview == null)
            {
                return Json(new ReturnResult(404, "Không tìm thấy ứng viên. Vui lòng kiểm tra lại số CMND hoặc mã hồ sơ", null), JsonRequestBehavior.AllowGet);
            }
            else if (registrationInterview.CreatedAt.Value.Year != DateTime.Now.Year || registrationInterview.NgayRaXoat != null || registrationInterview.IsActive == false)
            {
                return Json(new ReturnResult(404, "Hết hạn để sửa thông tin ứng tuyển", null), JsonRequestBehavior.AllowGet);
            }
            var registrationInterviewJson = JsonConvert.SerializeObject(registrationInterview,
            Formatting.None,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
            return Json(new ReturnResult(200, "success", null), JsonRequestBehavior.AllowGet);          
        }
        [Route("capnhathosoungtuyen/{madangki}/{cmnd}")]
        [HttpGet]
        public ActionResult CapNhatHoSoUngTuyen(string madangki, string cmnd)
        {
            RegistrationInterview registrationInterview = registrationInterviewRepository.GetRegistrationInterviewByIdAndIdentifyCard(madangki.ToUpper(), cmnd.Trim());
            if (registrationInterview == null || registrationInterview.CreatedAt.Value.Year != DateTime.Now.Year || registrationInterview.NguoiRaSoat != null || registrationInterview.IsActive == false)
            {
                return RedirectToRoute("capnhathosougtuyen");
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
            return View(candidateModelInOneView);
        }
        [Route("submitcapnhat")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitCapNhat(int Id, RegistrationInterviewDTO registrationInterviewDTO)
        {
            if (ModelState.IsValid)
            {
                RegistrationInterview registrationInterview = registrationInterviewRepository.GetRegistrationInterviewById(Id);
                registrationInterview.UpdatedAt = DateTime.Now;
                Mapper.Map(registrationInterviewDTO, registrationInterview);
                if (registrationInterviewDTO.IsNienChe == false)
                {
                    registrationInterview.DiemLuanVan = null;
                }
                RegistrationInterview registrationInterviewAfterUpdated = registrationInterviewRepository.CapNhatRegistrationInterview(registrationInterview);
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
            RegistrationInterview registrationInterview = registrationInterviewRepository.GetRegistrationInterviewByIdWithDetail(madangki);
            return View(registrationInterview);           
        }

        [Route("trangthaidangky")]
        [HttpGet]
        public ActionResult TrangThaiDangKy()
        {
            List<RegistrationInterviewStatusRegistedCountDTO> registration = registrationInterviewRepository.GetSoluongDangkyTheoViTriUngTuyen();
            List<MonDuTuyen> mondutuyens = monDuTuyenRepository.GetMonDuTuyens();
            var registrationRegistedStatus = (from s1 in registration join s2 in mondutuyens on Convert.ToInt32(s1.ViTriUngTuyen) equals s2.Id select new RegistrationInterviewStatusRegistedCountDTO { ViTriUngTuyen = s2.ViTriUngTuyen.Name + " " + s2.Name, Quantity = s1.Quantity, Targets = s2.Targets });
            
            //var registrationRegistedStatus = (from p in mondutuyens from s in registration where Convert.ToInt32(s.Quantity) == p.Id select new RegistrationInterviewStatusRegistedCountDTO { ViTriUngTuyen = p.ViTriUngTuyen.Name + " " + p.Name, Quantity = s.Quantity, Targets = p.Targets });
            //var b = (from s1 in mondutuyens join s2 in registration on s1.Id equals Convert.ToInt32(s2.ViTriUngTuyen) select new RegistrationInterviewStatusRegistedCountDTO { ViTriUngTuyen = s1.ViTriUngTuyen.Name + " " + s1.Name, Quantity = 0, Targets = s1.Targets } );
            var b = from s1 in mondutuyens where !registration.Any(s => Convert.ToInt32(s.ViTriUngTuyen) == s1.Id) select new RegistrationInterviewStatusRegistedCountDTO { ViTriUngTuyen = s1.ViTriUngTuyen.Name + " " + s1.Name, Quantity = 0, Targets = s1.Targets };
            var ab = registrationRegistedStatus.Concat(b).OrderBy(s => s.ViTriUngTuyen);
            ViewBag.RegistrationStatus = ab;
            return View();
        }


    }
}