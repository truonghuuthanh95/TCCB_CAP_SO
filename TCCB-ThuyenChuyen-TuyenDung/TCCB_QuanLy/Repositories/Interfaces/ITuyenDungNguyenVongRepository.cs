using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Repositories.Interfaces
{
    public interface ITuyenDungNguyenVongRepository
    {
        List<TuyenDungNguyenVong> GetTuyenDungNguyenVongsByTuyenDungId(int tuyenDungId);
        List<TuyenDungNguyenVong> CreateTuyenDungNguyenVong(List<TuyenDungNguyenVong> tuyenDungNguyenVongs);
    }
}
