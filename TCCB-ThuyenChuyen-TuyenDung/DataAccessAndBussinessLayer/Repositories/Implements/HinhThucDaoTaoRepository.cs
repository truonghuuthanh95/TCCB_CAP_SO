using System.Collections.Generic;
using System.Linq;
using DataAccessAndBussinessLayer.Repositories.Interfaces;
using DataAccessAndBussinessLayer.Models.DAO;

namespace DataAccessAndBussinessLayer.Repositories.Implements
{
    public class HinhThucDaoTaoRepository : IHinhThucDaoTaoRepository
    {
        TCCBDB _db;

        public HinhThucDaoTaoRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<HinhThucDaoTao> GetHinhThucDaoTaos()
        {
            List<HinhThucDaoTao> hinhThucDaoTaos = _db.HinhThucDaoTaos.Where(s => s.IsActive == true).ToList();
            return hinhThucDaoTaos;
        }

       
    }
}