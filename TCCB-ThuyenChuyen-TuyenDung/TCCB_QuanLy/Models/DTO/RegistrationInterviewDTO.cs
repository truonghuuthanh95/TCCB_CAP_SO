using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCCB_QuanLy.Models.DTO
{
    public class RegistrationInterviewDTO
    {
        public int Id { get; set; }

       
        public string LastName { get; set; }

       
        public string FirstName { get; set; }      
                      
        public DateTime? DOB { get; set; }
        
        public string SDT { get; set; }

        public int? NV01Quan { get; set; }

        public int? NV02Quan { get; set; }

        public int? NV03Quan { get; set; }       

        public string Email { get; set; }

        public int? MonDuTuyenId { get; set; }

        public int? TrinhDoNgoaiNguId { get; set; }

        public int? TrinhDoTinHocId { get; set; }

        public bool? IsMale { get; set; }

        public int? XepLoaiHocLucId { get; set; }

        public short? NamTotNghiep { get; set; }
       
        public int? ChuyenNganhDaoTaoId { get; set; }

        public bool? IsNienChe { get; set; }

        public double? GPA { get; set; }

        public double? DiemLuanVan { get; set; }

        public int? HinhThucDaoTaoId { get; set; }

        public int? TrinhDaoCaoNhatId { get; set; }
      
        public int? DaiHocDiaDiem { get; set; }
     
        public string TenTruongDaiHoc { get; set; }

        public int? BangTotNghiepId { get; set; }

        public bool? IsHadNghiepVuSupham { get; set; }

        public int? LamViecTrongNganhId { get; set; }
        
        public string NamVaoNghanh { get; set; } = "Không có";

        public string MaNgach { get; set; } = "Không có";

        public string HeSoLuong { get; set; } = "Không có";

        public string MocNangLuongLansau { get; set; } = "Không có";

        public int? NOHNWardId { get; set; }
      
        public string NOHNSoNhaTenDuong { get; set; }

        public int? HKTTWardId { get; set; }
        
        public string HKTTSoNhaTenDuong { get; set; }
    }
}