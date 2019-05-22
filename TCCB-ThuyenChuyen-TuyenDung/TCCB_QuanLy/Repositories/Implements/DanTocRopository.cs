using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class DanTocRopository : IDanTocRepository
    {
        TCCBDB _db;

        public DanTocRopository(TCCBDB db)
        {
            _db = db;
        }

        public List<DanToc> GetDanTocs()
        {
            List<DanToc> danTocs = _db.DanTocs.OrderBy(s => s.Name).ToList();
            return danTocs;
        }
    }
}