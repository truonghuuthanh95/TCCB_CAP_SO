using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TCCB_QuanLy.Models.DTO
{
    public class ThuyenChuyenContainNgoaiTinhDTO
    {
        public int Id { get; set; }
        public string TienTo { get; set; }
        [Column(TypeName = "date")]
        public DateTime NgayTiepNhan { get; set; }
        public string HoTen { get; set; }
        [Column(TypeName = "date")]
        public DateTime NamSinh { get; set; }
        public string CMND { get; set; }
        public string NguoiTiepNhan { get; set; }
        public string DangCongTac { get; set; }
        public string XinChuyenDen { get; set; }

    }
}