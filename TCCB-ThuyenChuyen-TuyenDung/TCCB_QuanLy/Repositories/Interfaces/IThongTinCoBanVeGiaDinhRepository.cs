using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Repositories.Interfaces
{
    public interface IThongTinCoBanVeGiaDinhRepository
    {
        List<ThongTinCoBanVeGiaDinh> GetThongTinCoBanVeGiaDinhsByTuyenDungId(int id);
        List<ThongTinCoBanVeGiaDinh> CreateThongTinCoBanVeGiaDinh(List<ThongTinCoBanVeGiaDinh> thongTinCoBanVeGiaDinhs);

        bool DeleteThongTinCoBanVeGiaDinhsByTuyenDungId(int id);
    }
}
