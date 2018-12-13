namespace TCCB_QuanLy.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BacLuong")]
    public partial class BacLuong
    {
        [Required]
        [StringLength(2)]
        public string Loai { get; set; }

        [Required]
        [StringLength(5)]
        public string Nhom { get; set; }

        public double? Bac { get; set; }

        [StringLength(255)]
        public string HeSo { get; set; }

        [StringLength(50)]
        public string ID { get; set; }
    }
}
