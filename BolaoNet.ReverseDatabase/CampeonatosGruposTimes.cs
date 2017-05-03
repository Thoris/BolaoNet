namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CampeonatosGruposTimes
    {
        public CampeonatosGruposTimes()
        {
            CampeonatosClassificacao = new HashSet<CampeonatosClassificacao>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string NomeTime { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string NomeGrupo { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string NomeCampeonato { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? ActiveFlag { get; set; }

        [StringLength(25)]
        public string CreatedBy { get; set; }

        [StringLength(25)]
        public string ModifiedBy { get; set; }

        public virtual ICollection<CampeonatosClassificacao> CampeonatosClassificacao { get; set; }

        public virtual CampeonatosGrupos CampeonatosGrupos { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }

        public virtual Times Times { get; set; }
    }
}
