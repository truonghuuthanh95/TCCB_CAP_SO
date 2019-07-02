using System.Collections.Generic;
using System.Linq;
using DataAccessAndBussinessLayer.Repositories.Interfaces;
using DataAccessAndBussinessLayer.Models.DAO;

namespace DataAccessAndBussinessLayer.Repositories.Implements
{
    public class ProvinceRepository : IProvinceRepository
    {
        TCCBDB _db;

        public ProvinceRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<Province> GetProvinceByCountryId(int id)
        {
            List<Province> provinces = _db.Provinces.Where(s => s.CountryId == id).OrderBy(s => s.Name).ToList();
            return provinces;
        }
    }
}