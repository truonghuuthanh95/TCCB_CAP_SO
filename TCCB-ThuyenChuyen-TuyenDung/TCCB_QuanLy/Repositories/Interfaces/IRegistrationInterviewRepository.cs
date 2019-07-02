using TCCB_QuanLy.Models.DAO;
using System.Collections.Generic;
using TCCB_QuanLy.Models.DTO;

namespace TCCB_QuanLy.Repositories.Interfaces
{
    public interface IRegistrationInterviewRepository
    {
        RegistrationInterview TaoMoiUngVien(RegistrationInterview registrationInterview);
        RegistrationInterview GetRegistrationInterviewById(int id);
        RegistrationInterview CapNhatRegistrationInterview(RegistrationInterview registrationInterview);
        RegistrationInterview GetRegistrationInterviewByIdAndIdentifyCard(string id, string identifyCard);        
        RegistrationInterview GetRegistrationInterviewByIdWithDetail(int id);
        List<RegistrationInterview> GetRegistrationInterviewsByCmnd(string cmnd);
        int GetRegistrationInterviewsDaDangkiSoLuong();
        int GetRegistrationInterviewsChuaCapNhatSoLuong();
        int GetRegistrationInterviewsDaHoanThanhSoLuong();
        int GetRegistrationInterviewsHopLeSoLuong();
        List<RegistrationInterview> GetRegistrationInterviewsDaDangKi();
        List<RegistrationInterview> GetRegistrationInterviewsChuaCapNhat();
        List<RegistrationInterview> GetRegistrationInterviewsDaHoanThanh();
        List<RegistrationInterview> GetRegistrationInterviewsDaHoanThanhWithDetail();
        List<HoSoHopLe> GetRegistrationInterviewsHopLe();
        List<HoSoHopLe> GetRegistrationInterviewsHopLeWithDetail();
        List<RegistrationInterviewStatusRegistedCountDTO> GetSoluongDangkyTheoViTriUngTuyen();
        RegistrationInterview GetRegistrationInterviewByTienToId(string id);

        List<RegistrationInterview> GetRegistrationInterviewsIsCheckByAccountId(int id);
    }
}