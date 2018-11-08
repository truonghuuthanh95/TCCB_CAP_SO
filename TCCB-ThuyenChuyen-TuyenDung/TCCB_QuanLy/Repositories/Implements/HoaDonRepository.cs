using System.Linq;
using TCCB_QuanLy.Repositories.Interfaces;
using TCCB_QuanLy.Models.DAO;
using System.Collections.Generic;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class HoaDonRepository : IHoaDonRepository
    {

        TCCBDB _db;

        public HoaDonRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<HoaDon> GetHoaDonByDVQLId()
        {
            List<HoaDon> hoaDons = _db.HoaDons.OrderByDescending(s => s.Id).ToList();
            return hoaDons;
        }

       
    }
}