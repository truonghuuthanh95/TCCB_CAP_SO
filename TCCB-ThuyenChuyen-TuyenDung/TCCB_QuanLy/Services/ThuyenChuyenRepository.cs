using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Services
{
    public class ThuyenChuyenRepository : IDisposable
    {
        public void Dispose()
        {
           
        }
        public ThuyenChuyen CapNhatThuyenChuyen(ThuyenChuyen thuyenChuyen)
        {
            using (var _db = new TCCBDB())
            {
                _db.Entry(thuyenChuyen).State = System.Data.Entity.EntityState.Modified;
                try
                {
                    _db.SaveChanges();
                }
                catch (Exception)
                {

                    return null;
                }
                return thuyenChuyen;
            }
            
        }

        public ThuyenChuyen CapNhatTrangThaiHoSo(ThuyenChuyen thuyenChuyen, int trangThaiId)
        {
            using (var _db = new TCCBDB())
            {
                thuyenChuyen.StatusId = trangThaiId;
                _db.Entry(thuyenChuyen).State = System.Data.Entity.EntityState.Modified;
                try
                {
                    _db.SaveChanges();
                }
                catch (Exception)
                {

                    return null;
                }
                return thuyenChuyen;
            }
            
        }

        public ThuyenChuyen CreateThuyenChuyen(ThuyenChuyen thuyenChuyen)
        {
            using (var _db = new TCCBDB())
            {
                thuyenChuyen.CreatedAt = DateTime.Now;
                thuyenChuyen.TienTo = "TC";
                _db.ThuyenChuyens.Add(thuyenChuyen);
                _db.SaveChanges();
                return thuyenChuyen;
            }
            
        }

        public ThuyenChuyen CheckThuyenChuyenExistedByIdAndCMND(string id, string cmnd)
        {
            using (var _db = new TCCBDB())
            {
                ThuyenChuyen thuyenChuyen = _db.ThuyenChuyens
                .Include("BangTotNghiep")
                .Include("StatusThuyenChuyen")
                .Include("ChuyenNganhDaoTao")
                .Include("HinhThucDaoTao")
                .Include("MonDuTuyen")
                .Include("School.Ward.District")
                .Include("School1.Ward.District")
                .Include("XepLoaiHocLuc")
                .Include("Ward1.District.Province")
                .Include("Ward.District.Province")
                .Include("TrinhDoCaoNhat")
                .Where(s => s.TienTo.Trim() + s.Id == id.ToUpper() && s.CMND.Trim() == cmnd.Trim())
                .SingleOrDefault();
                return thuyenChuyen;
            }
            
        }

        public List<ThuyenChuyen> GetThuyenChuyens(int? dvqlId)
        {
            using (var _db = new TCCBDB())
            {
                List<ThuyenChuyen> thuyenChuyens = _db.ThuyenChuyens
                .Include("BangTotNghiep")
                .Include("ChuyenNganhDaoTao")
                .Include("HinhThucDaoTao")
                .Include("StatusThuyenChuyen")
                .Include("MonDuTuyen")
                .Include("School")
                .Include("School1")
                .Include("XepLoaiHocLuc")
                .Include("Ward1.District.Province")
                .Include("Ward.District.Province")
                .Include("TrinhDoCaoNhat")
                .Where(s => s.School.DVQLId == dvqlId && s.StatusId != null).ToList();
                return thuyenChuyens;
            }
            
        }
        public List<ThuyenChuyen> GetThuyenChuyensByYear(int? year)
        {
            using (var _db = new TCCBDB())
            {
                List<ThuyenChuyen> thuyenChuyens = _db.ThuyenChuyens
                .Include("BangTotNghiep")
                .Include("ChuyenNganhDaoTao")
                .Include("HinhThucDaoTao")
                .Include("StatusThuyenChuyen")
                .Include("MonDuTuyen")
                .Include("School")
                .Include("School1")
                .Include("XepLoaiHocLuc")
                .Include("Ward1.District.Province")
                .Include("Ward.District.Province")
                .Include("TrinhDoCaoNhat")
                .Where(s => s.NgayTiepNhan.Value.Year == year).ToList();
                return thuyenChuyens;
            }

        }
        public List<ThuyenChuyen> GetThuyenChuyensByDVQLAndYear(int? dvqlId, int year)
        {
            using (var _db = new TCCBDB())
            {
                List<ThuyenChuyen> thuyenChuyens = _db.ThuyenChuyens
                .Include("BangTotNghiep")
                .Include("ChuyenNganhDaoTao")
                .Include("HinhThucDaoTao")
                .Include("StatusThuyenChuyen")
                .Include("MonDuTuyen")
                .Include("School")
                .Include("School1")
                .Include("XepLoaiHocLuc")
                .Include("Ward1.District.Province")
                .Include("Ward.District.Province")
                .Include("TrinhDoCaoNhat")
                .Where(s => s.School.DVQLId == dvqlId && s.StatusId != null).Where(s => s.CreatedAt.Value.Year == year).ToList();
                return thuyenChuyens;
            }

        }
        public ThuyenChuyen GetThuyenChuyensByMaHoSo(string id)
        {
            using (var _db = new TCCBDB())
            {
                ThuyenChuyen thuyenChuyen = _db.ThuyenChuyens
                .Include("BangTotNghiep")
                .Include("StatusThuyenChuyen")
                .Include("ChuyenNganhDaoTao")
                .Include("HinhThucDaoTao")
                .Include("MonDuTuyen")
                .Include("School.Ward.District")
                .Include("School.DVQL")
                .Include("School1.Ward.District")
                .Include("XepLoaiHocLuc")
                .Include("Ward1.District.Province")
                .Include("Ward.District.Province")
                .Include("TrinhDoCaoNhat")
                .Where(s => s.TienTo.Trim() + s.Id == id.ToUpper().Trim()).SingleOrDefault();
                return thuyenChuyen;
            }

        }
        public ThuyenChuyen GetThuyenChuyensById(int id)
        {
            using (var _db = new TCCBDB())
            {
                ThuyenChuyen thuyenChuyen = _db.ThuyenChuyens
                .Include("BangTotNghiep")
                .Include("StatusThuyenChuyen")
                .Include("ChuyenNganhDaoTao")
                .Include("HinhThucDaoTao")
                .Include("MonDuTuyen")
                .Include("School.Ward.District")
                .Include("School.DVQL")
                .Include("School1.Ward.District")
                .Include("XepLoaiHocLuc")
                .Include("Ward1.District.Province")
                .Include("Ward.District.Province")
                .Include("TrinhDoCaoNhat")
                .Where(s => s.Id == id).SingleOrDefault();
                return thuyenChuyen;
            }
            
        }

        public List<ThuyenChuyen> GetThuyenChuyenByStatusAndDvqlAndYear(int statusId, int? dvqlId, int year)
        {
            using (var _db = new TCCBDB())
            {
                List<ThuyenChuyen> thuyenChuyens = _db.ThuyenChuyens
                .Include("BangTotNghiep")
                .Include("ChuyenNganhDaoTao")
                .Include("HinhThucDaoTao")
                .Include("StatusThuyenChuyen")
                .Include("MonDuTuyen")
                .Include("School")
                .Include("School1")
                .Include("XepLoaiHocLuc")
                .Include("Ward1.District.Province")
                .Include("Ward.District.Province")
                .Include("TrinhDoCaoNhat")
                .Where(s => s.School.DVQLId == dvqlId && s.StatusId == statusId).Where(s => s.CreatedAt.Value.Year == year).ToList();
                return thuyenChuyens;
            }           
        }
    }
}