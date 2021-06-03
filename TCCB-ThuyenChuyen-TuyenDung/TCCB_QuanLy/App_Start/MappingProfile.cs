using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Models.DTO;

namespace TCCB_QuanLy.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TuyenDung2020, RegistrationInterviewDTO>();
            CreateMap<RegistrationInterviewDTO, TuyenDung2020>();
            CreateMap<TuyenDung2021, RegistrationInterviewDTO>();
            CreateMap<RegistrationInterviewDTO, TuyenDung2021>();
            //CreateMap<ThuyenChuyen, ThuyenChuyenDTO>();
            //CreateMap<ThuyenChuyenDTO, ThuyenChuyen>();
            CreateMap<ThuyenChuyenNgoaiTinh, ThuyenChuyenNgoaiTinhDTO>();
            CreateMap<ThuyenChuyenNgoaiTinhDTO, ThuyenChuyenNgoaiTinh>();
            CreateMap<ThuyenChuyenDTO2020, ThuyenChuyen2020>();
            CreateMap<ThuyenChuyen2020, ThuyenChuyenDTO2020>();
            CreateMap<CanBoThamGiaHoiDongDTO, TruongNhiemVuThamGiaHDTD>();
            CreateMap<TruongNhiemVuThamGiaHDTD, CanBoThamGiaHoiDongDTO>();
            CreateMap<ThongTinCoBanVeGiaDinh, ThongTinCoBanVeGiaDinhDTO>();
            CreateMap<ThongTinCoBanVeGiaDinhDTO, ThongTinCoBanVeGiaDinh>();
            CreateMap<ThongTinQuaTrinhCongTac, ThongTinQuaTrinhCongTacDTO>();
            CreateMap<ThongTinQuaTrinhCongTacDTO, ThongTinQuaTrinhCongTac>();


        }
    }
}