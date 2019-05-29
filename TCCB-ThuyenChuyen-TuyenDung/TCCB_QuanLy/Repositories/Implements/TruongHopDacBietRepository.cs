using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class TruongHopDacBietRepository : ITruongHopDacBietRepository
    {
        TCCBDB _db;

        public TruongHopDacBietRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<TruongHopDacBiet> GetTruongHopDacBiets()
        {
            List<TruongHopDacBiet> truongHopDacBiets = _db.TruongHopDacBiets.Where(s => s.IsActive == true).ToList();
            return truongHopDacBiets;
        }
    }
}