using System.Collections.Generic;
using System.Linq;
using DataAccessAndBussinessLayer.Repositories.Interfaces;
using DataAccessAndBussinessLayer.Models.DAO;

namespace DataAccessAndBussinessLayer.Repositories.Implements
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