namespace TCCB_QuanLy.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhiemVuThamGiaHoiDongTuyenDung")]
    public partial class NhiemVuThamGiaHoiDongTuyenDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhiemVuThamGiaHoiDongTuyenDung()
        {
            TruongNhiemVuThamGiaHDTDs = new HashSet<TruongNhiemVuThamGiaHDTD>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TruongNhiemVuThamGiaHDTD> TruongNhiemVuThamGiaHDTDs { get; set; }
    }
}
