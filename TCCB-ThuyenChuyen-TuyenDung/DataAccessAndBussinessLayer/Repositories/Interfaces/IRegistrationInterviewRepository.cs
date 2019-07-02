using DataAccessAndBussinessLayer.Models.DAO;
using System.Collections.Generic;

namespace DataAccessAndBussinessLayer.Repositories.Interfaces
{
    public interface IRegistrationInterviewRepository
    {
        RegistrationInterview TaoMoiUngVien(RegistrationInterview registrationInterview);
        RegistrationInterview GetRegistrationInterviewById(int id);
        RegistrationInterview CapNhatRegistrationInterview(RegistrationInterview registrationInterview);
        RegistrationInterview GetRegistrationInterviewByIdAndIdentifyCard(int id, string identifyCard);        
        RegistrationInterview GetRegistrationInterviewByIdWithDetail(int id);
        List<RegistrationInterview> GetRegistrationInterviewsByCmnd(string cmnd);
        int GetRegistrationInterviewsDaDangkiSoLuong();
        int GetRegistrationInterviewsChuaCapNhatSoLuong();
        int GetRegistrationInterviewsDaHoanThanhSoLuong();
        int GetRegistrationInterviewsHopLeSoLuong();
        List<RegistrationInterview> GetRegistrationInterviewsDaDangKi();
        List<RegistrationInterview> GetRegistrationInterviewsChuaCapNhat();
        List<RegistrationInterview> GetRegistrationInterviewsDaHoanThanh();
        List<RegistrationInterview> GetRegistrationInterviewsHopLe();
    }
}