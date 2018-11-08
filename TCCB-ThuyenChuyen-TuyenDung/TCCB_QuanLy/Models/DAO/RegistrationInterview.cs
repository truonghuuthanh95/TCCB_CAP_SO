namespace TCCB_QuanLy.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RegistrationInterview")]
    public partial class RegistrationInterview
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        public DateTime? NgayRaXoat { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [StringLength(15)]
        public string IdentifyCard { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DOB { get; set; }

        [StringLength(12)]
        public string SDT { get; set; }

        public int? NV01Quan { get; set; }

        public int? NV02Quan { get; set; }

        public int? NV03Quan { get; set; }

        public bool? IsPass { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public int? MonDuTuyenId { get; set; }

        public int? TrinhDoNgoaiNguId { get; set; }

        public int? TrinhDoTinHocId { get; set; }

        public bool? IsMale { get; set; }

        public int? XepLoaiHocLucId { get; set; }

        public short? NamTotNghiep { get; set; }

        public int? NguoiTaoHoaDon { get; set; }

        public decimal? TienHoaDon { get; set; }

        public int? ChuyenNganhDaoTaoId { get; set; }

        public bool? IsNienChe { get; set; }

        public double? GPA { get; set; }

        public double? DiemLuanVan { get; set; }

        public int? HinhThucDaoTaoId { get; set; }

        public int? TrinhDaoCaoNhatId { get; set; }

        public int? NguoiRaSoat { get; set; }

        public int? DaiHocDiaDiem { get; set; }

        [StringLength(200)]
        public string TenTruongDaiHoc { get; set; }

        public int? BangTotNghiepId { get; set; }

        public bool? IsHadNghiepVuSupham { get; set; }

        public int? LamViecTrongNganhId { get; set; }

        [StringLength(50)]
        public string NamVaoNghanh { get; set; }

        [StringLength(50)]
        public string MaNgach { get; set; }

        [StringLength(50)]
        public string HeSoLuong { get; set; }

        [StringLength(50)]
        public string MocNangLuongLansau { get; set; }

        public int? NOHNWardId { get; set; }

        [StringLength(200)]
        public string NOHNSoNhaTenDuong { get; set; }

        public int? HKTTWardId { get; set; }

        [StringLength(200)]
        public string HKTTSoNhaTenDuong { get; set; }

        public bool? IsActive { get; set; }

        public virtual Account Account { get; set; }

        public virtual Account Account1 { get; set; }

        public virtual BangTotNghiep BangTotNghiep { get; set; }

        public virtual ChuyenNganhDaoTao ChuyenNganhDaoTao { get; set; }

        public virtual District District { get; set; }

        public virtual District District1 { get; set; }

        public virtual District District2 { get; set; }

        public virtual HinhThucDaoTao HinhThucDaoTao { get; set; }

        public virtual LamViecTrongNganh LamViecTrongNganh { get; set; }

        public virtual MonDuTuyen MonDuTuyen { get; set; }

        public virtual Province Province { get; set; }

        public virtual XepLoaiHocLuc XepLoaiHocLuc { get; set; }

        public virtual TrinhDoNgoaiNgu TrinhDoNgoaiNgu { get; set; }

        public virtual TrinhDoCaoNhat TrinhDoCaoNhat { get; set; }

        public virtual TrinhDoTinHoc TrinhDoTinHoc { get; set; }

        public virtual Ward Ward { get; set; }

        public virtual Ward Ward1 { get; set; }
    }
}
