using System.Collections.Generic;
using System.Linq;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Repositories.Implements
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