using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class TruongNhiemVuThamGiaHDTDRepository : ITruongNhiemVuThamGiaHDTDRepository

    {
        TCCBDB _db;

        public TruongNhiemVuThamGiaHDTDRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<TruongNhiemVuThamGiaHDTD> GetNhiemVuThamGiaHDTDsBySchoolId(int schoolId)
        {
            List<TruongNhiemVuThamGiaHDTD> truongNhiemVuThamGiaHDTDs = _db.TruongNhiemVuThamGiaHDTDs.Where(s => s.SchoolId == schoolId).ToList();
            return truongNhiemVuThamGiaHDTDs;
        }

        public bool UpdateTruongNhiemVuThamGiaHDTD(List<TruongNhiemVuThamGiaHDTD> truongNhiemVuThamGiaHDTDs)
        {
            //_db.TruongNhiemVuThamGiaHDTDs.RemoveRange(_db.TruongNhiemVuThamGiaHDTDs.Where(s => s.SchoolId == truongNhiemVuThamGiaHDTDs[0].SchoolId).ToList());
            _db.Database.ExecuteSqlCommand($"DELETE FROM [dbo].[TruongNhiemVuThamGiaHDTD] WHERE SchoolId = {truongNhiemVuThamGiaHDTDs[0].SchoolId}");
            
            _db.TruongNhiemVuThamGiaHDTDs.AddRange(truongNhiemVuThamGiaHDTDs);

            try
            {

                _db.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
                
            return true;
        }
    }
}