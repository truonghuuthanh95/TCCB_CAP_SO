using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Services
{
    public class MonDuTuyenRepository : IDisposable
    {
        public void Dispose()
        {
           
        }
        public List<MonDuTuyen> GetAllMonDuTuyens()
        {
            using (var _db = new TCCBDB())
            {
                List<MonDuTuyen> monDuTuyens = _db.MonDuTuyens.OrderBy(s => s.PositionInterviewId).ThenBy(s => s.Name).ToList();
                return monDuTuyens;
            }
            
        }

        public List<MonDuTuyen> GetMonDuTuyens()
        {
            using (var _db = new TCCBDB())
            {
                List<MonDuTuyen> monDuTuyens = _db.MonDuTuyens.Include("ViTriUngTuyen").Where(s => s.IsActive == true).OrderBy(s => s.PositionInterviewId).ThenBy(s => s.Name).ToList();
                return monDuTuyens;
            }
            
        }
    }
}