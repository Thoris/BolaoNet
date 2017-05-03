namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BoloesMembrosPontos
    {
        [StringLength(25)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(25)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? ActiveFlag { get; set; }

        public int? Posicao { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Rodada { get; set; }

        public int? LastPosicao { get; set; }

        public int? TotalPontos { get; set; }

        public int? TotalEmpate { get; set; }

        public int? TotalVitoria { get; set; }

        public int? TotalGolsGanhador { get; set; }

        public int? TotalGolsPerdedor { get; set; }

        public int? TotalResultTime1 { get; set; }

        public int? TotalResultTime2 { get; set; }

        public int? TotalVDE { get; set; }

        public int? TotalErro { get; set; }

        public int? TotalGolsGanhadorFora { get; set; }

        public int? TotalGolsGanhadorDentro { get; set; }

        public int? TotalPerdedorFora { get; set; }

        public int? TotalPerdedorDentro { get; set; }

        public int? TotalGolsEmpate { get; set; }

        public int? TotalGolsTime1 { get; set; }

        public int? TotalGolsTime2 { get; set; }

        public int? TotalPlacarCheio { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(25)]
        public string UserName { get; set; }

        public bool? IsMultiploTime { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        public string NomeBolao { get; set; }

        public int? MultiploTime { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string NomeCampeonato { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(30)]
        public string NomeFase { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(20)]
        public string NomeGrupo { get; set; }

        public virtual BoloesMembros BoloesMembros { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }

        public virtual CampeonatosGrupos CampeonatosGrupos { get; set; }

        public virtual CampeonatosFases CampeonatosFases { get; set; }
    }
}
