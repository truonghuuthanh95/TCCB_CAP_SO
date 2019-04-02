using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Services
{
    public class RegistrationInterviewRepository : IDisposable
    {
        public void Dispose()
        {
           
        }
        public RegistrationInterview GetRegistrationInterviewById(int id)
        {
            using (var _db = new TCCBDB())
            {
                RegistrationInterview registrationInterview = _db.RegistrationInterviews
               .SingleOrDefault(s => s.Id == id);

                return registrationInterview;
            }
            
        }

        public RegistrationInterview GetRegistrationInterviewByIdAndIdentifyCard(int id, string identifyCard)
        {
            using (var _db = new TCCBDB())
            {
                RegistrationInterview registrationInterview = _db.RegistrationInterviews
                .Include("Ward.District")
                .Include("Ward1.District")
                .SingleOrDefault(s => s.Id == id);
                if (registrationInterview == null || registrationInterview.IdentifyCard.Trim() != identifyCard)
                {
                    return null;

                }
                return registrationInterview;
            }
            

        }


        public RegistrationInterview GetRegistrationInterviewByIdWithDetail(int id)
        {
            using (var _db = new TCCBDB())
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
                .SingleOrDefault(s => s.Id == id);
                return registrationInterview;
            }
            
        }

        public RegistrationInterview CapNhatRegistrationInterview(RegistrationInterview registrationInterview)
        {
            using (var _db = new TCCBDB())
            {
                _db.Entry(registrationInterview).State = EntityState.Modified;
                try
                {
                    _db.SaveChanges();
                }
                catch (Exception)
                {
                    return null;
                }
                return registrationInterview;
            }
            
        }

        public RegistrationInterview TaoMoiUngVien(RegistrationInterview registrationInterview)
        {
            using (var _db = new TCCBDB())
            {
                _db.RegistrationInterviews.Add(registrationInterview);
                _db.SaveChanges();
                return registrationInterview;
            }
            


        }

        public List<RegistrationInterview> GetRegistrationInterviewsByCmnd(string cmnd)
        {
            using (var _db = new TCCBDB())
            {
                List<RegistrationInterview> registrationInterviews = _db.RegistrationInterviews.Where(s => s.IdentifyCard.Trim() == cmnd.Trim()).OrderByDescending(s => s.CreatedAt).ToList();
                return registrationInterviews;
            }
            
        }

        public int GetRegistrationInterviewsDaDangkiSoLuong()
        {
            using (var _db = new TCCBDB())
            {
                int count = _db.RegistrationInterviews.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null)).Count();
                return count;
            }
            
        }

        public List<RegistrationInterview> GetRegistrationInterviewsDaDangKi()
        {
            using (var _db = new TCCBDB())
            {
                List<RegistrationInterview> registrationInterviews = _db.RegistrationInterviews.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null)).ToList();
                return registrationInterviews;
            }
            
        }

        public List<RegistrationInterview> GetRegistrationInterviewsChuaCapNhat()
        {
            using (var _db = new TCCBDB())
            {
                List<RegistrationInterview> registrationInterviews = _db.RegistrationInterviews.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null) && s.UpdatedAt == null).ToList();
                return registrationInterviews;
            }
            
        }

        public List<RegistrationInterview> GetRegistrationInterviewsDaHoanThanh()
        {
            using (var _db = new TCCBDB())
            {
                List<RegistrationInterview> registrationInterviews = _db.RegistrationInterviews.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null) && s.UpdatedAt != null).ToList();
                return registrationInterviews;
            }
            
        }

        public int GetRegistrationInterviewsChuaCapNhatSoLuong()
        {
            using (var _db = new TCCBDB())
            {
                int count = _db.RegistrationInterviews.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null) && s.UpdatedAt == null).Count();
                return count;
            }
            
        }

        public int GetRegistrationInterviewsDaHoanThanhSoLuong()
        {
            using (var _db = new TCCBDB())
            {
                int count = _db.RegistrationInterviews.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null) && s.UpdatedAt != null).Count();
                return count;
            }
            
        }

        public int GetRegistrationInterviewsHopLeSoLuong()
        {
            using (var _db = new TCCBDB())
            {
                int count = _db.RegistrationInterviews.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && s.NguoiRaSoat != null && (s.IsActive == true || s.IsActive == null)).Count();
                return count;
            }
            
        }

        public List<RegistrationInterview> GetRegistrationInterviewsHopLe()
        {
            using (var _db = new TCCBDB())
            {
                List<RegistrationInterview> registrationInterviews = _db.RegistrationInterviews.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && s.NguoiRaSoat != null && (s.IsActive == true || s.IsActive == null)).ToList();
                return registrationInterviews;
            }
            
        }
    }
}