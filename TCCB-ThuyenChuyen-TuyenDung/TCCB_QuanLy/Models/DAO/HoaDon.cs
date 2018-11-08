namespace TCCB_QuanLy.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        public int Id { get; set; }

        public int? Value { get; set; }

        [StringLength(200)]
        public string CollectContent { get; set; }

        [StringLength(100)]
        public string ValueByWord { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateComeToCheck { get; set; }
    }
}
