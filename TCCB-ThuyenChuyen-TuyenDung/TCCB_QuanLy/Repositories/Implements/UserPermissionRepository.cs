using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCB_QuanLy.Repositories.Implements
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
            List<UserPermission> userPermissions = _db.UserPermissions.AsNoTracking().Include("Permission").Where(s => s.AccountId == id && s.IsActive == true).ToList();
            return userPermissions;            
        }
    }
}