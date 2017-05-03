namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UsersInRoles
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string RoleName { get; set; }

        [StringLength(25)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(25)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? ActiveFlag { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(25)]
        public string UserName { get; set; }

        public virtual Roles Roles { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }

        public virtual Users Users2 { get; set; }

        public virtual Users Users3 { get; set; }
    }
}
