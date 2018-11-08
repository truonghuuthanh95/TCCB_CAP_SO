using System.Collections.Generic;
using System.Linq;
using TCCB_QuanLy.Repositories.Interfaces;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Repositories.Implements
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