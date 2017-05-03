namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BoloesMembrosClassificacao")]
    public partial class BoloesMembrosClassificacao
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
        [StringLength(30)]
        public string NomeBolao { get; set; }

        public int? Posicao { get; set; }

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

        public int? TotalApostaExtra { get; set; }

        public virtual BoloesMembros BoloesMembros { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }
    }
}
