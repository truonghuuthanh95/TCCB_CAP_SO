using System;
using System.Linq;
using DataAccessAndBussinessLayer.Repositories.Interfaces;
using DataAccessAndBussinessLayer.Models.DAO;
using System.Data.Entity;

namespace DataAccessAndBussinessLayer.Repositories.Implements
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

        public RegistrationInterview GetRegistrationInterviewByIdAndIdentifyCard(int id, string identifyCard)
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
                .SingleOrDefault(s => s.Id == id);
            return registrationInterview;
        }                  

        public RegistrationInterview CapNhatRegistrationInterview(RegistrationInterview registrationInterview)
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
}