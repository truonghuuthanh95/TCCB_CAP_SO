using DataAccessAndBussinessLayer.Models.DAO;
using DataAccessAndBussinessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessAndBussinessLayer.Repositories.Implements
{
    public class PermissionRepository : IPermissionRepository
    {
        TCCBDB _db;

        public PermissionRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<Permission> GetPermissions()
        {
            List<Permission> permissions = _db.Permissions.OrderBy(s => s.GroupPermissionId).ToList();
            return permissions;
        }
    }
}