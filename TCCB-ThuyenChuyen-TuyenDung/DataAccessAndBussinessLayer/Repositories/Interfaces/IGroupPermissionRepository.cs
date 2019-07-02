﻿using DataAccessAndBussinessLayer.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessAndBussinessLayer.Repositories.Interfaces
{
    public interface IGroupPermissionRepository
    {
        List<GroupPermission> GetGroupPermissions();
    }
}