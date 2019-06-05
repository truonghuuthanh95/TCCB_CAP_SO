using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class ThanhPhanBanThanHienTaiRepository : IThanhPhanBanThanHienTaiRepository
    {
        TCCBDB _db;

        public ThanhPhanBanThanHienTaiRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<ThanhPhanBanThanHienTai> GetThanhPhanBanThanHienTais()
        {
            List<ThanhPhanBanThanHienTai> thanhPhanBanThanHienTais = _db.ThanhPhanBanThanHienTais.OrderBy(s => s.Name).ToList();
            ThanhPhanBanThanHienTai thanhPhanBanThanHienTai = thanhPhanBanThanHienTais.Where(s => s.Id == 11).SingleOrDefault();
            thanhPhanBanThanHienTais.Remove(thanhPhanBanThanHienTai);
            thanhPhanBanThanHienTais.Insert(0, thanhPhanBanThanHienTai);
            return thanhPhanBanThanHienTais;
        }
    }
}