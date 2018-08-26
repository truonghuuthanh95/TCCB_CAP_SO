using System.Collections.Generic;
using System.Linq;
using DataAccessAndBussinessLayer.Models.DAO;
using DataAccessAndBussinessLayer.Repositories.Interfaces;

namespace DataAccessAndBussinessLayer.Repositories.Implements
{
    public class BangTotNghiepRepository : IBangTotNghiepRepository
    {
        TCCBDB _db;

        public BangTotNghiepRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<BangTotNghiep> GetBangTotNghieps()
        {
            List<BangTotNghiep> bangTotNghieps = _db.BangTotNghieps.Where(s => s.IsActive == true).ToList();
            return bangTotNghieps;
        }
        
    }
}