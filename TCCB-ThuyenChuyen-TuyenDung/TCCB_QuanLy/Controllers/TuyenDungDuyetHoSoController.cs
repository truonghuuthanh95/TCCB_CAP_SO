using AutoMapper;
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
    

    [RoutePrefix("tuyendung")]
    public class TuyenDungDuyetHoSoController : Controller
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
        IHoSoHopLeRepository hoSoHopLeRepository;

        public TuyenDungDuyetHoSoController(IRegistrationInterviewRepository registrationInterviewRepository, IProvinceRepository provinceRepository, IDistrictRepository districtRepository, IWardRepository wardRepository, IHinhThucDaoTaoRepository hinhThucDaoTaoRepository, IBangTotNghiepRepository bangTotNghiepRepository, IChuyenNganhDaoTaoRepository chuyenNganhDaoTaoRepository, ITrinhDoCaoNhatRepository trinhDoCaoNhatRepository, ILamViecTrongNganhRepository lamViecTrongNganhRepository, ITrinhDoTinHocRepository trinhDoTinHocRepository, ITrinhDoNgoaiNguRepository trinhDoNgoaiNguRepository, IMonDuTuyenRepository monDuTuyenRepository, IXepLoaiHocLucRepository xepLoaiHocLucRepository, ICapTruongRepository capTruongRepository, ITonGiaoRepository tonGiaoRepository, IDanTocRepository danTocRepository, IDoiTuongUuTienRepository doiTuongUuTienRepository, IThanhPhanBanThanHienTaiRepository thanhPhanBanThanHienTaiRepository, ITruongHopDacBietRepository truongHopDacBietRepository, ITrinhDoNgoaiNguKhacReposittory trinhDoNgoaiNguKhacReposittory, IChungChiNghiepVuSuPhamRepository chungChiNghiepVuSuPhamRepository, IHoSoHopLeRepository hoSoHopLeRepository)
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
            this.hoSoHopLeRepository = hoSoHopLeRepository;
        }






        //// GET: TuyenDungDuyetHoSo
        //[Route("duyethoso", Name ="duyethoso")]
        //public ActionResult DuyetHoSo()
        //{
        //    int permissionId = 7;
        //    Account account = (Account)Session[Utils.Constants.USER_SESSION];
        //    if (account == null)
        //    {
        //        return RedirectToRoute("login");
        //    }
        //    List<UserPermission> userPermission = (List<UserPermission>)Session[Utils.Constants.USER_PERMISSION_SESSION];
        //    if (userPermission.Where(s => s.PermissionId == permissionId).SingleOrDefault() == null)
        //    {
        //        return RedirectToRoute("login");
        //    }
        //    return View();
        //}

        //[Route("kiemtramaduyethople/{id}")]
        //public ActionResult KiemTraMaDuyetHopLe(string id)
        //{
        //    int permisstionId = 7;
        //    Account account = (Account)Session[Utils.Constants.USER_SESSION];
        //    if (account == null)
        //    {
        //        return Json(new ReturnResult(403, "Access denied", null), JsonRequestBehavior.AllowGet);
        //    }
        //    List<UserPermission> userPermission = (List<UserPermission>)Session[Utils.Constants.USER_PERMISSION_SESSION];
        //    if (userPermission.Where(s => s.PermissionId == permisstionId).SingleOrDefault() == null)
        //    {
        //        return Json(new ReturnResult(403, "Access denied", null), JsonRequestBehavior.AllowGet);
        //    }
        //    RegistrationInterview registrationInterview = registrationInterviewRepository.GetRegistrationInterviewByTienToId(id);
        //    if (registrationInterview == null)
        //    {
        //        return Json(new ReturnResult(404, "Không tìm thấy ứng viên với mã " + id, null), JsonRequestBehavior.AllowGet);
        //    }
        //    else if (registrationInterview.UpdatedAt == null)
        //    {
        //        return Json(new ReturnResult(404, "Hồ sơ với mã " + id + " chưa hoàn tất cập nhật", null), JsonRequestBehavior.AllowGet);
        //    }
        //    else if (registrationInterview.TrangThaiHosoTuyenDungId == 3)
        //    {
        //        return Json(new ReturnResult(400, "Hồ sơ " + id.ToUpper() +" bị từ chối bởi " + registrationInterview.Account1.LastName + " " + registrationInterview.Account1.FirstName + ". Lý do:  " + registrationInterview.LyDoTuChoi, null), JsonRequestBehavior.AllowGet);
        //    }
        //    else if (registrationInterview.TrangThaiHosoTuyenDungId == 1)
        //    {
        //        HoSoHopLe hoSoHopLe = hoSoHopLeRepository.GetHoSoHopLeByHoSoId(registrationInterview.Id);
        //        return Json(new ReturnResult(400, "Hồ sơ mã " + id.ToUpper() + " đã được tiếp nhận bởi " + registrationInterview.Account1.LastName + " " + registrationInterview.Account1.FirstName + " với mã vòng 2: " + hoSoHopLe.TienTo + hoSoHopLe.MaVong2, null), JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(new ReturnResult(200, "success", registrationInterview.Id), JsonRequestBehavior.AllowGet);           
        //}
        //[Route("duyethosochitiet/{id}")]
        //public ActionResult DuyetHoSoChiTiet(int id)
        //{
        //    int permissionId = 7;
        //    Account account = (Account)Session[Utils.Constants.USER_SESSION];
        //    if (account == null)
        //    {
        //        return RedirectToRoute("login");
        //    }
        //    List<UserPermission> userPermission = (List<UserPermission>)Session[Utils.Constants.USER_PERMISSION_SESSION];
        //    if (userPermission.Where(s => s.PermissionId == permissionId).SingleOrDefault() == null)
        //    {
        //        return RedirectToRoute("login");
        //    }
        //    RegistrationInterview registrationInterview = registrationInterviewRepository.GetRegistrationInterviewByIdWithDetail(id);
        //    if (registrationInterview == null || registrationInterview.TrangThaiHosoTuyenDungId == 3 || registrationInterview.TrangThaiHosoTuyenDungId == 1 || registrationInterview.UpdatedAt == null)
        //    {
        //        return RedirectToRoute("duyethoso");
        //    }
        //    List<Province> province = provinceRepository.GetProvinceByCountryId(237);
        //    List<District> nohnQuanHuyen = districtRepository.GetDistrictByProvinceId(registrationInterview.Ward.District.ProvinceId);
        //    List<Ward> nohnPhuongXa = wardRepository.GetWardByDistrictId(registrationInterview.Ward.DistrictID);
        //    List<District> hkttQuanHuyen = districtRepository.GetDistrictByProvinceId(registrationInterview.Ward1.District.ProvinceId);
        //    List<Ward> hkttPhuongXa = wardRepository.GetWardByDistrictId(registrationInterview.Ward1.DistrictID);
        //    List<HinhThucDaoTao> hinhThucDaoTaos = hinhThucDaoTaoRepository.GetHinhThucDaoTaos();
        //    List<BangTotNghiep> bangTotNghieps = bangTotNghiepRepository.GetBangTotNghieps();
        //    List<ChuyenNganhDaoTao> chuyenNganhDaoTaos = chuyenNganhDaoTaoRepository.GetChuyenNganhDaoTaos();
        //    List<TrinhDoCaoNhat> trinhDoCaoNhats = trinhDoCaoNhatRepository.GetTrinhDoCaoNhats();
        //    List<LamViecTrongNganh> lamViecTrongNganhs = lamViecTrongNganhRepository.GetLamViecTrongNganhs();
        //    List<TrinhDoTinHoc> trinhDoTinHocs = trinhDoTinHocRepository.GetTrinhDoTinHocs();
        //    List<TrinhDoNgoaiNgu> trinhDoNgoaiNgus = trinhDoNgoaiNguRepository.GetTrinhDoNgoaiNgus();
        //    List<MonDuTuyen> monDuTuyens = monDuTuyenRepository.GetMonDuTuyens();
        //    List<XepLoaiHocLuc> xepLoaiHocLucs = xepLoaiHocLucRepository.GetXepLoaiHocLucs();
        //    List<District> HCMDistrict = districtRepository.GetDistrictByProvinceId(79);
        //    CandidateModelInOneView candidateModelInOneView = new CandidateModelInOneView(province, nohnQuanHuyen, nohnPhuongXa, hkttQuanHuyen, hkttPhuongXa, registrationInterview, hinhThucDaoTaos, bangTotNghieps, trinhDoCaoNhats, chuyenNganhDaoTaos, lamViecTrongNganhs, trinhDoTinHocs, trinhDoNgoaiNgus, monDuTuyens, xepLoaiHocLucs, HCMDistrict);
        //    ViewBag.DoiTuongUuTiens = doiTuongUuTienRepository.GetDoiTuongUuTiens();
        //    ViewBag.TonGiaos = tonGiaoRepository.GetTonGiaos();
        //    ViewBag.DanTocs = danTocRepository.GetDanTocs();
        //    ViewBag.ThanhPhanBanThanHienTais = thanhPhanBanThanHienTaiRepository.GetThanhPhanBanThanHienTais();
        //    ViewBag.TruongHopDacBiets = truongHopDacBietRepository.GetTruongHopDacBiets();
        //    ViewBag.TrinhDoNgoaiNguKhas = trinhDoNgoaiNguKhacReposittory.GetTrinhDoNgoaiNguKhacs();
        //    ViewBag.ChungChiNghiepVuSuPhams = chungChiNghiepVuSuPhamRepository.GetChungChiNghiepVuSuPhams();
        //    return View(candidateModelInOneView);            
        //}
        //[Route("submitcapnhatduyet")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult SubmitCapNhatDuyet(int Id, RegistrationInterviewDTO registrationInterviewDTO, string ghiChuCanBoSung, int trangthaiId, string lyDoTuChoi)
        //{
        //    int permisstionId = 7;
        //    Account account = (Account)Session[Utils.Constants.USER_SESSION];
        //    if (account == null)
        //    {
        //        return Json(new ReturnResult(403, "Access denied", null), JsonRequestBehavior.AllowGet);
        //    }
        //    List<UserPermission> userPermission = (List<UserPermission>)Session[Utils.Constants.USER_PERMISSION_SESSION];
        //    if (userPermission.Where(s => s.PermissionId == permisstionId).SingleOrDefault() == null)
        //    {
        //        return Json(new ReturnResult(403, "Access denied", null), JsonRequestBehavior.AllowGet);
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        RegistrationInterview registrationInterview = registrationInterviewRepository.GetRegistrationInterviewById(Id);
        //        if (registrationInterview.TrangThaiHosoTuyenDungId == 1 || registrationInterview.TrangThaiHosoTuyenDungId == 3)
        //        {
        //            return Json(new ReturnResult(200, "Hò sơ đã được duyệt trước đó", null));
        //        }
        //        registrationInterview.NgayRaXoat = DateTime.Now;                
        //        if (trangthaiId == 2)
        //        {                    
        //            registrationInterview.GhiChu = ghiChuCanBoSung + " (vào lúc " + DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy") + ")";
        //        }
        //        else if (trangthaiId == 3)
        //        {                    
        //            registrationInterview.LyDoTuChoi = lyDoTuChoi + " (vào lúc " + DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy") + ")";
        //        }                
        //        registrationInterview.NguoiRaSoat = account.Id;
        //        registrationInterview.TrangThaiHosoTuyenDungId = trangthaiId;
        //        Mapper.Map(registrationInterviewDTO, registrationInterview);
        //        if (registrationInterviewDTO.IsNienChe == false)
        //        {
        //            registrationInterview.DiemLuanVan = null;
        //        }
        //        RegistrationInterview registrationInterviewAfterUpdated = registrationInterviewRepository.CapNhatRegistrationInterview(registrationInterview);
        //        if (registrationInterviewAfterUpdated == null)
        //        {
        //            return Json(new ReturnResult(400, "failed", null));
        //        }
        //        if (trangthaiId == 1)
        //        {

        //            HoSoHopLe hoSoHopLe = new HoSoHopLe();
        //            hoSoHopLe.CreatedAt = DateTime.Now;
        //            hoSoHopLe.TienTo = account.Code.Trim() + DateTime.Now.Year % 100 + "_";
        //            hoSoHopLe.HoSoId = registrationInterview.Id;
        //            HoSoHopLe hoSoHopCreated = hoSoHopLeRepository.CreateHoSoHopLe(hoSoHopLe);
        //            return Json(new ReturnResult(200, "Tiếp nhận mã hồ sơ " + registrationInterview.TienTo + registrationInterview.Id + " thành công với mã vòng 2: " + hoSoHopLe.TienTo + hoSoHopLe.MaVong2 , registrationInterviewAfterUpdated.Id));
        //        }
        //        else if (trangthaiId == 2)
        //        {
        //            return Json(new ReturnResult(200, "Ghi nhận cần bổ sung mã hồ sơ " + registrationInterview.TienTo + registrationInterview.Id + " thành công", registrationInterviewAfterUpdated.Id));
        //        }
        //        else if (trangthaiId == 3)
        //        {
        //            return Json(new ReturnResult(200, "Từ chối mã hồ sơ " + registrationInterview.TienTo + registrationInterview.Id + " thành công", registrationInterviewAfterUpdated.Id));
        //        }
                
        //    }
        //    return Json(new ReturnResult(400, "failed", null));
        //}
        //[Route("hosodaduyet")]
        //public ActionResult HoSoDaDuyet(int id)
        //{
        //    int permissionId = 7;
        //    Account account = (Account)Session[Utils.Constants.USER_SESSION];
        //    if (account == null)
        //    {
        //        return RedirectToRoute("login");
        //    }
        //    List<UserPermission> userPermission = (List<UserPermission>)Session[Utils.Constants.USER_PERMISSION_SESSION];
        //    if (userPermission.Where(s => s.PermissionId == permissionId).SingleOrDefault() == null)
        //    {
        //        return RedirectToRoute("login");
        //    }
        //    ViewBag.HoSoDaDuyets = registrationInterviewRepository.GetRegistrationInterviewsIsCheckByAccountId(account.Id);
        //    return View();
        //}
    }
}