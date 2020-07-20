using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCCB_QuanLy.Models.DTO
{
    public class CanBoThamGiaHoiDongDTO
    {
        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(50)]
        public string NamSinh { get; set; }

        [StringLength(50)]
        public string NamVaoNganh { get; set; }

        [StringLength(50)]
        public string ChucVu { get; set; }

        [StringLength(50)]
        public string ChuyenNganhDaoTao { get; set; }

        [StringLength(50)]
        public string TrinhDoChuyenMon { get; set; }

        public int NhiemVuId { get; set; }
        public bool GioiTinh { get; set; }
    }
}