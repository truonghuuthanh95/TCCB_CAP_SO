using TCCB_QuanLy.Models.DAO;
using System.Collections.Generic;
using TCCB_QuanLy.Models.DTO;

namespace TCCB_QuanLy.Repositories.Interfaces
{
    public interface IRegistrationInterviewRepository
    {
        TuyenDung2020 TaoMoiUngVien(TuyenDung2020 TuyenDung);
        TuyenDung2020 GetTuyenDungById(int id);
        TuyenDung2020 CapNhatTuyenDung(TuyenDung2020 TuyenDung);
        TuyenDung2020 GetTuyenDungByIdAndIdentifyCard(string id, string identifyCard);
        TuyenDung2020 GetTuyenDungByIdWithDetail(int id);
        List<TuyenDung2020> GetTuyenDungsByCmnd(string cmnd);
        int GetTuyenDungsDaDangkiSoLuong();
        int GetTuyenDungsChuaCapNhatSoLuong();
        int GetTuyenDungsDaHoanThanhSoLuong();
        int GetTuyenDungsHopLeSoLuong();
        int GetTuyenDungsDaRaXoatSoLuong();
        int GetTuyenDungsKhongHopLeSoLuong();
        List<TuyenDung2020> GetTuyenDungsDaDangKi();
        List<TuyenDung2020> GetTuyenDungsChuaCapNhat();
        List<TuyenDung2020> GetTuyenDungsDaHoanThanh();
        List<TuyenDung2020> GetTuyenDungsDaHoanThanhWithDetail();
        List<HoSoHopLe> GetTuyenDungsHopLe();
        List<HoSoHopLe> GetTuyenDungsHopLeWithDetail();
        List<RegistrationInterviewStatusRegistedCountDTO> GetSoluongDangkyTheoViTriUngTuyen();
        TuyenDung2020 GetTuyenDungByTienToId(string id);

        List<TuyenDung2020> GetTuyenDungsIsCheckByAccountId(int id);
        TuyenDung2020 GetTuyenDungByCMND(string cmnd);
        List<TuyenDung2020> GetTuyenDungBySchoolID(int schoolID);
        List<TuyenDung2020> GetTuyenDungsByStatus(int id);


    }
}