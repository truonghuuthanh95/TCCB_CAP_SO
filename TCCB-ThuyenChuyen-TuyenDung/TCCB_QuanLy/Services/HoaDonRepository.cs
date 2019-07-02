using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Services
{
    public class HoaDonRepository : IDisposable
    {
        public void Dispose()
        {
            
        }
        public List<HoaDon> GetHoaDonByDVQLId()
        {
            using (var _db = new TCCBDB())
            {
                List<HoaDon> hoaDons = _db.HoaDons.OrderByDescending(s => s.Id).ToList();
                return hoaDons;
            }
            
        }

    }
}