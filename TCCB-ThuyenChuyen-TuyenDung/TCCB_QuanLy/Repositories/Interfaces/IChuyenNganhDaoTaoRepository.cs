﻿using TCCB_QuanLy.Models.DAO;
using System.Collections.Generic;

namespace TCCB_QuanLy.Repositories.Interfaces
{
    public interface IChuyenNganhDaoTaoRepository
    {
        List<ChuyenNganhDaoTao> GetChuyenNganhDaoTaos();
    }
}
