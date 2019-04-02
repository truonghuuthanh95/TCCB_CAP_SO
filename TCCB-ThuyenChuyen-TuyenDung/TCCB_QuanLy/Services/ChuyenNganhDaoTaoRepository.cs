using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Services
{
    public class ChuyenNganhDaoTaoRepository : IDisposable
    {
        public void Dispose()
        {
           
        }
        public List<ChuyenNganhDaoTao> GetChuyenNganhDaoTaos()
        {
            using (var _db = new TCCBDB())
            {
                List<ChuyenNganhDaoTao> chuyenNganhDaoTaos = _db.ChuyenNganhDaoTaos.Where(s => s.IsActive == true).OrderBy(s => s.Name).ToList();
                return chuyenNganhDaoTaos;
            }
            
        }
    }
}