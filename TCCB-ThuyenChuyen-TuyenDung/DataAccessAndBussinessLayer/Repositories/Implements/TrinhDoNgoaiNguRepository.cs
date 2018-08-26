using System.Collections.Generic;
using System.Linq;
using DataAccessAndBussinessLayer.Repositories.Interfaces;
using DataAccessAndBussinessLayer.Models.DAO;

namespace DataAccessAndBussinessLayer.Repositories.Implements
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
            List<TrinhDoNgoaiNgu> trinhDoNgoaiNgus = _db.TrinhDoNgoaiNgus.ToList();
            return trinhDoNgoaiNgus;
        }
    }
}