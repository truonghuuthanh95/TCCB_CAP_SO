namespace DataAccessAndBussinessLayer.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrinhDoTinHoc")]
    public partial class TrinhDoTinHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrinhDoTinHoc()
        {
            RegistrationInterviews = new HashSet<RegistrationInterview>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public bool? IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistrationInterview> RegistrationInterviews { get; set; }
    }
}
