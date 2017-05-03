namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Estadios
    {
        public Estadios()
        {
            Jogos = new HashSet<Jogos>();
        }

        [Key]
        [StringLength(30)]
        public string Nome { get; set; }

        [StringLength(20)]
        public string Pais { get; set; }

        [StringLength(20)]
        public string Estado { get; set; }

        [StringLength(100)]
        public string Cidade { get; set; }

        [Column(TypeName = "image")]
        public byte[] Foto { get; set; }

        public int? Capacidade { get; set; }

        [StringLength(255)]
        public string Descricao { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? ActiveFlag { get; set; }

        [StringLength(25)]
        public string CreatedBy { get; set; }

        [StringLength(25)]
        public string ModifiedBy { get; set; }

        [StringLength(30)]
        public string NomeTime { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }

        public virtual Times Times { get; set; }

        public virtual ICollection<Jogos> Jogos { get; set; }
    }
}
