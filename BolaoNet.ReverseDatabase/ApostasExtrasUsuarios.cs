namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ApostasExtrasUsuarios
    {
        [StringLength(25)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(25)]
        public string ModifiedBy { get; set; }

        public DateTime? DataAposta { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? Pontos { get; set; }

        public bool? IsApostaValida { get; set; }

        public bool? ActiveFlag { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Posicao { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string NomeBolao { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(25)]
        public string UserName { get; set; }

        [StringLength(30)]
        public string NomeTime { get; set; }

        public bool? Automatico { get; set; }

        public virtual ApostasExtras ApostasExtras { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }

        public virtual Times Times { get; set; }

        public virtual Users Users2 { get; set; }
    }
}
