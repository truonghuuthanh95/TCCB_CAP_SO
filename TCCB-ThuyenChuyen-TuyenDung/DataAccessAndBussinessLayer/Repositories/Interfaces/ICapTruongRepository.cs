using DataAccessAndBussinessLayer.Models.DAO;
using System.Collections.Generic;

namespace DataAccessAndBussinessLayer.Repositories.Interfaces
{
    public interface ICapTruongRepository
    {
        List<CapTruong> GetCapTruongs();
    }
}