using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Services
{
    public class ThuyenChuyenNgoaiTinhService : IDisposable
    {
        public void Dispose()
        {
            
        }
        public ThuyenChuyenNgoaiTinh CapNhatThuyenChuyen(ThuyenChuyenNgoaiTinh thuyenChuyen)
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

        public ThuyenChuyenNgoaiTinh CapNhatTrangThaiHoSo(ThuyenChuyenNgoaiTinh thuyenChuyen, int trangThaiId)
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

        public ThuyenChuyenNgoaiTinh CreateThuyenChuyen(ThuyenChuyenNgoaiTinh thuyenChuyen)
        {
            using (var _db = new TCCBDB())
            {
                thuyenChuyen.CreatedAt = DateTime.Now;
                thuyenChuyen.TienTo = "TCN";
                _db.ThuyenChuyenNgoaiTinhs.Add(thuyenChuyen);
                _db.SaveChanges();
                return thuyenChuyen;
            }

        }

        public ThuyenChuyenNgoaiTinh CheckThuyenChuyenExistedByIdAndCMND(string id, string cmnd)
        {
            using (var _db = new TCCBDB())
            {
                ThuyenChuyenNgoaiTinh thuyenChuyen = _db.ThuyenChuyenNgoaiTinhs
                .Include("BangTotNghiep")
                .Include("StatusThuyenChuyen")
                .Include("ChuyenNganhDaoTao")
                .Include("HinhThucDaoTao")
                .Include("MonDuTuyen")
                .Include("School.Ward.District")               
                .Include("XepLoaiHocLuc")
                .Include("Ward1.District.Province")
                .Include("Ward.District.Province")
                .Include("TrinhDoCaoNhat")
                .Where(s => s.TienTo + s.Id == id.Trim().ToUpper() && s.CMND.Trim() == cmnd.Trim())
                .SingleOrDefault();
                return thuyenChuyen;
            }

        }

        public List<ThuyenChuyenNgoaiTinh> GetThuyenChuyens(int? dvqlId)
        {
            using (var _db = new TCCBDB())
            {
                List<ThuyenChuyenNgoaiTinh> thuyenChuyens = _db.ThuyenChuyenNgoaiTinhs
                .Include("BangTotNghiep")
                .Include("ChuyenNganhDaoTao")
                .Include("HinhThucDaoTao")
                .Include("StatusThuyenChuyen")
                .Include("MonDuTuyen")
                .Include("School")              
                .Include("XepLoaiHocLuc")
                .Include("Ward1.District.Province")
                .Include("Ward.District.Province")
                .Include("TrinhDoCaoNhat")
                .Where(s => s.School.DVQLId == dvqlId && s.StatusId != null).ToList();
                return thuyenChuyens;
            }

        }
        public List<ThuyenChuyenNgoaiTinh> GetThuyenChuyensByYear(int? year)
        {
            using (var _db = new TCCBDB())
            {
                List<ThuyenChuyenNgoaiTinh> thuyenChuyens = _db.ThuyenChuyenNgoaiTinhs
                .Include("BangTotNghiep")
                .Include("ChuyenNganhDaoTao")
                .Include("HinhThucDaoTao")
                .Include("StatusThuyenChuyen")
                .Include("MonDuTuyen")
                .Include("School")
                .Include("XepLoaiHocLuc")
                .Include("Ward1.District.Province")
                .Include("Ward.District.Province")
                .Include("TrinhDoCaoNhat")
                .Include("Province")
                .Where(s => s.NgayTiepNhan.Value.Year == year).ToList();
                return thuyenChuyens;
            }

        }
        public ThuyenChuyenNgoaiTinh GetThuyenChuyensById(int id)
        {
            using (var _db = new TCCBDB())
            {
                ThuyenChuyenNgoaiTinh thuyenChuyen = _db.ThuyenChuyenNgoaiTinhs
                .Include("BangTotNghiep")
                .Include("StatusThuyenChuyen")
                .Include("ChuyenNganhDaoTao")
                .Include("HinhThucDaoTao")
                .Include("MonDuTuyen")
                .Include("School.Ward.District")
                .Include("School.DVQL")               
                .Include("XepLoaiHocLuc")
                .Include("Ward1.District.Province")
                .Include("Ward.District.Province")
                .Include("Province")
                .Include("TrinhDoCaoNhat")
                .Where(s => s.Id == id).SingleOrDefault();
                return thuyenChuyen;
            }

        }
        public ThuyenChuyenNgoaiTinh GetThuyenChuyensByMaHoSo(string id)
        {
            using (var _db = new TCCBDB())
            {
                ThuyenChuyenNgoaiTinh thuyenChuyen = _db.ThuyenChuyenNgoaiTinhs
                .Include("BangTotNghiep")
                .Include("StatusThuyenChuyen")
                .Include("ChuyenNganhDaoTao")
                .Include("HinhThucDaoTao")
                .Include("MonDuTuyen")
                .Include("School.Ward.District")
                .Include("School.DVQL")
                .Include("XepLoaiHocLuc")
                .Include("Ward1.District.Province")
                .Include("Ward.District.Province")
                .Include("Province")
                .Include("TrinhDoCaoNhat")
                .Where(s => s.TienTo.Trim() + s.Id == id.Trim().ToUpper()).SingleOrDefault();
                return thuyenChuyen;
            }

        }
        public List<ThuyenChuyenNgoaiTinh> GetThuyenChuyenByStatusAndDvqlAndYear(int statusId, int? dvqlId, int year)
        {
            using (var _db = new TCCBDB())
            {
                List<ThuyenChuyenNgoaiTinh> thuyenChuyens = _db.ThuyenChuyenNgoaiTinhs
                .Include("BangTotNghiep")
                .Include("ChuyenNganhDaoTao")
                .Include("HinhThucDaoTao")
                .Include("StatusThuyenChuyen")
                .Include("MonDuTuyen")
                .Include("School")                
                .Include("XepLoaiHocLuc")
                .Include("Ward.District.Province")
                .Include("Ward1.District.Province")
                .Include("Province")
                .Include("TrinhDoCaoNhat")
                .Where(s => s.School.DVQLId == dvqlId && s.StatusId == statusId && s.CreatedAt.Value.Year == year).ToList();
                return thuyenChuyens;
            }
        }
    }
}