namespace TCCB_QuanLy.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XepLoaiHocLuc")]
    public partial class XepLoaiHocLuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XepLoaiHocLuc()
        {
            RegistrationInterviews = new HashSet<RegistrationInterview>();
            ThuyenChuyens = new HashSet<ThuyenChuyen>();
            ThuyenChuyen2020 = new HashSet<ThuyenChuyen2020>();
            ThuyenChuyenNgoaiTinhs = new HashSet<ThuyenChuyenNgoaiTinh>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public bool? IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistrationInterview> RegistrationInterviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThuyenChuyen> ThuyenChuyens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThuyenChuyen2020> ThuyenChuyen2020 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThuyenChuyenNgoaiTinh> ThuyenChuyenNgoaiTinhs { get; set; }
    }
}
