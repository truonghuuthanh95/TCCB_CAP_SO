namespace TCCB_QuanLy.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TruongMonDuTuyen")]
    public partial class TruongMonDuTuyen
    {
        public int Id { get; set; }

        public int? MonDuTuyenId { get; set; }

        public int? SchoolId { get; set; }

        public bool? IsActive { get; set; }

        public virtual MonDuTuyen MonDuTuyen { get; set; }

        public virtual School School { get; set; }
    }
}
