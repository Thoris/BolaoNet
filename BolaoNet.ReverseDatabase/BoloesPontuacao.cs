namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BoloesPontuacao")]
    public partial class BoloesPontuacao
    {
        [StringLength(25)]
        public string CreatedBy { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Pontos { get; set; }

        [StringLength(25)]
        public string ModifiedBy { get; set; }

        [StringLength(20)]
        public string Titulo { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(20)]
        public string ForeColor { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(20)]
        public string BackColor { get; set; }

        public bool? ActiveFlag { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string NomeBolao { get; set; }

        public virtual Boloes Boloes { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }
    }
}
