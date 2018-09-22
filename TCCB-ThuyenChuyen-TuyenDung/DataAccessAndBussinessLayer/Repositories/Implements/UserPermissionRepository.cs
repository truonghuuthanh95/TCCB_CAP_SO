using DataAccessAndBussinessLayer.Models.DAO;
using DataAccessAndBussinessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessAndBussinessLayer.Repositories.Implements
{
    public class UserPermissionRepository : IUserPermissionRepository
    {
        TCCBDB _db;

        public UserPermissionRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<UserPermission> GetUserPermissionsByAccountId(int id)
        {
            List<UserPermission> userPermissions = _db.UserPermissions.Include("Permission").Where(s => s.AccountId == id).ToList();
            return userPermissions;            
        }
    }
}