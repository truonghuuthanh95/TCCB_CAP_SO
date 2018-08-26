using System.Collections.Generic;
using DataAccessAndBussinessLayer.Models.DAO;

namespace DataAccessAndBussinessLayer.Repositories.Interfaces
{
    public interface IWardRepository
    {
        List<Ward> GetWardByDistrictId(int id);
    }
}