using TCCB_QuanLy.Models.DAO;
using System.Collections.Generic;

namespace TCCB_QuanLy.Repositories.Interfaces
{
    public interface ICapTruongRepository
    {
        List<CapTruong> GetCapTruongs();
    }
}