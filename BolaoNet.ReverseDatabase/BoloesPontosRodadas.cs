namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BoloesPontosRodadas
    {
        public BoloesPontosRodadas()
        {
            BoloesPontosRodadasUsuarios = new HashSet<BoloesPontosRodadasUsuarios>();
        }

        [StringLength(25)]
        public string CreatedBy { get; set; }

        public int? Pontos { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(25)]
        public string ModifiedBy { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Posicao { get; set; }

        [StringLength(50)]
        public string Titulo { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? ActiveFlag { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string NomeGrupo { get; set; }

        public DateTime? DataValidacao { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string NomeCampeonato { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(30)]
        public string NomeFase { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(30)]
        public string NomeBolao { get; set; }

        public virtual Boloes Boloes { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }

        public virtual CampeonatosFases CampeonatosFases { get; set; }

        public virtual CampeonatosGrupos CampeonatosGrupos { get; set; }

        public virtual ICollection<BoloesPontosRodadasUsuarios> BoloesPontosRodadasUsuarios { get; set; }
    }
}
