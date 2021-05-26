using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Repositories.Interfaces
{
    public interface IThongTinQuaTrinhCongTacRepository
    {
        List<ThongTinQuaTrinhCongTac> GetThongTinQuaTrinhCongTacsByTuyenDungId(int tuyendungId);
        List<ThongTinQuaTrinhCongTac> CreateThongTinQuaTrinhCongTac(List<ThongTinQuaTrinhCongTac> thongTinQuaTrinhCongTacs);
    }
}
