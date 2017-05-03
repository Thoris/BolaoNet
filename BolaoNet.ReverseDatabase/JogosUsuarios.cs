namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class JogosUsuarios
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdJogo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string NomeCampeonato { get; set; }

        [StringLength(25)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? DataAposta { get; set; }

        [StringLength(25)]
        public string ModifiedBy { get; set; }

        public short? Automatico { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public short? ApostaTime1 { get; set; }

        public bool? ActiveFlag { get; set; }

        public short? ApostaTime2 { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(25)]
        public string UserName { get; set; }

        public bool? IsDerrota { get; set; }

        public int? Pontos { get; set; }

        public bool? Valido { get; set; }

        public bool? IsEmpate { get; set; }

        public bool? IsVitoria { get; set; }

        public bool? IsGolsGanhador { get; set; }

        public bool? IsGolsPerdedor { get; set; }

        public bool? IsResultTime1 { get; set; }

        public bool? IsResultTime2 { get; set; }

        public bool? IsVDE { get; set; }

        public bool? IsErro { get; set; }

        public bool? IsGolsGanhadorFora { get; set; }

        public bool? IsGolsGanhadorDentro { get; set; }

        public bool? IsGolsPerdedorFora { get; set; }

        public bool? IsGolsPerdedorDentro { get; set; }

        public bool? IsGolsEmpate { get; set; }

        public bool? IsMultiploTime { get; set; }

        public bool? IsGolsTime1 { get; set; }

        public int? MultiploTime { get; set; }

        public bool? IsGolsTime2 { get; set; }

        public bool? IsPlacarCheio { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(30)]
        public string NomeBolao { get; set; }

        [StringLength(30)]
        public string NomeTimeResult1 { get; set; }

        [StringLength(30)]
        public string NomeTimeResult2 { get; set; }

        public int? Ganhador { get; set; }

        public DateTime? DataFacebook { get; set; }

        public virtual BoloesMembros BoloesMembros { get; set; }

        public virtual Jogos Jogos { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }

        public virtual Times Times { get; set; }

        public virtual Times Times1 { get; set; }
    }
}
