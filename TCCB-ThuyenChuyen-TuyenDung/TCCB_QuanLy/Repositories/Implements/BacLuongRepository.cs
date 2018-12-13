using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class BacLuongRepository : IBacLuongRepository
    {
        TCCBDB _db;

        public BacLuongRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<BacLuong> GetBacLuongByNhomMaNgach(string nhom)
        {
            List<BacLuong> bacLuongs = _db.BacLuongs.Where(s => s.Nhom.Trim() == nhom.Trim()).OrderBy(s => s.ID).ToList();
            return bacLuongs;
        }
    }
}