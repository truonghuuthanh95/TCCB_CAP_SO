using DataAccessAndBussinessLayer.Models.DAO;
using DataAccessAndBussinessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessAndBussinessLayer.Repositories.Implements
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