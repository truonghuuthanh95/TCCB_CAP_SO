﻿using System;
using System.Collections.Generic;
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

        public ThuyenChuyen CapNhatThuyenChuyen(ThuyenChuyen thuyenChuyen)
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

        public ThuyenChuyen CapNhatTrangThaiHoSo(ThuyenChuyen thuyenChuyen, int trangThaiId)
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

        public ThuyenChuyen CreateThuyenChuyen(ThuyenChuyen thuyenChuyen)
        {
            thuyenChuyen.CreatedAt = DateTime.Now;
            _db.ThuyenChuyens.Add(thuyenChuyen);
            _db.SaveChanges();
            return thuyenChuyen;
        }

        public ThuyenChuyen checkThuyenChuyenExistedByIdAndCMND(int id, string cmnd)
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
                .Where(s => s.Id == id && s.CMND.Trim() == cmnd.Trim())               
                .SingleOrDefault();
            return thuyenChuyen;
        }

        public List<ThuyenChuyen> GetThuyenChuyens(int? dvqlId)
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

        public ThuyenChuyen GetThuyenChuyensById(int id)
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

        public List<ThuyenChuyen> GetThuyenChuyenByStatusAndDvql(int statusId, int? dvqlId)
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
                .Where(s => s.School.DVQLId == dvqlId && s.StatusId == statusId).ToList();
            return thuyenChuyens;
        }
    }
}