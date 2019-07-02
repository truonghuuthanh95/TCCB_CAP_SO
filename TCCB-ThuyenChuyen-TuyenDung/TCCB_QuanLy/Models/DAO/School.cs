namespace TCCB_QuanLy.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("School")]
    public partial class School
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public School()
        {
            ThuyenChuyens = new HashSet<ThuyenChuyen>();
            ThuyenChuyens1 = new HashSet<ThuyenChuyen>();
            ThuyenChuyenNgoaiTinhs = new HashSet<ThuyenChuyenNgoaiTinh>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string MaTruong { get; set; }

        public int? WardId { get; set; }

        [StringLength(500)]
        public string SoNhaTenDuong { get; set; }

        public bool? IsDaTaoMoi { get; set; }

        public int? CapTruongId { get; set; }

        [StringLength(200)]
        public string TenTruong { get; set; }

        public int? LoaiHinh { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(12)]
        public string SDT { get; set; }

        public int? DVQLId { get; set; }

        public int? NhaCungCapId { get; set; }

        [StringLength(50)]
        public string MaSoThue { get; set; }

        [StringLength(50)]
        public string HieuTruong { get; set; }

        public virtual CapTruong CapTruong { get; set; }

        public virtual DVQL DVQL { get; set; }

        public virtual LoaiHinh LoaiHinh1 { get; set; }

        public virtual Ward Ward { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThuyenChuyen> ThuyenChuyens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThuyenChuyen> ThuyenChuyens1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThuyenChuyenNgoaiTinh> ThuyenChuyenNgoaiTinhs { get; set; }
    }
}
