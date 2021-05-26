namespace TCCB_QuanLy.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TruongNhiemVuThamGiaHDTD")]
    public partial class TruongNhiemVuThamGiaHDTD
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(50)]
        public string NamSinh { get; set; }

        [StringLength(50)]
        public string NamVaoNganh { get; set; }

        [StringLength(100)]
        public string ChucVu { get; set; }

        [StringLength(500)]
        public string ChuyenNganhDaoTao { get; set; }

        [StringLength(500)]
        public string TrinhDoChuyenMon { get; set; }

        public int? SchoolId { get; set; }

        public int? NhiemVuId { get; set; }

        public bool? GioiTinh { get; set; }

        public virtual NhiemVuThamGiaHoiDongTuyenDung NhiemVuThamGiaHoiDongTuyenDung { get; set; }

        public virtual School School { get; set; }
    }
}
