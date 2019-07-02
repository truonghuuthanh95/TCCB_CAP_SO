using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Services
{
    public class MaNgachRepository : IDisposable
    {
        public void Dispose()
        {
            
        }
        public MaNgach GetMaNgachById(string id)
        {
            using (var _db = new TCCBDB())
            {
                MaNgach maNgach = _db.MaNgaches.Where(s => s.ID == id).SingleOrDefault();
                return maNgach;
            }
            
        }

        public List<MaNgach> GetMaNgaches()
        {
            using (var _db = new TCCBDB())
            {
                List<MaNgach> maNgaches = _db.MaNgaches.OrderBy(s => s.ChucDanh).ToList();
                return maNgaches;
            }
            
        }
    }
}