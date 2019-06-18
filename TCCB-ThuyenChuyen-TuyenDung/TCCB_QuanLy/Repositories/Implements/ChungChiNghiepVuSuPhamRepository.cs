using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class ChungChiNghiepVuSuPhamRepository : IChungChiNghiepVuSuPhamRepository
    {
        TCCBDB _db;

        public ChungChiNghiepVuSuPhamRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<ChungChiNghiepVuSuPham> GetChungChiNghiepVuSuPhams()
        {
            List<ChungChiNghiepVuSuPham> chungChiNghiepVuSuPhams = _db.ChungChiNghiepVuSuPhams.Where(s => s.IsActive == true).ToList();
            return chungChiNghiepVuSuPhams;
        }
    }
}