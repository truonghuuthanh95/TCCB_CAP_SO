using System.Collections.Generic;
using System.Linq;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class BangTotNghiepRepository : IBangTotNghiepRepository
    {
        TCCBDB _db;

        public BangTotNghiepRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<BangTotNghiep> GetBangTotNghieps()
        {
            List<BangTotNghiep> bangTotNghieps = _db.BangTotNghieps.Where(s => s.IsActive == true).ToList();
            return bangTotNghieps;
        }
        
    }
}