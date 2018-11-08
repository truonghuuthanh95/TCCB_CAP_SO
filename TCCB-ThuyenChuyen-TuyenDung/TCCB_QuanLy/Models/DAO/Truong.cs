namespace TCCB_QuanLy.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Truong")]
    public partial class Truong
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int? DistrictId { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public int? SchoolType { get; set; }

        public int? ProvinceId { get; set; }

        [StringLength(50)]
        public string SchoolCode { get; set; }

        public int? SchoolDegreeId { get; set; }

        public virtual CapTruong CapTruong { get; set; }

        public virtual District District { get; set; }
    }
}
