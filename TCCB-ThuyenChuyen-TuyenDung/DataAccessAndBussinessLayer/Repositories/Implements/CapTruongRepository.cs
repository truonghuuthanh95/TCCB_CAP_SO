using System.Collections.Generic;
using System.Linq;
using DataAccessAndBussinessLayer.Models.DAO;
using DataAccessAndBussinessLayer.Repositories.Interfaces;

namespace DataAccessAndBussinessLayer.Repositories.Implements
{
    public class CapTruongRepository : ICapTruongRepository
    {
        TCCBDB _db;

        public CapTruongRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<CapTruong> GetCapTruongs()
        {
            List<CapTruong> capTruongs = _db.CapTruongs.Where(s => s.IsActive == true).ToList();
            return capTruongs;
        }
        
    }
}