using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class TrinhDoNgoaiNguKhacReposittory : ITrinhDoNgoaiNguKhacReposittory
    {
        TCCBDB _db;

        public TrinhDoNgoaiNguKhacReposittory(TCCBDB db)
        {
            _db = db;
        }

        public List<TrinhDoNgoaiNguKhac> GetTrinhDoNgoaiNguKhacs()
        {
            List<TrinhDoNgoaiNguKhac> trinhDoNgoaiNguKhacs = _db.TrinhDoNgoaiNguKhacs.Where(s => s.IsActive == true).ToList();
            return trinhDoNgoaiNguKhacs;
        }
    }
}