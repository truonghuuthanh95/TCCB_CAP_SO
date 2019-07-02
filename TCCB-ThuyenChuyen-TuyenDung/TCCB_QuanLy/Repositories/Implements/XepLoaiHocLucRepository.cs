using System.Collections.Generic;
using System.Linq;
using TCCB_QuanLy.Repositories.Interfaces;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class XepLoaiHocLucRepository : IXepLoaiHocLucRepository
    {
        TCCBDB _db;

        public XepLoaiHocLucRepository(TCCBDB db)
        {
            _db = db;
        }

        

        public List<XepLoaiHocLuc> GetXepLoaiHocLucs()
        {
            List<XepLoaiHocLuc> xepLoaiHocLucs = _db.XepLoaiHocLucs.Where(s => s.IsActive == true).ToList();
            return xepLoaiHocLucs;
        }
    }
}