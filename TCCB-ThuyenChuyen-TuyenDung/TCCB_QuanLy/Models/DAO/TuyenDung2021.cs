namespace TCCB_QuanLy.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TuyenDung2021
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TuyenDung2021()
        {
            TuyenDungNguyenVongs = new HashSet<TuyenDungNguyenVong>();
        }

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

        [StringLength(50)]
        public string TienTo { get; set; }

        public int? DanTocId { get; set; }

        public int? TonGiaoId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CMNDNgayCap { get; set; }

        public int? CMNDNoiCap { get; set; }

        public int? QueQuanProvinceId { get; set; }

        [StringLength(200)]
        public string TinhTrangSucKhoe { get; set; }

        public double? Chieucao { get; set; }

        public double? CanNang { get; set; }

        public int? ThanhPhanBanThanHienTaiId { get; set; }

        [StringLength(50)]
        public string TrinhDoVanHoa { get; set; }

        [StringLength(50)]
        public string SoVanBangChungChiDaiHoc { get; set; }

        public int? DoiTuongUuTien { get; set; }

        [StringLength(50)]
        public string SoVanBangChungChiTinHoc { get; set; }

        [StringLength(50)]
        public string SoVanBangChungChiNgoaiNgu { get; set; }

        public int? TruongHopDacBietId { get; set; }

        public int? TrinhDoNgoaiNguKhacId { get; set; }

        [StringLength(50)]
        public string SoVanBangChungChiNgoaiNguKhac { get; set; }

        public int? ChungChiNghiepVuSuPhamId { get; set; }

        [StringLength(50)]
        public string ChungChiNghiepVuSuPhamSoVanBang { get; set; }

        public int? TrangThaiHosoTuyenDungId { get; set; }

        public string GhiChu { get; set; }

        public string LyDoTuChoi { get; set; }

        public int? TruongDuTuyenId { get; set; }

        public int? NhanNhiemSo { get; set; }

        public bool? IsTrungTuyen { get; set; }

        public int? ThongTinQuaTrinhCongTacId { get; set; }

        public int? ThongTinVeGiaDinhId { get; set; }

        public virtual Account Account { get; set; }

        public virtual Account Account1 { get; set; }

        public virtual BangTotNghiep BangTotNghiep { get; set; }

        public virtual ChungChiNghiepVuSuPham ChungChiNghiepVuSuPham { get; set; }

        public virtual ChuyenNganhDaoTao ChuyenNganhDaoTao { get; set; }

        public virtual DanToc DanToc { get; set; }

        public virtual DoiTuongUuTien DoiTuongUuTien1 { get; set; }

        public virtual HinhThucDaoTao HinhThucDaoTao { get; set; }

        public virtual LamViecTrongNganh LamViecTrongNganh { get; set; }

        public virtual MonDuTuyen MonDuTuyen { get; set; }

        public virtual Province Province { get; set; }

        public virtual Province Province1 { get; set; }

        public virtual Province Province2 { get; set; }

        public virtual School School { get; set; }

        public virtual ThanhPhanBanThanHienTai ThanhPhanBanThanHienTai { get; set; }

        public virtual ThongTinCoBanVeGiaDinh ThongTinCoBanVeGiaDinh { get; set; }

        public virtual ThongTinQuaTrinhCongTac ThongTinQuaTrinhCongTac { get; set; }

        public virtual TonGiao TonGiao { get; set; }

        public virtual TrangThaiHoSoTuyenDung TrangThaiHoSoTuyenDung { get; set; }

        public virtual TrinhDoCaoNhat TrinhDoCaoNhat { get; set; }

        public virtual TrinhDoNgoaiNgu TrinhDoNgoaiNgu { get; set; }

        public virtual TrinhDoNgoaiNguKhac TrinhDoNgoaiNguKhac { get; set; }

        public virtual TrinhDoTinHoc TrinhDoTinHoc { get; set; }

        public virtual TruongHopDacBiet TruongHopDacBiet { get; set; }

        public virtual XepLoaiHocLuc XepLoaiHocLuc { get; set; }

        public virtual Ward Ward { get; set; }

        public virtual Ward Ward1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TuyenDungNguyenVong> TuyenDungNguyenVongs { get; set; }
    }
}
