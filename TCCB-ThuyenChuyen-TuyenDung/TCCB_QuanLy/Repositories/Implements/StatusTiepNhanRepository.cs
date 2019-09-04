using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class StatusTiepNhanRepository : IStatusTiepNhanRepository
    {
        TCCBDB _db;

        public StatusTiepNhanRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<StatusTiepNhan> GetStatusTiepNhans()
        {
            List<StatusTiepNhan> statusTiepNhans = _db.StatusTiepNhans.AsNoTracking().Where(s => s.IsActive == true).ToList();
            return statusTiepNhans;
        }

       
    }
}