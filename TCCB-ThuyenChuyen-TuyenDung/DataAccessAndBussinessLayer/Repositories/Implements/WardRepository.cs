using System.Collections.Generic;
using System.Linq;
using DataAccessAndBussinessLayer.Repositories.Interfaces;
using DataAccessAndBussinessLayer.Models.DAO;

namespace DataAccessAndBussinessLayer.Repositories.Implements
{
    public class WardRepository : IWardRepository
    {
        TCCBDB _db;

        public WardRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<Ward> GetWardByDistrictId(int id)
        {
            List<Ward> wards = _db.Wards.Where(s => s.DistrictID == id).OrderBy(s => s.Name).ToList();
            return wards;
        }
    }
}