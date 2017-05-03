namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BoloesMembros
    {
        public BoloesMembros()
        {
            BoloesMembrosGrupo = new HashSet<BoloesMembrosGrupo>();
            BoloesMembrosGrupo1 = new HashSet<BoloesMembrosGrupo>();
            BoloesMembrosPontos = new HashSet<BoloesMembrosPontos>();
            BoloesPontosRodadasUsuarios = new HashSet<BoloesPontosRodadasUsuarios>();
            JogosUsuarios = new HashSet<JogosUsuarios>();
        }

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

        public virtual Boloes Boloes { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }

        public virtual Users Users2 { get; set; }

        public virtual BoloesMembrosClassificacao BoloesMembrosClassificacao { get; set; }

        public virtual ICollection<BoloesMembrosGrupo> BoloesMembrosGrupo { get; set; }

        public virtual ICollection<BoloesMembrosGrupo> BoloesMembrosGrupo1 { get; set; }

        public virtual ICollection<BoloesMembrosPontos> BoloesMembrosPontos { get; set; }

        public virtual ICollection<BoloesPontosRodadasUsuarios> BoloesPontosRodadasUsuarios { get; set; }

        public virtual ICollection<JogosUsuarios> JogosUsuarios { get; set; }
    }
}
