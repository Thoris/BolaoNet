namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Profiles
    {
        [Key]
        public int ProfileID { get; set; }

        public bool? IsAnonymous { get; set; }

        public DateTime? LastActivityDate { get; set; }

        public DateTime? LastUpdatedDate { get; set; }

        [Column(TypeName = "image")]
        public byte[] PropertyValuesBinary { get; set; }

        [Column(TypeName = "ntext")]
        public string PropertyValuesString { get; set; }

        [Column(TypeName = "ntext")]
        public string PropertyNames { get; set; }

        [StringLength(25)]
        public string UserName { get; set; }
    }
}
