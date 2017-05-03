namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CampeonatosFases
    {
        public CampeonatosFases()
        {
            BoloesCampeonatosClassificacaoUsuarios = new HashSet<BoloesCampeonatosClassificacaoUsuarios>();
            BoloesMembrosPontos = new HashSet<BoloesMembrosPontos>();
            BoloesPontosRodadas = new HashSet<BoloesPontosRodadas>();
            CampeonatosClassificacao = new HashSet<CampeonatosClassificacao>();
            CampeonatosPosicoes = new HashSet<CampeonatosPosicoes>();
            Jogos = new HashSet<Jogos>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string NomeCampeonato { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string Nome { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(255)]
        public string Descricao { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? ActiveFlag { get; set; }

        [StringLength(25)]
        public string CreatedBy { get; set; }

        [StringLength(25)]
        public string ModifiedBy { get; set; }

        public virtual ICollection<BoloesCampeonatosClassificacaoUsuarios> BoloesCampeonatosClassificacaoUsuarios { get; set; }

        public virtual ICollection<BoloesMembrosPontos> BoloesMembrosPontos { get; set; }

        public virtual ICollection<BoloesPontosRodadas> BoloesPontosRodadas { get; set; }

        public virtual Campeonatos Campeonatos { get; set; }

        public virtual ICollection<CampeonatosClassificacao> CampeonatosClassificacao { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }

        public virtual ICollection<CampeonatosPosicoes> CampeonatosPosicoes { get; set; }

        public virtual ICollection<Jogos> Jogos { get; set; }
    }
}
