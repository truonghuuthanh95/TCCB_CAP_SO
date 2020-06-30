using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class ThuyenChuyenRepository : IThuyenChuyenRepository
    {
        TCCBDB _db;

        public ThuyenChuyenRepository(TCCBDB db)
        {
            _db = db;
        }
      

        
        public ThuyenChuyen2020 CapNhatThuyenChuyen(ThuyenChuyen2020 thuyenChuyen)
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

        public ThuyenChuyen2020 CapNhatTrangThaiHoSo(ThuyenChuyen2020 thuyenChuyen, int trangThaiId)
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

        public ThuyenChuyen2020 CreateThuyenChuyen(ThuyenChuyen2020 thuyenChuyen)
        {
            thuyenChuyen.CreatedAt = DateTime.Now;
            _db.ThuyenChuyen2020.Add(thuyenChuyen);
            _db.SaveChanges();
            return thuyenChuyen;
        }

        public ThuyenChuyen2020 checkThuyenChuyenExistedByIdAndCMND(int id, string cmnd)
        {
            ThuyenChuyen2020 thuyenChuyen = _db.ThuyenChuyen2020
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
                .Where(s => s.Id == id && s.CMND.Trim() == cmnd.Trim())
                .SingleOrDefault();
            return thuyenChuyen;
        }

        

        public ThuyenChuyen2020 GetThuyenChuyensById(int id)
        {
            ThuyenChuyen2020 thuyenChuyen = _db.ThuyenChuyen2020
                .Include("Province")
                .Include("Province1")
                .Include("BangTotNghiep")
                .Include("StatusThuyenChuyen")
                .Include("ChuyenNganhDaoTao")
                .Include("HinhThucDaoTao")
                .Include("MonDuTuyen")
                
                .Include("School.DVQL")
                .Include("School.Ward.District")                
                .Include("School1.DVQL")
                .Include("School1.Ward.District")
                .Include("XepLoaiHocLuc")
                .Include("Ward1.District.Province")
                .Include("Ward.District.Province")
                .Include("TrinhDoCaoNhat")
                .Where(s => s.Id == id).SingleOrDefault();
            return thuyenChuyen;
        }

        public List<ThuyenChuyen2020> GetThuyenChuyenByStatusAndYear(int statusId, int year)
        {
            List<ThuyenChuyen2020> thuyenChuyen2020 = _db.ThuyenChuyen2020
               .Include("Province")
               .Include("Province1")
               .Include("BangTotNghiep")
               .Include("StatusThuyenChuyen")
               .Include("ChuyenNganhDaoTao")
               .Include("HinhThucDaoTao")
               .Include("MonDuTuyen")
               .Include("School.DVQL")
               .Include("School.Ward.District")
               .Include("School1.DVQL")
               .Include("School1.Ward.District")
               .Include("XepLoaiHocLuc")
               .Include("Ward1.District.Province")
               .Include("Ward.District.Province")
               .Include("TrinhDoCaoNhat").Where(s => s.NgayTiepNhan.Value.Year == year).Where(s => s.StatusId == statusId).ToList();
            return thuyenChuyen2020;
        }

        public ThuyenChuyen2020 GetThuyenChuyensByMaHoSo(string maHoSo)
        {
            ThuyenChuyen2020 thuyenChuyen = _db.ThuyenChuyen2020
                //.Include("Province")
                //.Include("Province1")
                //.Include("BangTotNghiep")
                ////.Include("StatusThuyenChuyen")
                //.Include("ChuyenNganhDaoTao")
                //.Include("HinhThucDaoTao")
                //.Include("MonDuTuyen")
                //.Include("School.DVQL")
                //.Include("School.Ward.District")
                //.Include("School1.DVQL")
                //.Include("School1.Ward.District")
                //.Include("XepLoaiHocLuc")
                //.Include("Ward1.District.Province")
                //.Include("Ward.District.Province")
                //.Include("TrinhDoCaoNhat")
                .Where(s => s.TienTo + s.Id == maHoSo).SingleOrDefault();
            return thuyenChuyen;
        }

        public ThuyenChuyen2020 TiepNhanHoSo(ThuyenChuyen2020 thuyenChuyen, int trangThaiId, int accountId)
        {
            thuyenChuyen.StatusId = trangThaiId;
            thuyenChuyen.NguoiTiepNhanId = accountId;
            thuyenChuyen.NgayTiepNhan = DateTime.Now;
            _db.Entry(thuyenChuyen).State = EntityState.Modified;
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

        public List<ThuyenChuyen2020> GetThuyenChuyensByYear(int year)
        {
            List<ThuyenChuyen2020> thuyenChuyen2020 = _db.ThuyenChuyen2020
                .Include("Province")
                .Include("Province1")
                .Include("BangTotNghiep")
                //.Include("StatusThuyenChuyen")
                .Include("ChuyenNganhDaoTao")
                .Include("HinhThucDaoTao")
                .Include("MonDuTuyen")
                .Include("School.DVQL")
                .Include("School.Ward.District")
                .Include("School1.DVQL")
                .Include("School1.Ward.District")
                .Include("XepLoaiHocLuc")
                .Include("Ward1.District.Province")
                .Include("Ward.District.Province")
                .Include("TrinhDoCaoNhat").Where(s => s.NgayTiepNhan.Value.Year == year).ToList();
            return thuyenChuyen2020;
        }

        //public List<ThuyenChuyen2020> GetThuyenChuyenByStatusAndDvql(int statusId, int? dvqlId)
        //{
        //    List<ThuyenChuyen2020> thuyenChuyens = _db.ThuyenChuyen2020
        //        .Include("BangTotNghiep")
        //        .Include("ChuyenNganhDaoTao")
        //        .Include("HinhThucDaoTao")
        //        .Include("StatusThuyenChuyen")
        //        .Include("MonDuTuyen")
        //        .Include("School")
        //        .Include("School1")
        //        .Include("XepLoaiHocLuc")
        //        .Include("Ward1.District.Province")
        //        .Include("Ward.District.Province")
        //        .Include("TrinhDoCaoNhat")
        //        .Where(s => s.School.DVQLId == dvqlId && s.StatusId == statusId).ToList();
        //    return thuyenChuyens;
        //}
    }
}