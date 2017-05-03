namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Times
    {
        public Times()
        {
            ApostasExtras = new HashSet<ApostasExtras>();
            ApostasExtrasUsuarios = new HashSet<ApostasExtrasUsuarios>();
            BoloesCampeonatosClassificacaoUsuarios = new HashSet<BoloesCampeonatosClassificacaoUsuarios>();
            BoloesCriteriosPontosTimes = new HashSet<BoloesCriteriosPontosTimes>();
            CampeonatosGruposTimes = new HashSet<CampeonatosGruposTimes>();
            CampeonatosTimes = new HashSet<CampeonatosTimes>();
            Estadios = new HashSet<Estadios>();
            JogosUsuarios = new HashSet<JogosUsuarios>();
            JogosUsuarios1 = new HashSet<JogosUsuarios>();
        }

        [Key]
        [StringLength(30)]
        public string Nome { get; set; }

        [StringLength(25)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(25)]
        public string ModifiedBy { get; set; }

        public bool? ActiveFlag { get; set; }

        public bool? IsClube { get; set; }

        [Column(TypeName = "image")]
        public byte[] Escudo { get; set; }

        public DateTime? DataFundacao { get; set; }

        [StringLength(100)]
        public string Site { get; set; }

        [StringLength(20)]
        public string Pais { get; set; }

        [StringLength(20)]
        public string Estado { get; set; }

        [StringLength(20)]
        public string Cidade { get; set; }

        [StringLength(255)]
        public string Descricao { get; set; }

        [StringLength(20)]
        public string NomeMascote { get; set; }

        [Column(TypeName = "image")]
        public byte[] Mascote { get; set; }

        public virtual ICollection<ApostasExtras> ApostasExtras { get; set; }

        public virtual ICollection<ApostasExtrasUsuarios> ApostasExtrasUsuarios { get; set; }

        public virtual ICollection<BoloesCampeonatosClassificacaoUsuarios> BoloesCampeonatosClassificacaoUsuarios { get; set; }

        public virtual ICollection<BoloesCriteriosPontosTimes> BoloesCriteriosPontosTimes { get; set; }

        public virtual ICollection<CampeonatosGruposTimes> CampeonatosGruposTimes { get; set; }

        public virtual ICollection<CampeonatosTimes> CampeonatosTimes { get; set; }

        public virtual ICollection<Estadios> Estadios { get; set; }

        public virtual ICollection<JogosUsuarios> JogosUsuarios { get; set; }

        public virtual ICollection<JogosUsuarios> JogosUsuarios1 { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }
    }
}
