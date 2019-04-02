using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Services
{
    public class BangTotNghiepRepository : IDisposable
    {
        public void Dispose()
        {
           
        }
        public List<BangTotNghiep> GetBangTotNghieps()
        {
            using (var _db = new TCCBDB())
            {
                List<BangTotNghiep> bangTotNghieps = _db.BangTotNghieps.Where(s => s.IsActive == true).ToList();
                return bangTotNghieps;
            }
            
        }
    }
}