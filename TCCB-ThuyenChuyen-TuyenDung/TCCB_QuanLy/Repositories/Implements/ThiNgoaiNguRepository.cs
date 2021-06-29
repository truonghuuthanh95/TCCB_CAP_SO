using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class ThiNgoaiNguRepository : IThiNgoaiNguRepository
    {
        TCCBDB _db;

        public ThiNgoaiNguRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<ThiNgoaiNgu> GetThiNgoaiNgus()
        {
            var result = _db.ThiNgoaiNgus.Where(s => s.IsActive == true).ToList();
            return result;
        }
    }
}