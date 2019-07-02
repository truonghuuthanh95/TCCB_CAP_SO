using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class DoiTuongUuTienRepository : IDoiTuongUuTienRepository
    {
        TCCBDB _db;

        public DoiTuongUuTienRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<DoiTuongUuTien> GetDoiTuongUuTiens()
        {
            List<DoiTuongUuTien> doiTuongUuTiens = _db.DoiTuongUuTiens.ToList();
            return doiTuongUuTiens;
        }
    }
}