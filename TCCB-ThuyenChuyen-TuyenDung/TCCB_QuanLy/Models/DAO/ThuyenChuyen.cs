namespace TCCB_QuanLy.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThuyenChuyen")]
    public partial class ThuyenChuyen
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(20)]
        public string CMND { get; set; }

        public bool? IsMale { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NamSinh { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public int? NoisinhWardId { get; set; }

        public int? HKTTWardId { get; set; }

        [StringLength(200)]
        public string SoNhaTenDuong { get; set; }

        public int? BangTotNghiepId { get; set; }

        public int? HinhThucDaoTaoId { get; set; }

        public int? ChuyenNganhDaoTaoId { get; set; }

        public int? XepLoaiHocLucId { get; set; }

        public string ThongTinQuanHeGiaDinh { get; set; }

        public string ThongTinQuanHeBanThan { get; set; }

        [StringLength(50)]
        public string MaNghach { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MocNangLuong { get; set; }

        [StringLength(50)]
        public string BacLuong { get; set; }

        [StringLength(50)]
        public string HeSo { get; set; }

        public int? DVDCTTruongId { get; set; }

        public int? DVDCTMonDayId { get; set; }

        public int? DVCDTruongId { get; set; }

        public int? DVCDMonDayId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public int? StatusId { get; set; }

        public int? NguoiTiepNhanId { get; set; }

        [StringLength(50)]
        public string CapDayDVCD { get; set; }

        [StringLength(50)]
        public string CapDayDVDCT { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BatDauCongTac { get; set; }

        public int? TrinhDoCaoNhatId { get; set; }

        public virtual BangTotNghiep BangTotNghiep { get; set; }

        public virtual ChuyenNganhDaoTao ChuyenNganhDaoTao { get; set; }

        public virtual HinhThucDaoTao HinhThucDaoTao { get; set; }

        public virtual MonDuTuyen MonDuTuyen { get; set; }

        public virtual School School { get; set; }

        public virtual School School1 { get; set; }

        public virtual StatusThuyenChuyen StatusThuyenChuyen { get; set; }

        public virtual TrinhDoCaoNhat TrinhDoCaoNhat { get; set; }

        public virtual Ward Ward { get; set; }

        public virtual Ward Ward1 { get; set; }

        public virtual XepLoaiHocLuc XepLoaiHocLuc { get; set; }
    }
}
