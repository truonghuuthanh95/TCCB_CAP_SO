using System;
using System.Linq;
using TCCB_QuanLy.Repositories.Interfaces;
using TCCB_QuanLy.Models.DAO;
using System.Data.Entity;
using System.Collections.Generic;
using TCCB_QuanLy.Models.DTO;

namespace TCCB_QuanLy.Repositories.Implements
{
	public class RegistrationInterviewRepository : IRegistrationInterviewRepository
	{
		TCCBDB _db;

		public RegistrationInterviewRepository(TCCBDB db)
		{
			_db = db;
		}

		public TuyenDung2021 GetTuyenDungById(int id)
		{
			TuyenDung2021 TuyenDung = _db.TuyenDung2021
			   .SingleOrDefault(s => s.Id == id);

			return TuyenDung;
		}

		public TuyenDung2021 GetTuyenDungByIdAndIdentifyCard(string id, string identifyCard)
		{
			TuyenDung2021 TuyenDung = _db.TuyenDung2021
				.Include("Ward.District")
				.Include("Ward1.District")
				.SingleOrDefault(s => s.TienTo + s.Id.ToString() == id.ToUpper());
			if (TuyenDung == null || TuyenDung.IdentifyCard.Trim() != identifyCard)
			{
				return null;

			}
			return TuyenDung;

		}


		public TuyenDung2021 GetTuyenDungByIdWithDetail(int id)
		{
			TuyenDung2021 TuyenDung = _db.TuyenDung2021
				.Include("Ward.District.Province")
				.Include("Ward1.District.Province")
				.Include("BangTotNghiep")
				.Include("TrinhDoNgoaiNgu")
				.Include("XepLoaiHocLuc")
				.Include("TrinhDoCaoNhat")
				.Include("TrinhDoTinHoc")
				.Include("ChuyenNganhDaoTao")
				.Include("LamViecTrongNganh")
				.Include("MonDuTuyen.ViTriUngTuyen")
				.Include("HinhThucDaoTao")
				.Include("Province")
				
				.Include("TonGiao")
				.Include("DanToc")
				.Include("ThanhPhanBanThanHienTai")
				.Include("DoiTuongUuTien1")
				.Include("TruongHopDacBiet")
				.Include("TrinhDoNgoaiNguKhac")
				.Include("ChungChiNghiepVuSuPham")
				.Include("Province1")
				.Include("Province2")
				.Include("School")
								.Include("School1")
				.Include("School2")

				.SingleOrDefault(s => s.Id == id);
			return TuyenDung;
		}

		public TuyenDung2021 CapNhatTuyenDung(TuyenDung2021 TuyenDung)
		{
			_db.Entry(TuyenDung).State = EntityState.Modified;

			_db.SaveChanges();

			return TuyenDung;
		}

		public TuyenDung2021 TaoMoiUngVien(TuyenDung2021 TuyenDung)
		{
			_db.TuyenDung2021.Add(TuyenDung);
			_db.SaveChanges();
			return TuyenDung;


		}

		public List<TuyenDung2021> GetTuyenDungsByCmnd(string cmnd)
		{
			List<TuyenDung2021> TuyenDungs = _db.TuyenDung2021.Where(s => s.IdentifyCard.Trim() == cmnd.Trim()).OrderByDescending(s => s.CreatedAt).ToList();
			return TuyenDungs;
		}

