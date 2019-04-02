using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Services
{
    public class TrinhDoTinHocRepository : IDisposable
    {
        public void Dispose()
        {
            
        }
        public List<TrinhDoTinHoc> GetTrinhDoTinHocs()
        {
            using (var _db = new TCCBDB())
            {
                List<TrinhDoTinHoc> trinhDoTinHocs = _db.TrinhDoTinHocs.Where(s => s.IsActive == true).ToList();
                return trinhDoTinHocs;
            }
            
        }
    }
}