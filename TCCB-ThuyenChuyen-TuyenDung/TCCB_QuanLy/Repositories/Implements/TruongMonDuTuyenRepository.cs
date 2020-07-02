using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class TruongMonDuTuyenRepository : ITruongMonDuTuyenRepository
    {
        TCCBDB _db;

        public TruongMonDuTuyenRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<School> GetTruongByMonDuTuyen(int? monDuTuyenId)
        {
            List <School> schools = _db.TruongMonDuTuyens.AsNoTracking().Where(s => s.IsActive == true && s.MonDuTuyenId == monDuTuyenId).Select(s => s.School).ToList();
            return schools;
        }

        List<TruongMonDuTuyen> ITruongMonDuTuyenRepository.GetTruongMonDuTuyens()
        {
            List<TruongMonDuTuyen> truongMonDuTuyens = _db.TruongMonDuTuyens.Where(s => s.IsActive == true).ToList();
            return truongMonDuTuyens;
        }
    }
}