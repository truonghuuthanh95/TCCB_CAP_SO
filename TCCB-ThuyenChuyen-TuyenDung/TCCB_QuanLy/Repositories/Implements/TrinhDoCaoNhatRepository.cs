using System.Collections.Generic;
using System.Linq;
using TCCB_QuanLy.Repositories.Interfaces;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class TrinhDoCaoNhatRepository : ITrinhDoCaoNhatRepository
    {
        TCCBDB _db;

        public TrinhDoCaoNhatRepository(TCCBDB db)
        {
            _db = db;
        }       

        public List<TrinhDoCaoNhat> GetTrinhDoCaoNhats()
        {
            List<TrinhDoCaoNhat> trinhDoCaoNhatHienNays = _db.TrinhDoCaoNhats.ToList();
            return trinhDoCaoNhatHienNays;
        }
    }
}