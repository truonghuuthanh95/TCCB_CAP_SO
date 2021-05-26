namespace TCCB_QuanLy.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KetQuaTuyenDung2020
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string MaTD { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(50)]
        public string DOB { get; set; }

        [StringLength(50)]
        public string GioiTinh { get; set; }

        public int? UuTien { get; set; }

        [StringLength(50)]
        public string ViTriDuTuyen { get; set; }

        [StringLength(200)]
        public string HoiDongXetTuyen { get; set; }

        [StringLength(50)]
        public string ChuyenMon { get; set; }

        [StringLength(50)]
        public string NghiepVu { get; set; }

        [StringLength(50)]
        public string TongDiem { get; set; }

        [StringLength(50)]
        public string CMND { get; set; }

        [StringLength(50)]
        public string DiemUuTien { get; set; }

        public virtual DoiTuongUuTien DoiTuongUuTien { get; set; }
    }
}
