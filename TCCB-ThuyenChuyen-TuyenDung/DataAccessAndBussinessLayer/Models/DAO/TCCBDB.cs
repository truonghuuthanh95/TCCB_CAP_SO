namespace DataAccessAndBussinessLayer.Models.DAO
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TCCBDB : DbContext
    {
        public TCCBDB()
            : base("name=TCCBDB2")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<BangTotNghiep> BangTotNghieps { get; set; }
        public virtual DbSet<CapTruong> CapTruongs { get; set; }
        public virtual DbSet<ChuyenNganhDaoTao> ChuyenNganhDaoTaos { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<GroupPermission> GroupPermissions { get; set; }
        public virtual DbSet<HinhThucDaoTao> HinhThucDaoTaos { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<LamViecTrongNganh> LamViecTrongNganhs { get; set; }
        public virtual DbSet<MonDuTuyen> MonDuTuyens { get; set; }
        public virtual DbSet<NgayHetHanSuaThongTin> NgayHetHanSuaThongTins { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<RegistrationInterview> RegistrationInterviews { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<TrinhDoCaoNhat> TrinhDoCaoNhats { get; set; }
        public virtual DbSet<TrinhDoNgoaiNgu> TrinhDoNgoaiNgus { get; set; }
        public virtual DbSet<TrinhDoTinHoc> TrinhDoTinHocs { get; set; }
        public virtual DbSet<Truong> Truongs { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }
        public virtual DbSet<ViTriUngTuyen> ViTriUngTuyens { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }
        public virtual DbSet<XepLoaiHocLuc> XepLoaiHocLucs { get; set; }

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

            modelBuilder.Entity<CapTruong>()
                .HasMany(e => e.Truongs)
                .WithOptional(e => e.CapTruong)
                .HasForeignKey(e => e.SchoolDegreeId);

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

            modelBuilder.Entity<MonDuTuyen>()
                .Property(e => e.Code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Province>()
                .HasMany(e => e.Districts)
                .WithRequired(e => e.Province)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Province>()
                .HasMany(e => e.RegistrationInterviews)
                .WithOptional(e => e.Province)
                .HasForeignKey(e => e.DaiHocDiaDiem);

            modelBuilder.Entity<RegistrationInterview>()
                .Property(e => e.TienHoaDon)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TrinhDoCaoNhat>()
                .HasMany(e => e.RegistrationInterviews)
                .WithOptional(e => e.TrinhDoCaoNhat)
                .HasForeignKey(e => e.TrinhDaoCaoNhatId);

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
        }
    }
}
