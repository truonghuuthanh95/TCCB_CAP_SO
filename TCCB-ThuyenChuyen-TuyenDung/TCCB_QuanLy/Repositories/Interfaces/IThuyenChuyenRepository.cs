using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Repositories.Interfaces
{
    public interface IThuyenChuyenRepository
    {
        ThuyenChuyen CreateThuyenChuyen(ThuyenChuyen thuyenChuyen);
        List<ThuyenChuyen> GetThuyenChuyens(int? dvqlId);
        ThuyenChuyen GetThuyenChuyensById(int id);
        ThuyenChuyen CapNhatTrangThaiHoSo(ThuyenChuyen thuyenChuyen, int trangThaiId);
        ThuyenChuyen CapNhatThuyenChuyen(ThuyenChuyen thuyenChuyen);
        ThuyenChuyen checkThuyenChuyenExistedByIdAndCMND(int id, string cmnd);
        List<ThuyenChuyen> GetThuyenChuyenByStatusAndDvql(int statusId, int? dvqlId);
    }
}