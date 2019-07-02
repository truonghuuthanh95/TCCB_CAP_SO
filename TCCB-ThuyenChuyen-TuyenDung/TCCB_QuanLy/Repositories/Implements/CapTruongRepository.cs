using System.Collections.Generic;
using System.Linq;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Repositories.Implements
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