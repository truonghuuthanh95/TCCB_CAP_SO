using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TCCB_QuanLy.Models.DAO
{
    public partial class TCCBDB : DbContext
    {
        public TCCBDB()
            : base("name=TCCBDB6")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountSchool> AccountSchools { get; set; }
        public virtual DbSet<BacLuong> BacLuongs { get; set; }
        public virtual DbSet<BangTotNghiep> BangTotNghieps { get; set; }
        public virtual DbSet<CandidateSchool> CandidateSchools { get; set; }
        public virtual DbSet<CapTruong> CapTruongs { get; set; }
        public virtual DbSet<ChungChiNghiepVuSuPham> ChungChiNghiepVuSuPhams { get; set; }
        public virtual DbSet<ChuyenNganhDaoTao> ChuyenNganhDaoTaos { get; set; }
        public virtual DbSet<DanToc> DanTocs { get; set; }
        public virtual DbSet<DiemThiTuyen> DiemThiTuyens { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<DoiTuongUuTien> DoiTuongUuTiens { get; set; }
        public virtual DbSet<DVQL> DVQLs { get; set; }
        public virtual DbSet<GroupPermission> GroupPermissions { get; set; }
        public virtual DbSet<HinhThucDaoTao> HinhThucDaoTaos { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HoSoHopLe> HoSoHopLes { get; set; }
        public virtual DbSet<KetQuaTuyenDung2020> KetQuaTuyenDung2020 { get; set; }
        public virtual DbSet<LamViecTrongNganh> LamViecTrongNganhs { get; set; }
        public virtual DbSet<LoaiHinh> LoaiHinhs { get; set; }
        public virtual DbSet<MaNgach> MaNgaches { get; set; }
        public virtual DbSet<MonDuTuyen> MonDuTuyens { get; set; }
        public virtual DbSet<NgayHetHanSuaThongTin> NgayHetHanSuaThongTins { get; set; }
        public virtual DbSet<NhiemVuThamGiaHoiDongTuyenDung> NhiemVuThamGiaHoiDongTuyenDungs { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<RegistrationInterview> RegistrationInterviews { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<StatusThuyenChuyen> StatusThuyenChuyens { get; set; }
        public virtual DbSet<StatusTiepNhan> StatusTiepNhans { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ThanhPhanBanThanHienTai> ThanhPhanBanThanHienTais { get; set; }
        public virtual DbSet<ThongTinCoBanVeGiaDinh> ThongTinCoBanVeGiaDinhs { get; set; }
        public virtual DbSet<ThongTinQuaTrinhCongTac> ThongTinQuaTrinhCongTacs { get; set; }
        public virtual DbSet<ThuyenChuyen> ThuyenChuyens { get; set; }
        public virtual DbSet<ThuyenChuyen2020> ThuyenChuyen2020 { get; set; }
        public virtual DbSet<TonGiao> TonGiaos { get; set; }
        public virtual DbSet<TrangThaiHoSoTuyenDung> TrangThaiHoSoTuyenDungs { get; set; }
        public virtual DbSet<TrinhDoCaoNhat> TrinhDoCaoNhats { get; set; }
        public virtual DbSet<TrinhDoNgoaiNgu> TrinhDoNgoaiNgus { get; set; }
        public virtual DbSet<TrinhDoNgoaiNguKhac> TrinhDoNgoaiNguKhacs { get; set; }
        public virtual DbSet<TrinhDoTinHoc> TrinhDoTinHocs { get; set; }
        public virtual DbSet<TruongHopDacBiet> TruongHopDacBiets { get; set; }
        public virtual DbSet<TruongMonDuTuyen> TruongMonDuTuyens { get; set; }
        public virtual DbSet<TruongNhiemVuThamGiaHDTD> TruongNhiemVuThamGiaHDTDs { get; set; }
        public virtual DbSet<TuyenDung2020> TuyenDung2020 { get; set; }
        public virtual DbSet<TuyenDung2021> TuyenDung2021 { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }
        public virtual DbSet<ViTriUngTuyen> ViTriUngTuyens { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }
        public virtual DbSet<XepLoaiHocLuc> XepLoaiHocLucs { get; set; }
        public virtual DbSet<ThuyenChuyenNgoaiTinh> ThuyenChuyenNgoaiTinhs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.RegistrationInterviews)
                .WithOptional(e => e.Account)
                .HasForeignKey(e => e.NguoiTaoHoaDon);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.RegistrationInterviews1)
                .WithOptional(e => e.Account1)
                .HasForeignKey(e => e.NguoiRaSoat);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.ThuyenChuyen2020)
                .WithOptional(e => e.Account)
                .HasForeignKey(e => e.NguoiTiepNhanId);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.ThuyenChuyenNgoaiTinhs)
                .WithOptional(e => e.Account)
                .HasForeignKey(e => e.NguoiTiepNhanId);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.TuyenDung2020)
                .WithOptional(e => e.Account)
                .HasForeignKey(e => e.NguoiTaoHoaDon);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.TuyenDung20201)
                .WithOptional(e => e.Account1)
                .HasForeignKey(e => e.NguoiRaSoat);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.TuyenDung2021)
                .WithOptional(e => e.Account)
                .HasForeignKey(e => e.NguoiTaoHoaDon);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.TuyenDung20211)
                .WithOptional(e => e.Account1)
                .HasForeignKey(e => e.NguoiRaSoat);

            modelBuilder.Entity<AccountSchool>()
                .HasMany(e => e.CandidateSchools)
                .WithOptional(e => e.AccountSchool)
                .HasForeignKey(e => e.SchoolId);

            modelBuilder.Entity<BacLuong>()
                .Property(e => e.Loai)
                .IsUnicode(false);

            modelBuilder.Entity<BacLuong>()
                .Property(e => e.Nhom)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .HasMany(e => e.RegistrationInterviews)
                .WithOptional(e => e.District)
                .HasForeignKey(e => e.NV01Quan);

            modelBuilder.Entity<District>()
                .HasMany(e => e.RegistrationInterviews1)
                .WithOptional(e => e.District1)
                .HasForeignKey(e => e.NV02Quan);

            modelBuilder.Entity<District>()
                .HasMany(e => e.RegistrationInterviews2)
                .WithOptional(e => e.District2)
                .HasForeignKey(e => e.NV03Quan);

            modelBuilder.Entity<District>()
                .HasMany(e => e.Wards)
                .WithRequired(e => e.District)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DoiTuongUuTien>()
                .HasMany(e => e.KetQuaTuyenDung2020)
                .WithOptional(e => e.DoiTuongUuTien)
                .HasForeignKey(e => e.UuTien);

            modelBuilder.Entity<DoiTuongUuTien>()
                .HasMany(e => e.RegistrationInterviews)
                .WithOptional(e => e.DoiTuongUuTien1)
                .HasForeignKey(e => e.DoiTuongUuTien);

            modelBuilder.Entity<DoiTuongUuTien>()
                .HasMany(e => e.TuyenDung2020)
                .WithOptional(e => e.DoiTuongUuTien1)
                .HasForeignKey(e => e.DoiTuongUuTien);

            modelBuilder.Entity<DoiTuongUuTien>()
                .HasMany(e => e.TuyenDung2021)
                .WithOptional(e => e.DoiTuongUuTien1)
                .HasForeignKey(e => e.DoiTuongUuTien);

            modelBuilder.Entity<LoaiHinh>()
                .HasMany(e => e.Schools)
                .WithOptional(e => e.LoaiHinh1)
                .HasForeignKey(e => e.LoaiHinh);

            modelBuilder.Entity<MaNgach>()
                .Property(e => e.Loai)
                .IsUnicode(false);

            modelBuilder.Entity<MaNgach>()
                .Property(e => e.Nhom)
                .IsUnicode(false);

            modelBuilder.Entity<MonDuTuyen>()
                .Property(e => e.Code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MonDuTuyen>()
                .HasMany(e => e.ThuyenChuyens)
                .WithOptional(e => e.MonDuTuyen)
                .HasForeignKey(e => e.DVDCTMonDayId);

            modelBuilder.Entity<MonDuTuyen>()
                .HasMany(e => e.ThuyenChuyen2020)
                .WithOptional(e => e.MonDuTuyen)
                .HasForeignKey(e => e.DVDCTMonDayId);

            modelBuilder.Entity<MonDuTuyen>()
                .HasMany(e => e.ThuyenChuyenNgoaiTinhs)
                .WithOptional(e => e.MonDuTuyen)
                .HasForeignKey(e => e.DVDCTMonDayId);

            modelBuilder.Entity<NhiemVuThamGiaHoiDongTuyenDung>()
                .HasMany(e => e.TruongNhiemVuThamGiaHDTDs)
                .WithOptional(e => e.NhiemVuThamGiaHoiDongTuyenDung)
                .HasForeignKey(e => e.NhiemVuId);

            modelBuilder.Entity<Province>()
                .HasMany(e => e.Districts)
                .WithRequired(e => e.Province)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Province>()
                .HasMany(e => e.RegistrationInterviews)
                .WithOptional(e => e.Province)
                .HasForeignKey(e => e.DaiHocDiaDiem);

            modelBuilder.Entity<Province>()
                .HasMany(e => e.RegistrationInterviews1)
                .WithOptional(e => e.Province1)
                .HasForeignKey(e => e.CMNDNoiCap);

            modelBuilder.Entity<Province>()
                .HasMany(e => e.RegistrationInterviews2)
                .WithOptional(e => e.Province2)
                .HasForeignKey(e => e.QueQuanProvinceId);

            modelBuilder.Entity<Province>()
                .HasMany(e => e.ThuyenChuyen2020)
                .WithOptional(e => e.Province)
                .HasForeignKey(e => e.DVDCTProvinceId);

            modelBuilder.Entity<Province>()
                .HasMany(e => e.ThuyenChuyen20201)
                .WithOptional(e => e.Province1)
                .HasForeignKey(e => e.DVCDProvinceId);

            modelBuilder.Entity<Province>()
                .HasMany(e => e.ThuyenChuyenNgoaiTinhs)
                .WithOptional(e => e.Province)
                .HasForeignKey(e => e.DVDCTProvinceId);

            modelBuilder.Entity<Province>()
                .HasMany(e => e.TuyenDung2020)
                .WithOptional(e => e.Province)
                .HasForeignKey(e => e.DaiHocDiaDiem);

            modelBuilder.Entity<Province>()
                .HasMany(e => e.TuyenDung20201)
                .WithOptional(e => e.Province1)
                .HasForeignKey(e => e.CMNDNoiCap);

            modelBuilder.Entity<Province>()
                .HasMany(e => e.TuyenDung20202)
                .WithOptional(e => e.Province2)
                .HasForeignKey(e => e.QueQuanProvinceId);

            modelBuilder.Entity<Province>()
                .HasMany(e => e.TuyenDung2021)
                .WithOptional(e => e.Province)
                .HasForeignKey(e => e.DaiHocDiaDiem);

            modelBuilder.Entity<Province>()
                .HasMany(e => e.TuyenDung20211)
                .WithOptional(e => e.Province1)
                .HasForeignKey(e => e.CMNDNoiCap);

            modelBuilder.Entity<Province>()
                .HasMany(e => e.TuyenDung20212)
                .WithOptional(e => e.Province2)
                .HasForeignKey(e => e.QueQuanProvinceId);

            modelBuilder.Entity<RegistrationInterview>()
                .Property(e => e.TienHoaDon)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RegistrationInterview>()
                .HasMany(e => e.CandidateSchools)
                .WithOptional(e => e.RegistrationInterview)
                .HasForeignKey(e => e.CandidateId);

            modelBuilder.Entity<RegistrationInterview>()
                .HasMany(e => e.HoSoHopLes)
                .WithOptional(e => e.RegistrationInterview)
                .HasForeignKey(e => e.HoSoId);

            modelBuilder.Entity<School>()
                .HasMany(e => e.ThuyenChuyens)
                .WithOptional(e => e.School)
                .HasForeignKey(e => e.DVDCTTruongId);

            modelBuilder.Entity<School>()
                .HasMany(e => e.ThuyenChuyens1)
                .WithOptional(e => e.School1)
                .HasForeignKey(e => e.DVCDTruongId);

            modelBuilder.Entity<School>()
                .HasMany(e => e.ThuyenChuyen2020)
                .WithOptional(e => e.School)
                .HasForeignKey(e => e.DVCDTruongId);

            modelBuilder.Entity<School>()
                .HasMany(e => e.ThuyenChuyen20201)
                .WithOptional(e => e.School1)
                .HasForeignKey(e => e.DVDCTTruongId);

            modelBuilder.Entity<School>()
                .HasMany(e => e.ThuyenChuyenNgoaiTinhs)
                .WithOptional(e => e.School)
                .HasForeignKey(e => e.DVCDTruongId);

            modelBuilder.Entity<School>()
                .HasMany(e => e.TuyenDung2020)
                .WithOptional(e => e.School)
                .HasForeignKey(e => e.TruongDuTuyenId);

            modelBuilder.Entity<School>()
                .HasMany(e => e.TuyenDung2021)
                .WithOptional(e => e.School)
                .HasForeignKey(e => e.TruongDuTuyenId);

            modelBuilder.Entity<StatusThuyenChuyen>()
                .HasMany(e => e.ThuyenChuyens)
                .WithOptional(e => e.StatusThuyenChuyen)
                .HasForeignKey(e => e.StatusId);

            modelBuilder.Entity<StatusThuyenChuyen>()
                .HasMany(e => e.ThuyenChuyen2020)
                .WithOptional(e => e.StatusThuyenChuyen)
                .HasForeignKey(e => e.StatusId);

            modelBuilder.Entity<StatusThuyenChuyen>()
                .HasMany(e => e.ThuyenChuyenNgoaiTinhs)
                .WithOptional(e => e.StatusThuyenChuyen)
                .HasForeignKey(e => e.StatusId);

            modelBuilder.Entity<ThongTinCoBanVeGiaDinh>()
                .HasMany(e => e.TuyenDung2021)
                .WithOptional(e => e.ThongTinCoBanVeGiaDinh)
                .HasForeignKey(e => e.ThongTinVeGiaDinhId);

            modelBuilder.Entity<TrinhDoCaoNhat>()
                .HasMany(e => e.RegistrationInterviews)
                .WithOptional(e => e.TrinhDoCaoNhat)
                .HasForeignKey(e => e.TrinhDaoCaoNhatId);

            modelBuilder.Entity<TrinhDoCaoNhat>()
                .HasMany(e => e.TuyenDung2020)
                .WithOptional(e => e.TrinhDoCaoNhat)
                .HasForeignKey(e => e.TrinhDaoCaoNhatId);

            modelBuilder.Entity<TrinhDoCaoNhat>()
                .HasMany(e => e.TuyenDung2021)
                .WithOptional(e => e.TrinhDoCaoNhat)
                .HasForeignKey(e => e.TrinhDaoCaoNhatId);

            modelBuilder.Entity<TuyenDung2020>()
                .Property(e => e.TienHoaDon)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TuyenDung2021>()
                .Property(e => e.TienHoaDon)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ViTriUngTuyen>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<ViTriUngTuyen>()
                .Property(e => e.IsActive)
                .IsFixedLength();

            modelBuilder.Entity<ViTriUngTuyen>()
                .HasMany(e => e.MonDuTuyens)
                .WithOptional(e => e.ViTriUngTuyen)
                .HasForeignKey(e => e.PositionInterviewId);

            modelBuilder.Entity<Ward>()
                .HasMany(e => e.RegistrationInterviews)
                .WithOptional(e => e.Ward)
                .HasForeignKey(e => e.NOHNWardId);

            modelBuilder.Entity<Ward>()
                .HasMany(e => e.RegistrationInterviews1)
                .WithOptional(e => e.Ward1)
                .HasForeignKey(e => e.HKTTWardId);

            modelBuilder.Entity<Ward>()
                .HasMany(e => e.ThuyenChuyens)
                .WithOptional(e => e.Ward)
                .HasForeignKey(e => e.NoisinhWardId);

            modelBuilder.Entity<Ward>()
                .HasMany(e => e.ThuyenChuyens1)
                .WithOptional(e => e.Ward1)
                .HasForeignKey(e => e.HKTTWardId);

            modelBuilder.Entity<Ward>()
                .HasMany(e => e.ThuyenChuyen2020)
                .WithOptional(e => e.Ward)
                .HasForeignKey(e => e.NoisinhWardId);

            modelBuilder.Entity<Ward>()
                .HasMany(e => e.ThuyenChuyen20201)
                .WithOptional(e => e.Ward1)
                .HasForeignKey(e => e.HKTTWardId);

            modelBuilder.Entity<Ward>()
                .HasMany(e => e.TuyenDung2020)
                .WithOptional(e => e.Ward)
                .HasForeignKey(e => e.NOHNWardId);

            modelBuilder.Entity<Ward>()
                .HasMany(e => e.TuyenDung20201)
                .WithOptional(e => e.Ward1)
                .HasForeignKey(e => e.HKTTWardId);

            modelBuilder.Entity<Ward>()
                .HasMany(e => e.TuyenDung2021)
                .WithOptional(e => e.Ward)
                .HasForeignKey(e => e.NOHNWardId);

            modelBuilder.Entity<Ward>()
                .HasMany(e => e.TuyenDung20211)
                .WithOptional(e => e.Ward1)
                .HasForeignKey(e => e.HKTTWardId);

            modelBuilder.Entity<Ward>()
                .HasMany(e => e.ThuyenChuyenNgoaiTinhs)
                .WithOptional(e => e.Ward)
                .HasForeignKey(e => e.NoisinhWardId);

            modelBuilder.Entity<Ward>()
                .HasMany(e => e.ThuyenChuyenNgoaiTinhs1)
                .WithOptional(e => e.Ward1)
                .HasForeignKey(e => e.HKTTWardId);
        }
    }
}
