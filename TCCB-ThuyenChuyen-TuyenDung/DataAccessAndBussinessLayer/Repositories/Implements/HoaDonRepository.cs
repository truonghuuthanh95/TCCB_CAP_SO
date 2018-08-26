using System.Linq;
using DataAccessAndBussinessLayer.Repositories.Interfaces;
using DataAccessAndBussinessLayer.Models.DAO;
using System.Collections.Generic;

namespace DataAccessAndBussinessLayer.Repositories.Implements
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