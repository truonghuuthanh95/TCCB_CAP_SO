namespace TCCB_QuanLy.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserPermission")]
    public partial class UserPermission
    {
        public int Id { get; set; }

        public int? AccountId { get; set; }

        public int? PermissionId { get; set; }

        public bool? IsActive { get; set; }

        public virtual Account Account { get; set; }

        public virtual Permission Permission { get; set; }
    }
}
