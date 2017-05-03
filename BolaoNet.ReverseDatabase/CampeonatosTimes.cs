namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CampeonatosTimes
    {
        public CampeonatosTimes()
        {
            Jogos = new HashSet<Jogos>();
            Jogos1 = new HashSet<Jogos>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string NomeCampeonato { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string NomeTime { get; set; }

        [StringLength(25)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(25)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? ActiveFlag { get; set; }

        public virtual Campeonatos Campeonatos { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }

        public virtual Times Times { get; set; }

        public virtual ICollection<Jogos> Jogos { get; set; }

        public virtual ICollection<Jogos> Jogos1 { get; set; }
    }
}
