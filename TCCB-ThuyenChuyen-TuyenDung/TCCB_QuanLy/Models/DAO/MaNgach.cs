namespace TCCB_QuanLy.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MaNgach")]
    public partial class MaNgach
    {
        [StringLength(50)]
        public string ID { get; set; }

        [StringLength(255)]
        public string ChucDanh { get; set; }

        [StringLength(2)]
        public string Loai { get; set; }

        [StringLength(50)]
        public string Nhom { get; set; }
    }
}
