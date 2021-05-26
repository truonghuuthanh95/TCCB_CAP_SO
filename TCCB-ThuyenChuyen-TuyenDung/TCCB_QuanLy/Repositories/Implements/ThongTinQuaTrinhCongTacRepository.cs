using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class ThongTinQuaTrinhCongTacRepository : IThongTinQuaTrinhCongTacRepository
    {
        TCCBDB _db;

        public ThongTinQuaTrinhCongTacRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<ThongTinQuaTrinhCongTac> CreateThongTinQuaTrinhCongTac(List<ThongTinQuaTrinhCongTac> thongTinQuaTrinhCongTacs)
        {
            _db.ThongTinQuaTrinhCongTacs.AddRange(thongTinQuaTrinhCongTacs);
            _db.SaveChanges();
            return thongTinQuaTrinhCongTacs;
        }

        public List<ThongTinQuaTrinhCongTac> GetThongTinQuaTrinhCongTacsByTuyenDungId(int tuyendungId)
        {
            var result = _db.ThongTinQuaTrinhCongTacs.Where(s => s.TuyenDungId == tuyendungId).ToList();
            return result;
        }
    }
}