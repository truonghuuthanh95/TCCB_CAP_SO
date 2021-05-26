using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Repositories.Interfaces
{
    public interface IThongTinGiaDinhRepository
    {

        List<ThongTinCoBanVeGiaDinh> GetThongTinCoBanVeGiaDinhsByTuyenDungId(int id);
        List<ThongTinCoBanVeGiaDinh> CreateThongTinGiaDinh(List<ThongTinCoBanVeGiaDinh> thongTinCoBanVeGiaDinhs);
    }
}
