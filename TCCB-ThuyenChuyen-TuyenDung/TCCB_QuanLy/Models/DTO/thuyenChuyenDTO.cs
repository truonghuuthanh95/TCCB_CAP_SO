using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCCB_QuanLy.Models.DTO
{
    public class ThuyenChuyenDTO
    {
        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(20)]
        public string CMND { get; set; }

        public bool IsMale { get; set; }

        public DateTime NamSinh { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public int NoisinhWardId { get; set; }

        public int HKTTWardId { get; set; }

        [StringLength(200)]
        public string SoNhaTenDuong { get; set; }

        public int BangTotNghiepId { get; set; }

        public int HinhThucDaoTaoId { get; set; }

        public int ChuyenNganhDaoTaoId { get; set; }

        public int XepLoaiHocLucId { get; set; }

        public string ThongTinQuanHeGiaDinh { get; set; }

        public string ThongTinQuanHeBanThan { get; set; }

        [StringLength(50)]
        public string MaNghach { get; set; }
      
        public DateTime MocNangLuong { get; set; }

        [StringLength(50)]
        public string BacLuong { get; set; }

        [StringLength(50)]
        public string HeSo { get; set; }

        public int DVDCTTruongId { get; set; }

        public int DVDCTMonDayId { get; set; }

        public int DVCDTruongId { get; set; }                  

        [StringLength(50)]
        public string CapDayDVCD { get; set; }

        [StringLength(50)]
        public string CapDayDVDCT { get; set; }

        public DateTime BatDauCongTac { get; set; }

        public int TrinhDoCaoNhatId { get; set; }
    }
}