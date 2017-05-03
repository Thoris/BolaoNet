namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BoloesCampeonatosClassificacaoUsuarios
    {
        [StringLength(25)]
        public string CreatedBy { get; set; }

        [StringLength(25)]
        public string ModifiedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? ActiveFlag { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string NomeCampeonato { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string NomeFase { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string NomeGrupo { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(30)]
        public string NomeTime { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(25)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(30)]
        public string NomeBolao { get; set; }

        public int? Posicao { get; set; }

        public int? TotalVitorias { get; set; }

        public int? TotalDerrotas { get; set; }

        public int? TotalEmpates { get; set; }

        public int? TotalGolsContra { get; set; }

        public int? TotalGolsPro { get; set; }

        public int? TotalPontos { get; set; }

        public virtual Boloes Boloes { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }

        public virtual Campeonatos Campeonatos { get; set; }

        public virtual Times Times { get; set; }

        public virtual Users Users2 { get; set; }

        public virtual CampeonatosGrupos CampeonatosGrupos { get; set; }

        public virtual CampeonatosFases CampeonatosFases { get; set; }
    }
}
