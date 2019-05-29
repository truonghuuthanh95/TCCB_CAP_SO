using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class TonGiaoRepository : ITonGiaoRepository
    {
        TCCBDB _db;

        public TonGiaoRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<TonGiao> GetTonGiaos()
        {
            List<TonGiao> tonGiaos = _db.TonGiaos.OrderBy(s => s.Name).ToList();
            TonGiao tonGiaoKhac = tonGiaos.Where(s => s.Id == 17).SingleOrDefault();
            tonGiaos.Remove(tonGiaoKhac);
            tonGiaos.Add(tonGiaoKhac);
            TonGiao tonGiaoKhong = tonGiaos.Where(s => s.Id == 1).SingleOrDefault();
            tonGiaos.Remove(tonGiaoKhong);
            tonGiaos.Insert(0, tonGiaoKhong);
            return tonGiaos;
        }
    }
}