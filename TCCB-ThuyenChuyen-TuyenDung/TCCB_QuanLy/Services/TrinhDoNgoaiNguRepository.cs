using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Services
{
    public class TrinhDoNgoaiNguRepository : IDisposable
    {
        public void Dispose()
        {
            
        }
        public List<TrinhDoNgoaiNgu> GetTrinhDoNgoaiNgus()
        {
            using (var _db = new TCCBDB())
            {
                List<TrinhDoNgoaiNgu> trinhDoNgoaiNgus = _db.TrinhDoNgoaiNgus.ToList();
                return trinhDoNgoaiNgus;
            }
            
        }
    }
}