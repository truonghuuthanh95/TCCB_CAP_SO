using DataAccessAndBussinessLayer.Models.DAO;
using System.Collections.Generic;

namespace DataAccessAndBussinessLayer.Repositories.Interfaces
{
    public interface IXepLoaiHocLucRepository
    {
        List<XepLoaiHocLuc> GetXepLoaiHocLucs();
    }
}