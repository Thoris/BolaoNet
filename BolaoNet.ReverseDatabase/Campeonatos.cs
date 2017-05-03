namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Campeonatos
    {
        public Campeonatos()
        {
            Boloes = new HashSet<Boloes>();
            BoloesCampeonatosClassificacaoUsuarios = new HashSet<BoloesCampeonatosClassificacaoUsuarios>();
            CampeonatosTimes = new HashSet<CampeonatosTimes>();
            CampeonatosFases = new HashSet<CampeonatosFases>();
            CampeonatosGrupos = new HashSet<CampeonatosGrupos>();
            CampeonatosHistorico = new HashSet<CampeonatosHistorico>();
            Jogos = new HashSet<Jogos>();
        }

        [StringLength(25)]
        public string ModifiedBy { get; set; }

        [Key]
        [StringLength(50)]
        public string Nome { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool? IsClube { get; set; }

        [StringLength(30)]
        public string FaseAtual { get; set; }

        [StringLength(25)]
        public string CreatedBy { get; set; }

        public int? RodadaAtual { get; set; }

        public bool? IsIniciado { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public DateTime? DataInicio { get; set; }

        public bool? ActiveFlag { get; set; }

        public virtual ICollection<Boloes> Boloes { get; set; }

        public virtual ICollection<BoloesCampeonatosClassificacaoUsuarios> BoloesCampeonatosClassificacaoUsuarios { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }

        public virtual ICollection<CampeonatosTimes> CampeonatosTimes { get; set; }

        public virtual ICollection<CampeonatosFases> CampeonatosFases { get; set; }

        public virtual ICollection<CampeonatosGrupos> CampeonatosGrupos { get; set; }

        public virtual ICollection<CampeonatosHistorico> CampeonatosHistorico { get; set; }

        public virtual ICollection<Jogos> Jogos { get; set; }
    }
}
