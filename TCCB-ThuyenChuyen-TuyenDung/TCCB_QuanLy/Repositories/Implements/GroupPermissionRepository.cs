using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class GroupPermissionRepository : IGroupPermissionRepository
    {
        TCCBDB _db;

        public GroupPermissionRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<GroupPermission> GetGroupPermissions()
        {
            List<GroupPermission> groupPermissions = _db.GroupPermissions.Where(s => s.IsActive == true).ToList();
            return groupPermissions;
        }
    }
}