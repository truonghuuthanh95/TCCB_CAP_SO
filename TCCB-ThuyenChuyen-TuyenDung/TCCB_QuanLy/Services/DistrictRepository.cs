using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Services
{
    public class DistrictRepository : IDisposable
    {
        public void Dispose()
        {
           
        }
        public List<District> GetDistrictByProvinceId(int id)
        {
            using (var _db = new TCCBDB())
            {
                List<District> districts = _db.Districts.Where(s => s.ProvinceId == id).OrderBy(s => s.Name).ToList();
                return districts;
            }
            
        }
    }
}