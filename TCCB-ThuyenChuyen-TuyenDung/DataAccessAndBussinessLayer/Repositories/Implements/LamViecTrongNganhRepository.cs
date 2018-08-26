using System.Collections.Generic;
using System.Linq;
using DataAccessAndBussinessLayer.Repositories.Interfaces;
using DataAccessAndBussinessLayer.Models.DAO;

namespace DataAccessAndBussinessLayer.Repositories.Implements
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