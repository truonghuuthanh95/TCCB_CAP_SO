using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Services
{
    public class WardRepository : IDisposable
    {
        public void Dispose()
        {
            
        }
        public List<Ward> GetWardByDistrictId(int id)
        {
            using (var _db = new TCCBDB())
            {
                List<Ward> wards = _db.Wards.Where(s => s.DistrictID == id).OrderBy(s => s.Name).ToList();
                return wards;
            }
            
        }
    }
}