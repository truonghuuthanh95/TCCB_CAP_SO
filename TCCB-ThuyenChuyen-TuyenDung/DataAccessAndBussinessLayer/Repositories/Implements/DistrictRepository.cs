using System.Collections.Generic;
using System.Linq;
using DataAccessAndBussinessLayer.Repositories.Interfaces;
using DataAccessAndBussinessLayer.Models.DAO;

namespace DataAccessAndBussinessLayer.Repositories.Implements
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