using TCCB_QuanLy.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCB_QuanLy.Repositories.Interfaces
{
    public interface IGroupPermissionRepository
    {
        List<GroupPermission> GetGroupPermissions();
    }
}