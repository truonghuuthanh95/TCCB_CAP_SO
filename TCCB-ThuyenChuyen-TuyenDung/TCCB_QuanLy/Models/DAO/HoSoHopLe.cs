namespace TCCB_QuanLy.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoSoHopLe")]
    public partial class HoSoHopLe
    {
        public int Id { get; set; }

        public int HoSoId { get; set; }

        public int? MaVong2 { get; set; }

        public DateTime? CreatedAt { get; set; }

        [StringLength(50)]
        public string TienTo { get; set; }

        public virtual RegistrationInterview RegistrationInterview { get; set; }
    }
}
