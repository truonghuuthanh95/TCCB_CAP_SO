using System.Collections.Generic;
using System.Linq;
using TCCB_QuanLy.Repositories.Interfaces;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class DistrictRepository : IDistrictRepository
    {
        TCCBDB _db;

        public DistrictRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<District> GetDistrictByProvinceId(int id)
        {
            List<District> districts = _db.Districts.Where(s => s.ProvinceId == id).OrderBy(s => s.Name).ToList();
            return districts;
        }
    }
}