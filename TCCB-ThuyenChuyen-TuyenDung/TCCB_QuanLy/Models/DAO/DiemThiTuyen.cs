namespace TCCB_QuanLy.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiemThiTuyen")]
    public partial class DiemThiTuyen
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string MaVong2 { get; set; }

        [StringLength(50)]
        public string ViTriDangKy { get; set; }

        [StringLength(50)]
        public string HoVaTen { get; set; }

        [StringLength(50)]
        public string DOB { get; set; }

        [StringLength(50)]
        public string CMND { get; set; }

        [StringLength(500)]
        public string DoiTuongUuTien { get; set; }

        [StringLength(500)]
        public string TruongHopDacBiet { get; set; }

        [StringLength(50)]
        public string DiemChuyenMonVaNgiepVu { get; set; }

        [StringLength(50)]
        public string DiemUuTien { get; set; }

        [StringLength(50)]
        public string KetQua { get; set; }

        [StringLength(50)]
        public string TongDiem { get; set; }
    }
}
