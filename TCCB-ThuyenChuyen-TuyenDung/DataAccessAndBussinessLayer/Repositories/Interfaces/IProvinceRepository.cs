﻿using System.Collections.Generic;
using DataAccessAndBussinessLayer.Models.DAO;

namespace DataAccessAndBussinessLayer.Repositories.Interfaces
{
    public interface IProvinceRepository
    {
        List<Province> GetProvinceByCountryId(int id);
    }
}