namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Boloes
    {
        public Boloes()
        {
            ApostasExtras = new HashSet<ApostasExtras>();
            BoloesCampeonatosClassificacaoUsuarios = new HashSet<BoloesCampeonatosClassificacaoUsuarios>();
            BoloesCriteriosPontos = new HashSet<BoloesCriteriosPontos>();
            BoloesCriteriosPontosTimes = new HashSet<BoloesCriteriosPontosTimes>();
            BoloesMembros = new HashSet<BoloesMembros>();
            BoloesPontosRodadas = new HashSet<BoloesPontosRodadas>();
            BoloesPontuacao = new HashSet<BoloesPontuacao>();
            BoloesPremios = new HashSet<BoloesPremios>();
            BoloesRegras = new HashSet<BoloesRegras>();
            Pagamentos = new HashSet<Pagamentos>();
        }

        [Key]
        [StringLength(30)]
        public string Nome { get; set; }

        [StringLength(255)]
        public string Descricao { get; set; }

        [Column(TypeName = "money")]
        public decimal? TaxaParticipacao { get; set; }

        public DateTime? CreatedDate { get; set; }

        [MaxLength(1)]
        public byte[] Foto { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? Publico { get; set; }

        public bool? ActiveFlag { get; set; }

        public bool? ForumAtivado { get; set; }

        [StringLength(25)]
        public string CreatedBy { get; set; }

        public bool? PermitirMsgAnonimos { get; set; }

        [StringLength(25)]
        public string ModifiedBy { get; set; }

        public DateTime? DataInicio { get; set; }

        [StringLength(20)]
        public string Estado { get; set; }

        [StringLength(100)]
        public string Cidade { get; set; }

        public bool? ApostasApenasAntes { get; set; }

        public int? HorasLimiteAposta { get; set; }

        [StringLength(20)]
        public string Pais { get; set; }

        public bool? IsIniciado { get; set; }

        public DateTime? DataIniciado { get; set; }

        [StringLength(25)]
        public string IniciadoBy { get; set; }

        [StringLength(50)]
        public string NomeCampeonato { get; set; }

        public virtual ICollection<ApostasExtras> ApostasExtras { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }

        public virtual Users Users2 { get; set; }

        public virtual Campeonatos Campeonatos { get; set; }

        public virtual ICollection<BoloesCampeonatosClassificacaoUsuarios> BoloesCampeonatosClassificacaoUsuarios { get; set; }

        public virtual ICollection<BoloesCriteriosPontos> BoloesCriteriosPontos { get; set; }

        public virtual ICollection<BoloesCriteriosPontosTimes> BoloesCriteriosPontosTimes { get; set; }

        public virtual ICollection<BoloesMembros> BoloesMembros { get; set; }

        public virtual ICollection<BoloesPontosRodadas> BoloesPontosRodadas { get; set; }

        public virtual ICollection<BoloesPontuacao> BoloesPontuacao { get; set; }

        public virtual ICollection<BoloesPremios> BoloesPremios { get; set; }

        public virtual ICollection<BoloesRegras> BoloesRegras { get; set; }

        public virtual ICollection<Pagamentos> Pagamentos { get; set; }
    }
}
