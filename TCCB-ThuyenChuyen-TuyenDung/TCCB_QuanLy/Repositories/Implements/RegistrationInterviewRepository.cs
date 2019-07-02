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
        
        public RegistrationInterview GetRegistrationInterviewById(int id)
        {
            RegistrationInterview registrationInterview = _db.RegistrationInterviews             
               .SingleOrDefault(s => s.Id == id);
               
            return registrationInterview;
        }

        public RegistrationInterview GetRegistrationInterviewByIdAndIdentifyCard(string id, string identifyCard)
        {
            RegistrationInterview registrationInterview = _db.RegistrationInterviews
                .Include("Ward.District")
                .Include("Ward1.District")
                .SingleOrDefault(s => s.TienTo + s.Id.ToString() == id.ToUpper());
            if (registrationInterview == null || registrationInterview.IdentifyCard.Trim() != identifyCard)
            {
                return null;

            }            
                return registrationInterview;
            
        }

        
        public RegistrationInterview GetRegistrationInterviewByIdWithDetail(int id)
        {
            RegistrationInterview registrationInterview = _db.RegistrationInterviews
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
                .SingleOrDefault(s => s.Id == id);
            return registrationInterview;
        }                  

        public RegistrationInterview CapNhatRegistrationInterview(RegistrationInterview registrationInterview)
        {           
            _db.Entry(registrationInterview).State = EntityState.Modified;
           
                _db.SaveChanges();
                     
            return registrationInterview;
        }

        public RegistrationInterview TaoMoiUngVien(RegistrationInterview registrationInterview)
        {           
            _db.RegistrationInterviews.Add(registrationInterview);
            _db.SaveChanges();
            return registrationInterview;
            

        }

        public List<RegistrationInterview> GetRegistrationInterviewsByCmnd(string cmnd)
        {
            List<RegistrationInterview> registrationInterviews = _db.RegistrationInterviews.Where(s => s.IdentifyCard.Trim() == cmnd.Trim()).OrderByDescending(s => s.CreatedAt).ToList();
            return registrationInterviews;
        }

        public int GetRegistrationInterviewsDaDangkiSoLuong()
        {
            int count = _db.RegistrationInterviews.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null)).Count();
            return count;
        }

        public List<RegistrationInterview> GetRegistrationInterviewsDaDangKi()
        {
            List<RegistrationInterview> registrationInterviews = _db.RegistrationInterviews.Include("Account").Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null)).ToList();
            return registrationInterviews;
        }

        public List<RegistrationInterview> GetRegistrationInterviewsChuaCapNhat()
        {
            List<RegistrationInterview> registrationInterviews = _db.RegistrationInterviews.Include("Account").Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null) && s.UpdatedAt == null).ToList();
            return registrationInterviews;
        }

        public List<RegistrationInterview> GetRegistrationInterviewsDaHoanThanh()
        {
            List<RegistrationInterview> registrationInterviews = _db.RegistrationInterviews.Include("Account").Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null) && s.UpdatedAt != null).ToList();
            return registrationInterviews;
        }
        public List<RegistrationInterview> GetRegistrationInterviewsDaHoanThanhWithDetail()
        {
            List<RegistrationInterview> registrationInterviews = _db.RegistrationInterviews
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
            return registrationInterviews;
        }
        public int GetRegistrationInterviewsChuaCapNhatSoLuong()
        {
            int count = _db.RegistrationInterviews.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null) && s.UpdatedAt == null).Count();
            return count;
        }

        public int GetRegistrationInterviewsDaHoanThanhSoLuong()
        {
            int count = _db.RegistrationInterviews.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null) && s.UpdatedAt != null).Count();
            return count;
        }

        public int GetRegistrationInterviewsHopLeSoLuong()
        {
            int count = _db.RegistrationInterviews.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && s.TrangThaiHosoTuyenDungId == 1 && (s.IsActive == true || s.IsActive == null)).Count();
            return count;
        }

        public List<HoSoHopLe> GetRegistrationInterviewsHopLe()
        {
            List<HoSoHopLe> hoSoHopLes = _db.HoSoHopLes.Include("RegistrationInterview").Include("RegistrationInterview.Account1").Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && s.RegistrationInterview.TrangThaiHosoTuyenDungId == 1 && (s.RegistrationInterview.IsActive == true || s.RegistrationInterview.IsActive == null)).ToList();
            return hoSoHopLes;
        }

        public List<RegistrationInterviewStatusRegistedCountDTO> GetSoluongDangkyTheoViTriUngTuyen()
        {
            var registrationInterviews = _db.RegistrationInterviews
                .Where(s => s.IsActive == true && s.MonDuTuyenId != null)
                .Include("MonDuTuyen")
                .GroupBy(s => s.MonDuTuyenId)
                .Select(s => new RegistrationInterviewStatusRegistedCountDTO { ViTriUngTuyen = s.Key.ToString(), Quantity = s.Count(), Targets = 0 }).ToList();            
            return registrationInterviews;
        }

        public RegistrationInterview GetRegistrationInterviewByTienToId(string id)
        {
            RegistrationInterview registrationInterview = _db.RegistrationInterviews.Include("Account1").Where(s => s.TienTo + s.Id.ToString() == id).SingleOrDefault();
            return registrationInterview;
        }

        public List<RegistrationInterview> GetRegistrationInterviewsIsCheckByAccountId(int id)
        {
            List<RegistrationInterview> registrationInterviews = _db.RegistrationInterviews.Where(s => s.NguoiRaSoat == id).ToList();
            return registrationInterviews;
        }

        public List<HoSoHopLe> GetRegistrationInterviewsHopLeWithDetail()
        {
            List<HoSoHopLe> hoSoHopLes = _db.HoSoHopLes
                .Include("RegistrationInterview")
                .Include("RegistrationInterview.Ward.District.Province")
                .Include("RegistrationInterview.Ward1.District.Province")
                .Include("RegistrationInterview.BangTotNghiep")
                .Include("RegistrationInterview.TrinhDoNgoaiNgu")
                .Include("RegistrationInterview.XepLoaiHocLuc")
                .Include("RegistrationInterview.TrinhDoCaoNhat")
                .Include("RegistrationInterview.TrinhDoTinHoc")
                .Include("RegistrationInterview.ChuyenNganhDaoTao")
                .Include("RegistrationInterview.LamViecTrongNganh")
                .Include("RegistrationInterview.MonDuTuyen.ViTriUngTuyen")
                .Include("RegistrationInterview.HinhThucDaoTao")
                .Include("RegistrationInterview.Province")
                .Include("RegistrationInterview.District")
                .Include("RegistrationInterview.District1")
                .Include("RegistrationInterview.District2")
                .Include("RegistrationInterview.TonGiao")
                .Include("RegistrationInterview.DanToc")
                .Include("RegistrationInterview.ThanhPhanBanThanHienTai")
                .Include("RegistrationInterview.DoiTuongUuTien1")
                .Include("RegistrationInterview.TruongHopDacBiet")
                .Include("RegistrationInterview.TrinhDoNgoaiNguKhac")
                .Include("RegistrationInterview.ChungChiNghiepVuSuPham")
                .Include("RegistrationInterview.Province1")
                .Include("RegistrationInterview.Province2")
                .Include("RegistrationInterview.Account")
                .Include("RegistrationInterview.Account1")
                .Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && s.RegistrationInterview.TrangThaiHosoTuyenDungId == 1 && (s.RegistrationInterview.IsActive == true || s.RegistrationInterview.IsActive == null)).ToList();
            return hoSoHopLes;
        }
    }
}