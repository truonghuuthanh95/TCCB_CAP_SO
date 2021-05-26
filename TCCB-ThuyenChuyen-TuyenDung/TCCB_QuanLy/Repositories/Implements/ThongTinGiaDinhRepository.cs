using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class ThongTinGiaDinhRepository : IThongTinGiaDinhRepository
    {
        TCCBDB _db;

        public ThongTinGiaDinhRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<ThongTinCoBanVeGiaDinh> CreateThongTinGiaDinh(List<ThongTinCoBanVeGiaDinh> thongTinCoBanVeGiaDinhs)
        {
            _db.ThongTinCoBanVeGiaDinhs.AddRange(thongTinCoBanVeGiaDinhs);
            _db.SaveChanges();
            return thongTinCoBanVeGiaDinhs;
        }

        public List<ThongTinCoBanVeGiaDinh> GetThongTinCoBanVeGiaDinhsByTuyenDungId(int id)
        {
            var result = _db.ThongTinCoBanVeGiaDinhs.Where(s => s.TuyenDungId == id).ToList();
            return result;
        }
    }
}