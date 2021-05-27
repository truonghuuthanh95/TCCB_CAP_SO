using TCCB_QuanLy.Models.DAO;
using System.Collections.Generic;
using TCCB_QuanLy.Models.DTO;

namespace TCCB_QuanLy.Repositories.Interfaces
{
    public interface IRegistrationInterviewRepository
    {
        TuyenDung2021 TaoMoiUngVien(TuyenDung2021 TuyenDung);
        TuyenDung2021 GetTuyenDungById(int id);
        TuyenDung2021 CapNhatTuyenDung(TuyenDung2021 TuyenDung);
        TuyenDung2021 GetTuyenDungByIdAndIdentifyCard(string id, string identifyCard);
        TuyenDung2021 GetTuyenDungByIdWithDetail(int id);
        List<TuyenDung2021> GetTuyenDungsByCmnd(string cmnd);
        int GetTuyenDungsDaDangkiSoLuong();
        int GetTuyenDungsChuaCapNhatSoLuong();
        int GetTuyenDungsDaHoanThanhSoLuong();
        int GetTuyenDungsHopLeSoLuong();
        int GetTuyenDungsDaRaXoatSoLuong();
        int GetTuyenDungsKhongHopLeSoLuong();
        List<TuyenDung2021> GetTuyenDungsDaDangKi();
        List<TuyenDung2021> GetTuyenDungsChuaCapNhat();
        List<TuyenDung2021> GetTuyenDungsDaHoanThanh();
        List<TuyenDung2021> GetTuyenDungsDaHoanThanhWithDetail(int? id);
        List<HoSoHopLe> GetTuyenDungsHopLe();
        List<HoSoHopLe> GetTuyenDungsHopLeWithDetail();
        List<RegistrationInterviewStatusRegistedCountDTO> GetSoluongDangkyTheoViTriUngTuyen();
        TuyenDung2021 GetTuyenDungByTienToId(string id);

        List<TuyenDung2021> GetTuyenDungsIsCheckByAccountId(int id);
        TuyenDung2021 GetTuyenDungByCMND(string cmnd);
        List<TuyenDung2021> GetTuyenDungBySchoolID(int schoolID);
        List<TuyenDung2021> GetTuyenDungsByStatus(int? id);
        List<SoLuongDangKi> GetTinhHinhDangKi();
    }
}