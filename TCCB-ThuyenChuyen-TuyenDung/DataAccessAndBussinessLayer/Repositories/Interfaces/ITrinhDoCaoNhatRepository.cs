using System.Collections.Generic;
using DataAccessAndBussinessLayer.Models.DAO;

namespace DataAccessAndBussinessLayer.Repositories.Interfaces
{
    public interface ITrinhDoCaoNhatRepository
    {
        List<TrinhDoCaoNhat> GetTrinhDoCaoNhats();
    }
}