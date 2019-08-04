using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Repositories.Interfaces
{
    public interface IDiemThiTuyenRepository
    {
        DiemThiTuyen GetDiemThiTuyenByMaVong2AndCmnd(string mavong2, string cmnd);
    }
}