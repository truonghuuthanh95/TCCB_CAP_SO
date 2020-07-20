using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Models.DTO
{
    public class SoLuongDangKi
    {
        
        public string TenMonDuTuyen { get; set; }
        public int MonDuTuyenId { get; set; }
        public int TruongDuTuyenId { get; set; }
        public string TenTruong { get; set; }
        public int SoLuong { get; set; }
        public int Targets { get; set; }
        public int DaNopHs { get; set; }

    }
    
}

