using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Services
{
    public class CapTruongRepository : IDisposable
    {
        public void Dispose()
        {
           
        }
        public List<CapTruong> GetCapTruongs()
        {
            using (var _db = new TCCBDB())
            {
                List<CapTruong> capTruongs = _db.CapTruongs.Where(s => s.IsActive == true).ToList();
                return capTruongs;
            }
            
        }
    }
}