﻿using DataAccessAndBussinessLayer.Repositories.Implements;
using DataAccessAndBussinessLayer.Repositories.Interfaces;
using System.Web.Mvc;
using Unity;
using Unity.Lifetime;

namespace TCCB_ThuyenChuyen_TuyenDung.App_Start
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
            container.RegisterType<ICapTruongRepository, CapTruongRepository>(new HierarchicalLifetimeManager());
                  
        }
    }
}