namespace TCCB_QuanLy.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViTriUngTuyen")]
    public partial class ViTriUngTuyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ViTriUngTuyen()
        {
            MonDuTuyens = new HashSet<MonDuTuyen>();
        }

        public int Id { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

        [StringLength(10)]
        public string IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonDuTuyen> MonDuTuyens { get; set; }
    }
}
