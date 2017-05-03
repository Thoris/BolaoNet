namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserMaritalStatus
    {
        public UserMaritalStatus()
        {
            Users = new HashSet<Users>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdMaritalStatus { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
