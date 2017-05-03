namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BoloesPontosRodadasUsuarios
    {
        [StringLength(25)]
        public string CreatedBy { get; set; }

        [StringLength(25)]
        public string ModifiedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Rodada { get; set; }

        public bool? ActiveFlag { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string NomeGrupo { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string NomeCampeonato { get; set; }

        public int? TotalPontos { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(30)]
        public string NomeFase { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(30)]
        public string NomeBolao { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Posicao { get; set; }

        [StringLength(25)]
        public string UserName { get; set; }

        public virtual BoloesMembros BoloesMembros { get; set; }

        public virtual BoloesPontosRodadas BoloesPontosRodadas { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }
    }
}
