using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class MaNgachRepository : IMaNgachRepository
    {
        TCCBDB _db;

        public MaNgachRepository(TCCBDB db)
        {
            _db = db;
        }

        public MaNgach GetMaNgachById(string id)
        {
            MaNgach maNgach = _db.MaNgaches.Where(s => s.ID == id).SingleOrDefault();
            return maNgach;
        }

        public List<MaNgach> GetMaNgaches()
        {
            List<MaNgach> maNgaches = _db.MaNgaches.OrderBy(s => s.ChucDanh).ToList();
            return maNgaches;
        }        
    }
}