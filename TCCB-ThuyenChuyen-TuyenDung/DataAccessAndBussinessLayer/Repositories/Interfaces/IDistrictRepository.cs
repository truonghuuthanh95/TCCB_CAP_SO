using System.Collections.Generic;
using DataAccessAndBussinessLayer.Models.DAO;

namespace DataAccessAndBussinessLayer.Repositories.Interfaces
{
    public interface IDistrictRepository
    {
        List<District> GetDistrictByProvinceId(int id);
    }
}