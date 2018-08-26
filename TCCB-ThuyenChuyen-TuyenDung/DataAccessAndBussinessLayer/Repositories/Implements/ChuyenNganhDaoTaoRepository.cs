using System.Collections.Generic;
using System.Linq;
using DataAccessAndBussinessLayer.Models.DAO;
using DataAccessAndBussinessLayer.Repositories.Interfaces;

namespace DataAccessAndBussinessLayer.Repositories.Implements
{
    public class ChuyenNganhDaoTaoRepository : IChuyenNganhDaoTaoRepository
    {
        TCCBDB _db;

        public ChuyenNganhDaoTaoRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<ChuyenNganhDaoTao> GetChuyenNganhDaoTaos()
        {
            List<ChuyenNganhDaoTao> chuyenNganhDaoTaos = _db.ChuyenNganhDaoTaos.Where(s => s.IsActive == true).OrderBy(s => s.Name).ToList();
            return chuyenNganhDaoTaos;
        }
    }
}