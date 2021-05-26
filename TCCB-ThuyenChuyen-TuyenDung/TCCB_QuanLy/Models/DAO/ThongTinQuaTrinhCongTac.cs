namespace TCCB_QuanLy.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinQuaTrinhCongTac")]
    public partial class ThongTinQuaTrinhCongTac
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThongTinQuaTrinhCongTac()
        {
            TuyenDung2021 = new HashSet<TuyenDung2021>();
        }

        public int Id { get; set; }

        public int? TuyenDungId { get; set; }

        [StringLength(100)]
        public string TuNgayDenNgay { get; set; }

        [StringLength(500)]
        public string CoQuanToChuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TuyenDung2021> TuyenDung2021 { get; set; }
    }
}
