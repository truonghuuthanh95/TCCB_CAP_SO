using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Repositories.Interfaces
{
    public interface IThuyenChuyenRepository
    {
        ThuyenChuyen2020 CreateThuyenChuyen(ThuyenChuyen2020 thuyenChuyen);
        List<ThuyenChuyen2020> GetThuyenChuyensByYear(int year);
        ThuyenChuyen2020 GetThuyenChuyensById(int id);
        ThuyenChuyen2020 CapNhatTrangThaiHoSo(ThuyenChuyen2020 thuyenChuyen, int trangThaiId);
        ThuyenChuyen2020 CapNhatThuyenChuyen(ThuyenChuyen2020 thuyenChuyen);
        ThuyenChuyen2020 checkThuyenChuyenExistedByIdAndCMND(int id, string cmnd);
        List<ThuyenChuyen2020> GetThuyenChuyenByStatusAndYear(int statusId, int year);
        ThuyenChuyen2020 GetThuyenChuyensByMaHoSo(string maHoSo);
        ThuyenChuyen2020 TiepNhanHoSo(ThuyenChuyen2020 thuyenChuyen, int trangThaiId, int accountId);
    }
}
