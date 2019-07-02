using System.Collections.Generic;
using System.Linq;
using DataAccessAndBussinessLayer.Repositories.Interfaces;
using DataAccessAndBussinessLayer.Models.DAO;

namespace DataAccessAndBussinessLayer.Repositories.Implements
{
    public class MonDuTuyenRepository : IMonDuTuyenRepository
    {
        TCCBDB _db;

        public MonDuTuyenRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<MonDuTuyen> GetMonDuTuyens()
        {
            List<MonDuTuyen> monDuTuyens = _db.MonDuTuyens.Include("ViTriUngTuyen").Where(s => s.IsActive == true).OrderBy(s => s.PositionInterviewId).ThenBy(s => s.Name).ToList();
            return monDuTuyens;
        }
       
    }
}