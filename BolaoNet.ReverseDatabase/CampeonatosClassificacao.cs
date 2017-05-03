namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CampeonatosClassificacao")]
    public partial class CampeonatosClassificacao
    {
        [StringLength(25)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(25)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? TotalVitorias { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Rodada { get; set; }

        public int? Posicao { get; set; }

        public bool? ActiveFlag { get; set; }

        public int? TotalDerrotas { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string NomeCampeonato { get; set; }

        public int? LastPosicao { get; set; }

        public int? TotalEmpates { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        public string NomeFase { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(30)]
        public string NomeTime { get; set; }

        public int? TotalGolsContra { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(20)]
        public string NomeGrupo { get; set; }

        public int? TotalGolsPro { get; set; }

        public int? TotalPontos { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }

        public virtual CampeonatosFases CampeonatosFases { get; set; }

        public virtual CampeonatosGruposTimes CampeonatosGruposTimes { get; set; }
    }
}
