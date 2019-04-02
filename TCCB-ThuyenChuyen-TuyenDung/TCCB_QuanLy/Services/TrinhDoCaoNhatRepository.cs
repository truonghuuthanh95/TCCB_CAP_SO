using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Services
{
    public class TrinhDoCaoNhatRepository : IDisposable
    {
        public void Dispose()
        {
            
        }
        public List<TrinhDoCaoNhat> GetTrinhDoCaoNhats()
        {
            using (var _db = new TCCBDB())
            {
                List<TrinhDoCaoNhat> trinhDoCaoNhatHienNays = _db.TrinhDoCaoNhats.ToList();
                return trinhDoCaoNhatHienNays;
            }
            
        }
    }
}