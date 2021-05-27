namespace TCCB_QuanLy.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TuyenDungNguyenVong")]
    public partial class TuyenDungNguyenVong
    {
        public int Id { get; set; }

        public int? TuyenDungId { get; set; }

        public int? SchoolId { get; set; }

        public virtual School School { get; set; }

        public virtual TuyenDung2021 TuyenDung2021 { get; set; }
    }
}
