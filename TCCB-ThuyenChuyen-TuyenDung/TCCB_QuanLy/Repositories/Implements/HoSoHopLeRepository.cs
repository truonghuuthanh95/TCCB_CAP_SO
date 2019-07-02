using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class HoSoHopLeRepository : IHoSoHopLeRepository
    {
        TCCBDB _db;

        public HoSoHopLeRepository(TCCBDB db)
        {
            _db = db;
        }
        private int? GetMaxSoHoHopLeByCurrentYear()
        {
            int? max = _db.HoSoHopLes.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year).OrderBy(s => s.MaVong2).Select(s => s.MaVong2).FirstOrDefault();
            if (!max.HasValue)
            {
                return 0;
            }
            return max;
        }
        public HoSoHopLe CreateHoSoHopLe(HoSoHopLe hoSoHopLe)
        {
            hoSoHopLe.MaVong2 = GetMaxSoHoHopLeByCurrentYear() + 1;
            _db.HoSoHopLes.Add(hoSoHopLe);
            _db.SaveChanges();
            return hoSoHopLe;
        }

        public HoSoHopLe GetHoSoHopLeByHoSoId(int id)
        {
            HoSoHopLe hoSoHopLe = _db.HoSoHopLes.Where(s => s.HoSoId == id).FirstOrDefault();
            return hoSoHopLe;
                
        }
    }
}