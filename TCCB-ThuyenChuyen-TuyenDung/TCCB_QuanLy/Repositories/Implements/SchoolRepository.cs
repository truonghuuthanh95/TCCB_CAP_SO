using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class SchoolRepository : ISchoolRepository
    {
        TCCBDB _db;

        public SchoolRepository(TCCBDB db)
        {
            _db = db;
        }

        public School GetSchoolById(int? id)
        {
            School school = _db.Schools.Include("Ward.District").Where(s => s.Id == id).SingleOrDefault();
            return school;
        }

        public School GetSchoolByMaTruong(string maTruong)
        {
            School school = _db.Schools.Include("Ward.District").Where(s => s.MaTruong.Trim() == maTruong.Trim()).SingleOrDefault();
            return school;
        }

        public List<School> GetSchoolsByDistrictAndCapHoc(int? districtId, int? caphoc)
        {
            List<School> schools = _db.Schools.Where(s => s.Ward.DistrictID == districtId).Where(s => s.CapTruongId == caphoc).ToList();
            return schools;
        }
    }
}