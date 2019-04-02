using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Services
{
    public class SchoolRepository : IDisposable
    {
        public void Dispose()
        {
            
        }
        public School GetSchoolById(int? id)
        {
            using (var _db = new TCCBDB())
            {
                School school = _db.Schools.Include("Ward.District").Where(s => s.Id == id).SingleOrDefault();
                return school;
            }
            
        }

        public List<School> GetSchoolsByDistrictAndCapHoc(int? districtId, int? caphoc)
        {
            using (var _db = new TCCBDB())
            {
                List<School> schools = _db.Schools.Where(s => s.Ward.DistrictID == districtId).Where(s => s.CapTruongId == caphoc).ToList();
                return schools;
            }
            
        }
    }
}