using DataAccessAndBussinessLayer.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessAndBussinessLayer.Repositories.Interfaces
{
    public interface IUserPermissionRepository
    {
        List<UserPermission> GetUserPermissionsByAccountId(int id);
    }
}