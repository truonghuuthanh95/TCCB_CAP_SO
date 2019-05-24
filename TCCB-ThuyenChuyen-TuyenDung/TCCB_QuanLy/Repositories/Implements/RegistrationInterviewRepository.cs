using System;
using System.Linq;
using TCCB_QuanLy.Repositories.Interfaces;
using TCCB_QuanLy.Models.DAO;
using System.Data.Entity;
using System.Collections.Generic;

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
            List<RegistrationInterview> registrationInterviews = _db.RegistrationInterviews.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null)).ToList();
            return registrationInterviews;
        }

        public List<RegistrationInterview> GetRegistrationInterviewsChuaCapNhat()
        {
            List<RegistrationInterview> registrationInterviews = _db.RegistrationInterviews.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null) && s.UpdatedAt == null).ToList();
            return registrationInterviews;
        }

        public List<RegistrationInterview> GetRegistrationInterviewsDaHoanThanh()
        {
            List<RegistrationInterview> registrationInterviews = _db.RegistrationInterviews.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null) && s.UpdatedAt != null).ToList();
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
            int count = _db.RegistrationInterviews.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && s.NguoiRaSoat != null && (s.IsActive == true || s.IsActive == null)).Count();
            return count;
        }

        public List<RegistrationInterview> GetRegistrationInterviewsHopLe()
        {
            List<RegistrationInterview> registrationInterviews = _db.RegistrationInterviews.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && s.NguoiRaSoat != null && (s.IsActive == true || s.IsActive == null)).ToList();
            return registrationInterviews;
        }
    }
}