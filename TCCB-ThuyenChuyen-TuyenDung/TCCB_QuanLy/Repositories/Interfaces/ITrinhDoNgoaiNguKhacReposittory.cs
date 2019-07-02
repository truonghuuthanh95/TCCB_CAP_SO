using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Repositories.Interfaces
{
    public interface ITrinhDoNgoaiNguKhacReposittory
    {
        List<TrinhDoNgoaiNguKhac> GetTrinhDoNgoaiNguKhacs();
    }
}