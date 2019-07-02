using AutoMapper;
using DataAccessAndBussinessLayer.Models.DAO;
using TCCB.Models.DTO;

namespace TCCB_ThuyenChuyen_TuyenDung.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegistrationInterview, RegistrationInterviewDTO>();
            CreateMap<RegistrationInterviewDTO, RegistrationInterview>();

        }
    }
}