using TCCB_QuanLy.Models.DAO;
using System.Collections.Generic;

namespace TCCB_QuanLy.Models.DTO
{
    public class CandidateModelInOneView
    {
        public List<Province> Provinces { get; set; }
        public List<District> NohnQuanHuyen { get; set; }
        public List<Ward> NohnPhuongXa { get; set; }
        public List<District> HkttQuanHuyen { get; set; }
        public List<Ward> HkttPhuongXa { get; set; }

        public TuyenDung2021 RegistrationInterview { get; set; }
       
        public List<HinhThucDaoTao> HinhThucDaoTaos { get; set; }
       
        public List<BangTotNghiep> BangTotNghieps { get; set; }
             
        public List<TrinhDoCaoNhat> TrinhDoCaoNhats { get; set; }
        
        public List<ChuyenNganhDaoTao> ChuyenNganhDaoTaos { get; set; }
       
        public List<LamViecTrongNganh> LamViecTrongNganhs { get; set; }
       
        public List<TrinhDoTinHoc> TrinhDoTinHocs { get; set; }
        
        public List<TrinhDoNgoaiNgu> TrinhDoNgoaiNgus { get; set; }
       
        public List<MonDuTuyen> MonDuTuyens { get; set; }
       
        public List<XepLoaiHocLuc> XepLoaiHocLucs { get; set; }
        public List<District> HCMDistrict { get; set; }

        public CandidateModelInOneView(List<Province> provinces, List<District> nohnQuanHuyen, List<Ward> nohnPhuongXa, List<District> hkttQuanHuyen, List<Ward> hkttPhuongXa, TuyenDung2021 registrationInterview, List<HinhThucDaoTao> hinhThucDaoTaos, List<BangTotNghiep> bangTotNghieps, List<TrinhDoCaoNhat> trinhDoCaoNhats, List<ChuyenNganhDaoTao> chuyenNganhDaoTaos, List<LamViecTrongNganh> lamViecTrongNganhs, List<TrinhDoTinHoc> trinhDoTinHocs, List<TrinhDoNgoaiNgu> trinhDoNgoaiNgus, List<MonDuTuyen> monDuTuyens, List<XepLoaiHocLuc> xepLoaiHocLucs, List<District> hCMDistrict)
        {
            Provinces = provinces;
            NohnQuanHuyen = nohnQuanHuyen;
            NohnPhuongXa = nohnPhuongXa;
            HkttQuanHuyen = hkttQuanHuyen;
            HkttPhuongXa = hkttPhuongXa;
            RegistrationInterview = registrationInterview;
            HinhThucDaoTaos = hinhThucDaoTaos;
            BangTotNghieps = bangTotNghieps;
            TrinhDoCaoNhats = trinhDoCaoNhats;
            ChuyenNganhDaoTaos = chuyenNganhDaoTaos;
            LamViecTrongNganhs = lamViecTrongNganhs;
            TrinhDoTinHocs = trinhDoTinHocs;
            TrinhDoNgoaiNgus = trinhDoNgoaiNgus;
            MonDuTuyens = monDuTuyens;
            XepLoaiHocLucs = xepLoaiHocLucs;
            HCMDistrict = hCMDistrict;
        }
    }
}