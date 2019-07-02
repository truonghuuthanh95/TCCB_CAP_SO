using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Services
{
    public class HinhThucDaoTaoRepository : IDisposable
    {
        public void Dispose()
        {
            
        }
        public List<HinhThucDaoTao> GetHinhThucDaoTaos()
        {
            using (var _db = new TCCBDB())
            {
                List<HinhThucDaoTao> hinhThucDaoTaos = _db.HinhThucDaoTaos.Where(s => s.IsActive == true).ToList();
                return hinhThucDaoTaos;
            }
            
        }
    }
}