namespace TCCB_QuanLy.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CandidateSchool")]
    public partial class CandidateSchool
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string MaVong2 { get; set; }

        public int? SchoolId { get; set; }

        public string GhiChu { get; set; }

        public int? StatusTiepNhanId { get; set; }

        public int? CandidateId { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual AccountSchool AccountSchool { get; set; }

        public virtual RegistrationInterview RegistrationInterview { get; set; }
    }
}