		public int GetTuyenDungsDaDangkiSoLuong()
		{
			int count = _db.TuyenDung2021.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null)).Count();
			return count;
		}

		public List<TuyenDung2021> GetTuyenDungsDaDangKi()
		{
			List<TuyenDung2021> TuyenDungs = _db.TuyenDung2021.Include("Account").Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null)).ToList();
			return TuyenDungs;
		}

		public List<TuyenDung2021> GetTuyenDungsChuaCapNhat()
		{
			List<TuyenDung2021> TuyenDungs = _db.TuyenDung2021.Include("Account").Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null) && s.UpdatedAt == null).ToList();
			return TuyenDungs;
		}

		public List<TuyenDung2021> GetTuyenDungsDaHoanThanh()
		{
			List<TuyenDung2021> TuyenDungs = _db.TuyenDung2021.Include("Account").Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null) && s.UpdatedAt != null).ToList();
			return TuyenDungs;
		}
		public List<TuyenDung2021> GetTuyenDungsDaHoanThanhWithDetail(int? id)
		{
            List<TuyenDung2021> TuyenDungs = new List<TuyenDung2021>();
            if (id == null)
            {
                TuyenDungs = _db.TuyenDung2021
				.Include("Ward.District.Province")
                .Include("Ward1.District.Province")
                .Include("BangTotNghiep")
                .Include("TrinhDoNgoaiNgu")
                .Include("XepLoaiHocLuc")
                .Include("TrinhDoCaoNhat")
                .Include("TrinhDoTinHoc")
                .Include("ChuyenNganhDaoTao")
                .Include("LamViecTrongNganh")
                .Include("MonDuTuyen.ViTriUngTuyen")
                .Include("HinhThucDaoTao")
                .Include("Province")
                .Include("TonGiao")
                .Include("DanToc")
                .Include("ThanhPhanBanThanHienTai")
                .Include("DoiTuongUuTien1")
                .Include("TruongHopDacBiet")
                .Include("TrinhDoNgoaiNguKhac")
                .Include("ChungChiNghiepVuSuPham")
                .Include("Province1")
                .Include("Province2")
                .Include("Account")
                .Include("School")
                .Include("TrangThaiHosoTuyenDung")
                .ToList();
            }
            else
            {
                TuyenDungs = _db.TuyenDung2021
				.Include("Ward.District.Province")
                .Include("Ward1.District.Province")
                .Include("BangTotNghiep")
                .Include("TrinhDoNgoaiNgu")
                .Include("XepLoaiHocLuc")
                .Include("TrinhDoCaoNhat")
                .Include("TrinhDoTinHoc")
                .Include("ChuyenNganhDaoTao")
                .Include("LamViecTrongNganh")
                .Include("MonDuTuyen.ViTriUngTuyen")
                .Include("HinhThucDaoTao")
                .Include("Province")
                .Include("TonGiao")
                .Include("DanToc")
                .Include("ThanhPhanBanThanHienTai")
                .Include("DoiTuongUuTien1")
                .Include("TruongHopDacBiet")
                .Include("TrinhDoNgoaiNguKhac")
                .Include("ChungChiNghiepVuSuPham")
                .Include("Province1")
                .Include("Province2")
                .Include("Account")
                .Include("School")
                .Include("TrangThaiHosoTuyenDung")
                .Where(s => s.TrangThaiHosoTuyenDungId == id)
                .ToList();
            }
			
			return TuyenDungs;
		}
		public int GetTuyenDungsChuaCapNhatSoLuong()
		{
			int count = _db.TuyenDung2021.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null) && s.UpdatedAt == null).Count();
			return count;
		}

		public int GetTuyenDungsDaHoanThanhSoLuong()
		{
			int count = _db.TuyenDung2021.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null) && s.UpdatedAt != null).Count();
			return count;
		}

		public int GetTuyenDungsHopLeSoLuong()
		{
			int count = _db.TuyenDung2021.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && s.TrangThaiHosoTuyenDungId == 1 && (s.IsActive == true || s.IsActive == null)).Count();
			return count;
		}

		//public List<HoSoHopLe> GetTuyenDungsHopLe()
		//{
		//    List<HoSoHopLe> hoSoHopLes = _db.HoSoHopLes.Include("TuyenDung").Include("TuyenDung.Account1").Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && s.TuyenDung.TrangThaiHosoTuyenDungId == 1 && (s.TuyenDung.IsActive == true || s.TuyenDung.IsActive == null)).ToList();
		//    return hoSoHopLes;
		//}

		public List<RegistrationInterviewStatusRegistedCountDTO> GetSoluongDangkyTheoViTriUngTuyen()
		{
			var TuyenDungs = _db.TuyenDung2021
				.Where(s => s.IsActive == true && s.MonDuTuyenId != null)
				.Include("MonDuTuyen")
				.GroupBy(s => s.MonDuTuyenId)
				.Select(s => new RegistrationInterviewStatusRegistedCountDTO { ViTriUngTuyen = s.Key.ToString(), Quantity = s.Count(), Targets = 0 }).ToList();
			return TuyenDungs;
		}

		public TuyenDung2021 GetTuyenDungByTienToId(string id)
		{
			TuyenDung2021 TuyenDung = _db.TuyenDung2021.Include("Account1").Where(s => s.TienTo + s.Id.ToString() == id).SingleOrDefault();
			return TuyenDung;
		}

		public List<TuyenDung2021> GetTuyenDungsIsCheckByAccountId(int id)
		{
			List<TuyenDung2021> TuyenDungs = _db.TuyenDung2021.Where(s => s.NguoiRaSoat == id).ToList();
			return TuyenDungs;
		}

		//public List<HoSoHopLe> GetTuyenDungsHopLeWithDetail()
		//{
		//    List<HoSoHopLe> hoSoHopLes = _db.HoSoHopLes
		//        .Include("TuyenDung")
		//        .Include("TuyenDung.Ward.District.Province")
		//        .Include("TuyenDung.Ward1.District.Province")
		//        .Include("TuyenDung.BangTotNghiep")
		//        .Include("TuyenDung.TrinhDoNgoaiNgu")
		//        .Include("TuyenDung.XepLoaiHocLuc")
		//        .Include("TuyenDung.TrinhDoCaoNhat")
		//        .Include("TuyenDung.TrinhDoTinHoc")
		//        .Include("TuyenDung.ChuyenNganhDaoTao")
		//        .Include("TuyenDung.LamViecTrongNganh")
		//        .Include("TuyenDung.MonDuTuyen.ViTriUngTuyen")
		//        .Include("TuyenDung.HinhThucDaoTao")
		//        .Include("TuyenDung.Province")
		//        .Include("TuyenDung.District")
		//        .Include("TuyenDung.District1")
		//        .Include("TuyenDung.District2")
		//        .Include("TuyenDung.TonGiao")
		//        .Include("TuyenDung.DanToc")
		//        .Include("TuyenDung.ThanhPhanBanThanHienTai")
		//        .Include("TuyenDung.DoiTuongUuTien1")
		//        .Include("TuyenDung.TruongHopDacBiet")
		//        .Include("TuyenDung.TrinhDoNgoaiNguKhac")
		//        .Include("TuyenDung.ChungChiNghiepVuSuPham")
		//        .Include("TuyenDung.Province1")
		//        .Include("TuyenDung.Province2")
		//        .Include("TuyenDung.Account")
		//        .Include("TuyenDung.Account1")
		//        .Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && s.tuyend.TrangThaiHosoTuyenDungId == 1 && (s.TuyenDung.IsActive == true || s.TuyenDung.IsActive == null)).ToList();
		//    return hoSoHopLes;
		//}

		public int GetTuyenDungsDaRaXoatSoLuong()
		{
			int count = _db.TuyenDung2021.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null) && s.NguoiRaSoat != null).Count();
			return count;
		}

		public int GetTuyenDungsKhongHopLeSoLuong()
		{
			int count = _db.TuyenDung2021.Where(s => s.CreatedAt.Value.Year == DateTime.Now.Year && (s.IsActive == true || s.IsActive == null) && s.TrangThaiHosoTuyenDungId == 3).Count();
			return count;
		}

		public List<HoSoHopLe> GetTuyenDungsHopLe()
		{
			throw new NotImplementedException();
		}

		public List<HoSoHopLe> GetTuyenDungsHopLeWithDetail()
		{
			throw new NotImplementedException();
		}

		public TuyenDung2021 GetTuyenDungByCMND(string cmnd)
		{
			TuyenDung2021 tuyenDung = _db.TuyenDung2021.Where(s => s.IdentifyCard == cmnd.Trim()).SingleOrDefault();
			return tuyenDung;
		}

		public List<TuyenDung2021> GetTuyenDungBySchoolID(int schoolID)
		{
			List<TuyenDung2021> tuyenDung2020s = _db.TuyenDung2021.AsNoTracking().Include("MonDuTuyen.ViTriUngTuyen")
				.Include("TrangThaiHosoTuyenDung").Where(s => s.School.Id == schoolID).ToList();
			return tuyenDung2020s;
		}

		public List<TuyenDung2021> GetTuyenDungsByStatus(int? id)
		{
			List<TuyenDung2021> tuyenDung2020s = new List<TuyenDung2021>();
			if (id == null)
			{
				tuyenDung2020s = _db.TuyenDung2021.AsNoTracking()
				.Include("School")
				.Include("MonDuTuyen.ViTriUngTuyen")
				.Include("TrangThaiHosoTuyenDung")
				.ToList();
			}
			else
			{
				tuyenDung2020s = _db.TuyenDung2021.AsNoTracking()
								.Include("School")
								.Include("MonDuTuyen.ViTriUngTuyen")
								.Include("TrangThaiHosoTuyenDung")
								.Where(s => s.TrangThaiHosoTuyenDungId == id).ToList();
			}
			
			return tuyenDung2020s;
		}

		public List<SoLuongDangKi> GetTinhHinhDangKi()
		{
			List<SoLuongDangKi> soLuongDangKis  = _db.Database.SqlQuery<SoLuongDangKi>(@"
SELECT s1.MonDuTuyenId,
	   s3.Name AS 'TenMonDuTuyen',
	   s2.Id,
	   s2.TenTruong,
	   ISNULL(s1.SoLuong, 0) AS 'SoLuong',
	   ISNULL(s1.Targets, 0) AS 'Targets',
	   ISNULL(s4.DaNopHs, 0) AS 'DaNopHs'
FROM
(
	SELECT s1.MonDuTuyenId,
		   s1.SchoolId,
		   s2.SoLuong,
		   s1.Targets
	FROM [TruongMonDuTuyen] AS s1
		 LEFT JOIN
	(
		SELECT MonDuTuyenId,
			   TruongDuTuyenId,
			   COUNT(TruongDuTuyenId) AS 'SoLuong'
		FROM [TuyenDung2021] AS s1,
			 School AS s2
		WHERE s1.TruongDuTuyenId = s2.Id
		GROUP BY s1.[TruongDuTuyenId],
				 s1.MonDuTuyenId
	) AS s2 ON s1.Schoolid = s2.TruongDuTuyenId
			   AND s1.MonDuTuyenId = s2.MonDuTuyenId
) AS s1
INNER JOIN School AS s2 ON s1.SchoolId = s2.Id
INNER JOIN MonDuTuyen AS s3 ON s1.MonDuTuyenId = s3.Id
LEFT JOIN
(
	SELECT MonDuTuyenId,
		   TruongDuTuyenId,
		   COUNT(TruongDuTuyenId) AS 'DaNopHs'
	FROM [TuyenDung2021] AS s1,
		 School AS s2
	WHERE s1.TruongDuTuyenId = s2.Id
		  AND s1.[TrangThaiHosoTuyenDungId] IS NOT NULL
	GROUP BY s1.[TruongDuTuyenId],
			 s1.MonDuTuyenId
) AS s4 ON s1.SchoolId = s4.[TruongDuTuyenId] AND s4.MonDuTuyenId = s1.MonDuTuyenId").ToList();
			return soLuongDangKis;
		}
	}
}