using DataAccessAndBussinessLayer.Models.DAO;

namespace DataAccessAndBussinessLayer.Repositories.Interfaces
{
    public interface IRegistrationInterviewRepository
    {
        RegistrationInterview GetRegistrationInterviewById(int id);
        RegistrationInterview CapNhatRegistrationInterview(RegistrationInterview registrationInterview);
        RegistrationInterview GetRegistrationInterviewByIdAndIdentifyCard(int id, string identifyCard);        
        RegistrationInterview GetRegistrationInterviewByIdWithDetail(int id);          
    }
}