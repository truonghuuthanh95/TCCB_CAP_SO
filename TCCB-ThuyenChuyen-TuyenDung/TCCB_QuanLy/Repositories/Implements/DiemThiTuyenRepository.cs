using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class DiemThiTuyenRepository : IDiemThiTuyenRepository
    {
        TCCBDB _db;

        public DiemThiTuyenRepository(TCCBDB db)
        {
            _db = db;
        }

        public DiemThiTuyen GetDiemThiTuyenByMaVong2AndCmnd(string mavong2, string cmnd)
        {
            DiemThiTuyen diemThiTuyen = _db.DiemThiTuyens.Where(s => s.MaVong2.Trim() == mavong2.Trim() && s.CMND.Trim() == cmnd.Trim()).SingleOrDefault();
            return diemThiTuyen;
        }
    }
}