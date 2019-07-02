using System.Collections.Generic;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Repositories.Interfaces
{
    public interface IMonDuTuyenRepository
    {
        List<MonDuTuyen> GetMonDuTuyens();
        List<MonDuTuyen> GetAllMonDuTuyens();
    }
}