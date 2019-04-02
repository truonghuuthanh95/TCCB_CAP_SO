using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Services
{
    public class ProvinceRepository : IDisposable
    {
        public void Dispose()
        {
            
        }
        public List<Province> GetProvinceByCountryId(int id)
        {
            using (var _db = new TCCBDB())
            {
                List<Province> provinces = _db.Provinces.Where(s => s.CountryId == id).OrderBy(s => s.Name).ToList();
                return provinces;
            }
            
        }
    }
}