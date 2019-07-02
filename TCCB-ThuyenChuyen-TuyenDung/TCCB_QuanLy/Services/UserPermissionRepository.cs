using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Services
{
    public class UserPermissionRepository : IDisposable
    {
        public void Dispose()
        {
           
        }
        public List<UserPermission> GetUserPermissionsByAccountId(int id)
        {
            using (var _db = new TCCBDB())
            {
                List<UserPermission> userPermissions = _db.UserPermissions.Include("Permission").Where(s => s.AccountId == id).ToList();
                return userPermissions;
            }
           
        }
    }
}