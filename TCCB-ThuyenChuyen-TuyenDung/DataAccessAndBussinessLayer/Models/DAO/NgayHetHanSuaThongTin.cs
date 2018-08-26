namespace DataAccessAndBussinessLayer.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NgayHetHanSuaThongTin")]
    public partial class NgayHetHanSuaThongTin
    {
        public int Id { get; set; }

        public int? DVQLId { get; set; }

        public DateTime? NgayHetHan { get; set; }
    }
}
