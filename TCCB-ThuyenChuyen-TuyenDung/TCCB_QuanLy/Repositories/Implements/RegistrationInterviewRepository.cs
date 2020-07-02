using System;
using System.Linq;
using TCCB_QuanLy.Repositories.Interfaces;
using TCCB_QuanLy.Models.DAO;
using System.Data.Entity;
using System.Collections.Generic;
using TCCB_QuanLy.Models.DTO;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class RegistrationInterviewRepository : IRegistrationInterviewRepository
    {
        TCCBDB _db;

        public RegistrationInterviewRepository(TCCBDB db)
        {
            _db = db;
        }

        public TuyenDung2020 GetTuyenDungById(int id)
        {
            TuyenDung2020 TuyenDung = _db.TuyenDung2020
               .SingleOrDefault(s => s.Id == id);

            return TuyenDung;
        }

        public TuyenDung2020 GetTuyenDungByIdAndIdentifyCard(string id, string identifyCard)
        {
            TuyenDung2020 TuyenDung = _db.TuyenDung2020
                .Include("Ward.District")
                .Include("Ward1.District")
                .SingleOrDefault(s => s.TienTo + s.Id.ToString() == id.ToUpper());
            if (TuyenDung == null || TuyenDung.IdentifyCard.Trim() != identifyCard)
            {
                return null;

            }
            return TuyenDung;

        }


        public TuyenDung2020 GetTuyenDungByIdWithDetail(int id)
        {
            TuyenDung2020 TuyenDung = _db.TuyenDung2020
                .Include("Ward.District.Province")
                .Include("Ward1.District.Province")
                .Include("BangTotNghiep")
                .Include("TrinhDoNgoaiNgu")
                .Include("XepLoaiHocLuc")
                .Include("TrinhDoCaoNhat")
                .Include("TrinhDoTinHoc")
                .Include("ChuyenNganhDaoTao")
                .Include("LamViecTrongNganh")
                .Include("MonDuTuyen.ViTriUngTuyen")
                .Include("HinhThucDaoTao")
                .Include("Province")
                
                .Include("TonGiao")
                .Include("DanToc")
                .Include("ThanhPhanBanThanHienTai")
                .Include("DoiTuongUuTien1")
                .Include("TruongHopDacBiet")
                .Include("TrinhDoNgoaiNguKhac")
                .Include("ChungChiNghiepVuSuPham")
                .Include("Province1")
                .Include("Province2")
                .Include("School")
                .SingleOrDefault(s => s.Id == id);
            return TuyenDung;
        }

        public TuyenDung2020 CapNhatTuyenDung(TuyenDung2020 TuyenDung)
        {
            _db.Entry(TuyenDung).State = EntityState.Modified;

            _db.SaveChanges();

            return TuyenDung;
        }

        public TuyenDung2020 TaoMoiUngVien(TuyenDung2020 TuyenDung)
        {
            _db.TuyenDung2020.Add(TuyenDung);
            _db.SaveChanges();
            return TuyenDung;


        }

        public List<TuyenDung2020> GetTuyenDungsByCmnd(string cmnd)
        {
            List<TuyenDung2020> TuyenDungs = _db.TuyenDung2020.Where(s => s.IdentifyCard.Trim() == cmnd.Trim()).OrderByDescending(s => s.CreatedAt).ToList();
            return TuyenDungs;
        }

        public int GetTuyenDungsDaDangkiSoLuong()
        {
            int count = _db.TuyenDung2020.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null)).Count();
            return count;
        }

        public List<TuyenDung2020> GetTuyenDungsDaDangKi()
        {
            List<TuyenDung2020> TuyenDungs = _db.TuyenDung2020.Include("Account").Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null)).ToList();
            return TuyenDungs;
        }

        public List<TuyenDung2020> GetTuyenDungsChuaCapNhat()
        {
            List<TuyenDung2020> TuyenDungs = _db.TuyenDung2020.Include("Account").Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null) && s.UpdatedAt == null).ToList();
            return TuyenDungs;
        }

        public List<TuyenDung2020> GetTuyenDungsDaHoanThanh()
        {
            List<TuyenDung2020> TuyenDungs = _db.TuyenDung2020.Include("Account").Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null) && s.UpdatedAt != null).ToList();
            return TuyenDungs;
        }
        public List<TuyenDung2020> GetTuyenDungsDaHoanThanhWithDetail()
        {
            List<TuyenDung2020> TuyenDungs = _db.TuyenDung2020
                .Include("Ward.District.Province")
                .Include("Ward1.District.Province")
                .Include("BangTotNghiep")
                .Include("TrinhDoNgoaiNgu")
                .Include("XepLoaiHocLuc")
                .Include("TrinhDoCaoNhat")
                .Include("TrinhDoTinHoc")
                .Include("ChuyenNganhDaoTao")
                .Include("LamViecTrongNganh")
                .Include("MonDuTuyen.ViTriUngTuyen")
                .Include("HinhThucDaoTao")
                .Include("Province")
                .Include("District")
                .Include("District1")
                .Include("District2")
                .Include("TonGiao")
                .Include("DanToc")
                .Include("ThanhPhanBanThanHienTai")
                .Include("DoiTuongUuTien1")
                .Include("TruongHopDacBiet")
                .Include("TrinhDoNgoaiNguKhac")
                .Include("ChungChiNghiepVuSuPham")
                .Include("Province1")
                .Include("Province2")
                .Include("Account")
                .Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true) && s.UpdatedAt != null).ToList();
            return TuyenDungs;
        }
        public int GetTuyenDungsChuaCapNhatSoLuong()
        {
            int count = _db.TuyenDung2020.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null) && s.UpdatedAt == null).Count();
            return count;
        }

        public int GetTuyenDungsDaHoanThanhSoLuong()
        {
            int count = _db.TuyenDung2020.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null) && s.UpdatedAt != null).Count();
            return count;
        }

        public int GetTuyenDungsHopLeSoLuong()
        {
            int count = _db.TuyenDung2020.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && s.TrangThaiHosoTuyenDungId == 1 && (s.IsActive == true || s.IsActive == null)).Count();
            return count;
        }

        //public List<HoSoHopLe> GetTuyenDungsHopLe()
        //{
        //    List<HoSoHopLe> hoSoHopLes = _db.HoSoHopLes.Include("TuyenDung").Include("TuyenDung.Account1").Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && s.TuyenDung.TrangThaiHosoTuyenDungId == 1 && (s.TuyenDung.IsActive == true || s.TuyenDung.IsActive == null)).ToList();
        //    return hoSoHopLes;
        //}

        public List<RegistrationInterviewStatusRegistedCountDTO> GetSoluongDangkyTheoViTriUngTuyen()
        {
            var TuyenDungs = _db.TuyenDung2020
                .Where(s => s.IsActive == true && s.MonDuTuyenId != null)
                .Include("MonDuTuyen")
                .GroupBy(s => s.MonDuTuyenId)
                .Select(s => new RegistrationInterviewStatusRegistedCountDTO { ViTriUngTuyen = s.Key.ToString(), Quantity = s.Count(), Targets = 0 }).ToList();
            return TuyenDungs;
        }

        public TuyenDung2020 GetTuyenDungByTienToId(string id)
        {
            TuyenDung2020 TuyenDung = _db.TuyenDung2020.Include("Account1").Where(s => s.TienTo + s.Id.ToString() == id).SingleOrDefault();
            return TuyenDung;
        }

        public List<TuyenDung2020> GetTuyenDungsIsCheckByAccountId(int id)
        {
            List<TuyenDung2020> TuyenDungs = _db.TuyenDung2020.Where(s => s.NguoiRaSoat == id).ToList();
            return TuyenDungs;
        }

        //public List<HoSoHopLe> GetTuyenDungsHopLeWithDetail()
        //{
        //    List<HoSoHopLe> hoSoHopLes = _db.HoSoHopLes
        //        .Include("TuyenDung")
        //        .Include("TuyenDung.Ward.District.Province")
        //        .Include("TuyenDung.Ward1.District.Province")
        //        .Include("TuyenDung.BangTotNghiep")
        //        .Include("TuyenDung.TrinhDoNgoaiNgu")
        //        .Include("TuyenDung.XepLoaiHocLuc")
        //        .Include("TuyenDung.TrinhDoCaoNhat")
        //        .Include("TuyenDung.TrinhDoTinHoc")
        //        .Include("TuyenDung.ChuyenNganhDaoTao")
        //        .Include("TuyenDung.LamViecTrongNganh")
        //        .Include("TuyenDung.MonDuTuyen.ViTriUngTuyen")
        //        .Include("TuyenDung.HinhThucDaoTao")
        //        .Include("TuyenDung.Province")
        //        .Include("TuyenDung.District")
        //        .Include("TuyenDung.District1")
        //        .Include("TuyenDung.District2")
        //        .Include("TuyenDung.TonGiao")
        //        .Include("TuyenDung.DanToc")
        //        .Include("TuyenDung.ThanhPhanBanThanHienTai")
        //        .Include("TuyenDung.DoiTuongUuTien1")
        //        .Include("TuyenDung.TruongHopDacBiet")
        //        .Include("TuyenDung.TrinhDoNgoaiNguKhac")
        //        .Include("TuyenDung.ChungChiNghiepVuSuPham")
        //        .Include("TuyenDung.Province1")
        //        .Include("TuyenDung.Province2")
        //        .Include("TuyenDung.Account")
        //        .Include("TuyenDung.Account1")
        //        .Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && s.tuyend.TrangThaiHosoTuyenDungId == 1 && (s.TuyenDung.IsActive == true || s.TuyenDung.IsActive == null)).ToList();
        //    return hoSoHopLes;
        //}

        public int GetTuyenDungsDaRaXoatSoLuong()
        {
            int count = _db.TuyenDung2020.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null) && s.NguoiRaSoat != null).Count();
            return count;
        }

        public int GetTuyenDungsKhongHopLeSoLuong()
        {
            int count = _db.TuyenDung2020.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null) && s.TrangThaiHosoTuyenDungId == 3).Count();
            return count;
        }

        public List<HoSoHopLe> GetTuyenDungsHopLe()
        {
            throw new NotImplementedException();
        }

        public List<HoSoHopLe> GetTuyenDungsHopLeWithDetail()
        {
            throw new NotImplementedException();
        }

        public TuyenDung2020 GetTuyenDungByCMND(string cmnd)
        {
            TuyenDung2020 tuyenDung = _db.TuyenDung2020.Where(s => s.IdentifyCard == cmnd.Trim()).SingleOrDefault();
            return tuyenDung;
        }

        public List<TuyenDung2020> GetTuyenDungBySchoolID(int schoolID)
        {
            List<TuyenDung2020> tuyenDung2020s = _db.TuyenDung2020.AsNoTracking().Include("MonDuTuyen.ViTriUngTuyen")
                .Include("TrangThaiHosoTuyenDung").Where(s => s.School.Id == schoolID).ToList();
            return tuyenDung2020s;
        }

        public List<TuyenDung2020> GetTuyenDungsByStatus(int? id)
        {
            List<TuyenDung2020> tuyenDung2020s = new List<TuyenDung2020>();
            if (id == null)
            {
                tuyenDung2020s = _db.TuyenDung2020.AsNoTracking()
                .Include("School")
                .Include("MonDuTuyen.ViTriUngTuyen")
                .ToList();
            }
            else
            {
                tuyenDung2020s = _db.TuyenDung2020.AsNoTracking()
                                .Include("School")
                                .Include("MonDuTuyen.ViTriUngTuyen")
                                .Where(s => s.TrangThaiHosoTuyenDungId == id).ToList();
            }
            
            return tuyenDung2020s;
        }
    }
}