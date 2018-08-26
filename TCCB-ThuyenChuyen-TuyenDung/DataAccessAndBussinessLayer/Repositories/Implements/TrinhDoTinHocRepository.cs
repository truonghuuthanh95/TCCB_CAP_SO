using System.Collections.Generic;
using System.Linq;
using DataAccessAndBussinessLayer.Repositories.Interfaces;
using DataAccessAndBussinessLayer.Models.DAO;

namespace DataAccessAndBussinessLayer.Repositories.Implements
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