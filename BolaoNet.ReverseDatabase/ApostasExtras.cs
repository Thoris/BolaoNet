namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ApostasExtras
    {
        public ApostasExtras()
        {
            ApostasExtrasUsuarios = new HashSet<ApostasExtrasUsuarios>();
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Posicao { get; set; }

        [StringLength(25)]
        public string CreatedBy { get; set; }

        [StringLength(50)]
        public string Titulo { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(255)]
        public string Descricao { get; set; }

        [StringLength(25)]
        public string ModifiedBy { get; set; }

        public int? TotalPontos { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? IsValido { get; set; }

        public bool? ActiveFlag { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string NomeBolao { get; set; }

        public DateTime? DataValidacao { get; set; }

        [StringLength(25)]
        public string ValidadoBy { get; set; }

        [StringLength(30)]
        public string NomeTimeValidado { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }

        public virtual Boloes Boloes { get; set; }

        public virtual Times Times { get; set; }

        public virtual Users Users2 { get; set; }

        public virtual ICollection<ApostasExtrasUsuarios> ApostasExtrasUsuarios { get; set; }
    }
}
