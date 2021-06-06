﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCCB_QuanLy.Models.DTO
{
    public class RegistrationInterviewDTO
    {
       
        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public DateTime? DOB { get; set; }
        [Required]
        public string SDT { get; set; }
        
        [Required]
        public string Email { get; set; }
        [Required]
        public int MonDuTuyenId { get; set; }
        [Required]
        public int TrinhDoNgoaiNguId { get; set; }
        [Required]
        public int TrinhDoTinHocId { get; set; }
        [Required]
        public bool IsMale { get; set; }
        [Required]
        public int XepLoaiHocLucId { get; set; }
        [Required]
        public string NamTotNghiep { get; set; }
        [Required]
        public int ChuyenNganhDaoTaoId { get; set; }
        [Required]
        public bool IsNienChe { get; set; }
        [Required]
        public double GPA { get; set; }

        public double? DiemLuanVan { get; set; }
        [Required]
        public int HinhThucDaoTaoId { get; set; }
        [Required]
        public int TrinhDaoCaoNhatId { get; set; }
        [Required]
        public int DaiHocDiaDiem { get; set; }
        [Required]
        public string TenTruongDaiHoc { get; set; }
        [Required]
        public int BangTotNghiepId { get; set; }
        [Required]
        //public bool IsHadNghiepVuSupham { get; set; }
        //[Required]
        //public int LamViecTrongNganhId { get; set; }
        public string NamVaoNghanh { get; set; } = "Không có";
        
        public string MaNgach { get; set; } = "Không có";
      
        public string HeSoLuong { get; set; } = "Không có";
       
        public string MocNangLuongLansau { get; set; } = "Không có";
        [Required]
        public int NOHNWardId { get; set; }
        [Required]
        public string NOHNSoNhaTenDuong { get; set; }
        [Required]
        public int HKTTWardId { get; set; }
        [Required]
        public string HKTTSoNhaTenDuong { get; set; }
        [Required]
        public int DanTocId { get; set; }
        [Required]
        public int TonGiaoId { get; set; }
        [Required]
        public string IdentifyCard { get; set; }
        [Required]
        public DateTime CMNDNgayCap { get; set; }
        [Required]
        public int CMNDNoiCap { get; set; }
        [Required]
        public int QueQuanProvinceId { get; set; }
        [Required]
        [StringLength(200)]
        public string TinhTrangSucKhoe { get; set; }
        [Required]
        public double Chieucao { get; set; }
        [Required]
        public double CanNang { get; set; }
        [Required]
        public int ThanhPhanBanThanHienTaiId { get; set; }
        //[Required]
        //[StringLength(50)]
        //public string TrinhDoVanHoa { get; set; }
        [Required]
        [StringLength(50)]
        public string SoVanBangChungChiDaiHoc { get; set; }
        [Required]
        public int DoiTuongUuTien { get; set; }
        [Required]
        [StringLength(50)]
        public string SoVanBangChungChiTinHoc { get; set; }
        [Required]
        [StringLength(50)]
        public string SoVanBangChungChiNgoaiNgu { get; set; }
        [Required]
        public int TruongHopDacBietId { get; set; }
        public int TrinhDoNgoaiNguKhacId { get; set; }

        [StringLength(50)]
        public string SoVanBangChungChiNgoaiNguKhac { get; set; }
        public int ChungChiNghiepVuSuPhamId { get; set; }

        [StringLength(50)]
        public string ChungChiNghiepVuSuPhamSoVanBang { get; set; }
        public int NguyenVong1 { get; set; }

        public int NguyenVong2 { get; set; }
        public int NguyenVong3 { get; set; }

        [StringLength(50)]
        public string NgayCapTinHoc { get; set; }

        [StringLength(50)]
        public string NgayCapNgoaiNgu { get; set; }

        [StringLength(50)]
        public string NgayCapNgoaiNguKhac { get; set; }

        [StringLength(500)]
        public string TinHocTruongDaoTao { get; set; }

        [StringLength(500)]
        public string NgoaiNguTruongDaoTao { get; set; }

        [StringLength(500)]
        public string NgoaiNguKhacTruongDaoTao { get; set; }

        //public int TinHocXepLoai { get; set; }

        //public int NgoaiNguXepLoai { get; set; }

        //public int NgoaiNguKhacXepLoai { get; set; }
    }
}
