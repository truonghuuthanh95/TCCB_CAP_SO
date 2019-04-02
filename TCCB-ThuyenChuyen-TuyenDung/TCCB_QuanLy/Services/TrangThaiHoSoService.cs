using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Services
{
    public class TrangThaiHoSoService : IDisposable
    {
        public void Dispose()
        {
            
        }
        public List<StatusThuyenChuyen> GetStatusThuyenChuyens()
        {
            using (var _db = new TCCBDB())
            {
                List<StatusThuyenChuyen> statusThuyenChuyens = _db.StatusThuyenChuyens.Where(s => s.IsActive == true).ToList();
                return statusThuyenChuyens;
            }
        }
        public StatusThuyenChuyen GetStatusThuyenChuyensById(int id)
        {
            using (var _db = new TCCBDB())
            {
                StatusThuyenChuyen statusThuyenChuyens = _db.StatusThuyenChuyens.Where(s => s.Id == id).SingleOrDefault();
                return statusThuyenChuyens;
            }
        }
    }
}