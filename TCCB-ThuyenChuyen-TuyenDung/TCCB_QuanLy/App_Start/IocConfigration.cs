using TCCB_QuanLy.Repositories.Implements;
using TCCB_QuanLy.Repositories.Interfaces;
using System.Web.Mvc;
using Unity;
using Unity.Lifetime;
namespace TCCB_QuanLy.App_Start
{
    public static class IocConfigration
    {
        public static void ConfigrationIocContainer()
        {
            IUnityContainer container = new UnityContainer();
            registerService(container);
            DependencyResolver.SetResolver(new UnityResolver(container));

        }

        private static void registerService(IUnityContainer container)
        {
            container.RegisterType<IHoaDonRepository, HoaDonRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IRegistrationInterviewRepository, RegistrationInterviewRepository>();
            container.RegisterType<IDistrictRepository, DistrictRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IProvinceRepository, ProvinceRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IWardRepository, WardRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IMonDuTuyenRepository, MonDuTuyenRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IXepLoaiHocLucRepository, XepLoaiHocLucRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IChuyenNganhDaoTaoRepository, ChuyenNganhDaoTaoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IHinhThucDaoTaoRepository, HinhThucDaoTaoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITrinhDoNgoaiNguRepository, TrinhDoNgoaiNguRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITrinhDoTinHocRepository, TrinhDoTinHocRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITrinhDoCaoNhatRepository, TrinhDoCaoNhatRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IBangTotNghiepRepository, BangTotNghiepRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ILamViecTrongNganhRepository, LamViecTrongNganhRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserPermissionRepository, UserPermissionRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPermissionRepository, PermissionRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IGroupPermissionRepository, GroupPermissionRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IAccountRepository, AccountRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICapTruongRepository, CapTruongRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISchoolRepository, SchoolRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IThuyenChuyenRepository, ThuyenChuyenRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IMaNgachRepository, MaNgachRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IBacLuongRepository, BacLuongRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IDoiTuongUuTienRepository, DoiTuongUuTienRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IDanTocRepository, DanTocRopository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITonGiaoRepository, TonGiaoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IThanhPhanBanThanHienTaiRepository, ThanhPhanBanThanHienTaiRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITruongHopDacBietRepository, TruongHopDacBietRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITrinhDoNgoaiNguKhacReposittory, TrinhDoNgoaiNguKhacReposittory>(new HierarchicalLifetimeManager());
            container.RegisterType<IChungChiNghiepVuSuPhamRepository, ChungChiNghiepVuSuPhamRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IHoSoHopLeRepository, HoSoHopLeRepository>(new HierarchicalLifetimeManager());
        }
    }
}