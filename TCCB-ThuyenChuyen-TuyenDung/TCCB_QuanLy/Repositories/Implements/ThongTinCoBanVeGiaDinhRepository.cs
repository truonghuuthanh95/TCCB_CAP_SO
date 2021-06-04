using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class ThongTinCoBanVeGiaDinhRepository : IThongTinCoBanVeGiaDinhRepository
    {
        TCCBDB _db;

        public ThongTinCoBanVeGiaDinhRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<ThongTinCoBanVeGiaDinh> CreateThongTinCoBanVeGiaDinh(List<ThongTinCoBanVeGiaDinh> thongTinCoBanVeGiaDinhs)
        {
            thongTinCoBanVeGiaDinhs.ForEach(s => { s.NgaySinh.Trim(); s.MoiQuanHe.Trim(); s.NoiDung.Trim(); });
            _db.ThongTinCoBanVeGiaDinhs.AddRange(thongTinCoBanVeGiaDinhs);
            _db.SaveChanges();
            return thongTinCoBanVeGiaDinhs;
        }

        public bool DeleteThongTinCoBanVeGiaDinhsByTuyenDungId(int id)
        {
            var remove = _db.ThongTinCoBanVeGiaDinhs.Where(s => s.TuyenDungId == id).ToList();
            _db.ThongTinCoBanVeGiaDinhs.RemoveRange(remove);
            _db.SaveChanges();
            return true;
        }

        public List<ThongTinCoBanVeGiaDinh> GetThongTinCoBanVeGiaDinhsByTuyenDungId(int id)
        {
            var result = _db.ThongTinCoBanVeGiaDinhs.Where(s => s.TuyenDungId == id).ToList();
            return result;
        }
    }
}