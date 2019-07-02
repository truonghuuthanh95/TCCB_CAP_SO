using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Services
{
    public class XepLoaiHocLucRepository : IDisposable
    {
        public void Dispose()
        {
           
        }
        public List<XepLoaiHocLuc> GetXepLoaiHocLucs()
        {
            using (var _db = new TCCBDB())
            {
                List<XepLoaiHocLuc> xepLoaiHocLucs = _db.XepLoaiHocLucs.Where(s => s.IsActive == true).ToList();
                return xepLoaiHocLucs;
            }
            
        }
    }
}