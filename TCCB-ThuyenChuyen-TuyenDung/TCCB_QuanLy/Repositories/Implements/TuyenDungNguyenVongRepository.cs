using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class TuyenDungNguyenVongRepository : ITuyenDungNguyenVongRepository
    {
        TCCBDB _db;

        public TuyenDungNguyenVongRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<TuyenDungNguyenVong> CreateTuyenDungNguyenVong(List<TuyenDungNguyenVong> tuyenDungNguyenVongs)
        {
            _db.TuyenDungNguyenVongs.AddRange(tuyenDungNguyenVongs);
            _db.SaveChanges();
            return tuyenDungNguyenVongs;
        }

        public List<TuyenDungNguyenVong> GetTuyenDungNguyenVongsByTuyenDungId(int tuyenDungId)
        {
            var result = _db.TuyenDungNguyenVongs.Where(s => s.TuyenDungId == tuyenDungId).ToList();
            return result;
        }
    }
}