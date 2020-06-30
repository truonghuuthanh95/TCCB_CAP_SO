using System.Collections.Generic;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Repositories.Interfaces
{
    public interface ISchoolRepository
    {
        School GetSchoolById(int? id);
        List<School> GetSchoolsByDistrictAndCapHoc(int? districtId, int? caphoc);
        School GetSchoolByMaTruong(string maTruong);
       
    }
}