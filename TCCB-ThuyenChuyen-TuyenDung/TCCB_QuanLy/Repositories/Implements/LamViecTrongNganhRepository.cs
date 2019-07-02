using System.Collections.Generic;
using System.Linq;
using TCCB_QuanLy.Repositories.Interfaces;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class LamViecTrongNganhRepository : ILamViecTrongNganhRepository
    {
        TCCBDB _db;

        public LamViecTrongNganhRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<LamViecTrongNganh> GetLamViecTrongNganhs()
        {
            List<LamViecTrongNganh> lamViecTrongNganhs = _db.LamViecTrongNganhs.Where(s => s.IsActive == true).ToList();
            return lamViecTrongNganhs;
        }

    }
}