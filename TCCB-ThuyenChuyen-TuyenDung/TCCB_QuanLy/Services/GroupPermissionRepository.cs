using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Services
{
    public class GroupPermissionRepository : IDisposable
    {
        public void Dispose()
        {
            
        }
        public List<GroupPermission> GetGroupPermissions()
        {
            using (var _db = new TCCBDB())
            {
                List<GroupPermission> groupPermissions = _db.GroupPermissions.Where(s => s.IsActive == true).ToList();
                return groupPermissions;
            }
            
        }
    }
}