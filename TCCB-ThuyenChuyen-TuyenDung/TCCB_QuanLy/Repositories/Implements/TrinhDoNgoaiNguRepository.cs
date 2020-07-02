using System.Collections.Generic;
using System.Linq;
using TCCB_QuanLy.Repositories.Interfaces;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class TrinhDoNgoaiNguRepository : ITrinhDoNgoaiNguRepository
    {
        TCCBDB _db;

        public TrinhDoNgoaiNguRepository(TCCBDB db)
        {
            _db = db;
        }
       

        public List<TrinhDoNgoaiNgu> GetTrinhDoNgoaiNgus()
        {
            List<TrinhDoNgoaiNgu> trinhDoNgoaiNgus = _db.TrinhDoNgoaiNgus.Where(s => s.IsActive == true).OrderBy(s => s.Name).ToList();
            return trinhDoNgoaiNgus;
        }
    }
}