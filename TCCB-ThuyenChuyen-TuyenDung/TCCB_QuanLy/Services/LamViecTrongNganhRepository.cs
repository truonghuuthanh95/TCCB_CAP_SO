using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Services
{
    public class LamViecTrongNganhRepository : IDisposable
    {
        public void Dispose()
        {
            
        }
        public List<LamViecTrongNganh> GetLamViecTrongNganhs()
        {
            using (var _db = new TCCBDB())
            {
                List<LamViecTrongNganh> lamViecTrongNganhs = _db.LamViecTrongNganhs.Where(s => s.IsActive == true).ToList();
                return lamViecTrongNganhs;
            }
            
        }
    }
}