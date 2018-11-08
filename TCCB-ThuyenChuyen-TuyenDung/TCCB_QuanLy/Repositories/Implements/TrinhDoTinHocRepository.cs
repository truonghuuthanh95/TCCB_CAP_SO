using System.Collections.Generic;
using System.Linq;
using TCCB_QuanLy.Repositories.Interfaces;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class TrinhDoTinHocRepository : ITrinhDoTinHocRepository
    {
        TCCBDB _db;

        public TrinhDoTinHocRepository(TCCBDB db)
        {
            _db = db;
        }        

        public List<TrinhDoTinHoc> GetTrinhDoTinHocs()
        {
            List<TrinhDoTinHoc> trinhDoTinHocs = _db.TrinhDoTinHocs.Where(s => s.IsActive == true).ToList();
            return trinhDoTinHocs;
        }
    }
}