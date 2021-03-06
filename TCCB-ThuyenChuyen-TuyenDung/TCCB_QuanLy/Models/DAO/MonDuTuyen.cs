namespace TCCB_QuanLy.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MonDuTuyen")]
    public partial class MonDuTuyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MonDuTuyen()
        {
            RegistrationInterviews = new HashSet<RegistrationInterview>();
            ThuyenChuyens = new HashSet<ThuyenChuyen>();
            ThuyenChuyenNgoaiTinhs = new HashSet<ThuyenChuyenNgoaiTinh>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Code { get; set; }

        public bool? IsActive { get; set; }

        public int? PositionInterviewId { get; set; }

        public int? Targets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistrationInterview> RegistrationInterviews { get; set; }

        public virtual ViTriUngTuyen ViTriUngTuyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThuyenChuyen> ThuyenChuyens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThuyenChuyenNgoaiTinh> ThuyenChuyenNgoaiTinhs { get; set; }
    }
}
