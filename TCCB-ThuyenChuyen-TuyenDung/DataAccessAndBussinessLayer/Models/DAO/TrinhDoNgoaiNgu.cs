namespace DataAccessAndBussinessLayer.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrinhDoNgoaiNgu")]
    public partial class TrinhDoNgoaiNgu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrinhDoNgoaiNgu()
        {
            RegistrationInterviews = new HashSet<RegistrationInterview>();
        }

        public int Id { get; set; }

        [StringLength(70)]
        public string Name { get; set; }

        public bool? IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistrationInterview> RegistrationInterviews { get; set; }
    }
}
