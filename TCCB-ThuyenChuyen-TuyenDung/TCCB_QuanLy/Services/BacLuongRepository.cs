using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Services
{
    public class BacLuongRepository : IDisposable
    {
        public void Dispose()
        {
            
        }
        public List<BacLuong> GetBacLuongByNhomMaNgach(string nhom)
        {
            using (var _db = new TCCBDB())
            {
                List<BacLuong> bacLuongs = _db.BacLuongs.Where(s => s.Nhom.Trim() == nhom.Trim()).OrderBy(s => s.ID).ToList();
                return bacLuongs;
            }
            
        }
    }
}