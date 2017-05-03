namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BoloesMembrosGrupo")]
    public partial class BoloesMembrosGrupo
    {
        [StringLength(25)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(25)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? ActiveFlag { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(25)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(25)]
        public string UserNameSelecionado { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        public string NomeBolao { get; set; }

        public virtual BoloesMembros BoloesMembros { get; set; }

        public virtual BoloesMembros BoloesMembros1 { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }
    }
}
