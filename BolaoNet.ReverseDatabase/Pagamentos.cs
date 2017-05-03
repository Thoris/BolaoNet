namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pagamentos
    {
        [StringLength(25)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [Key]
        [Column(Order = 0)]
        public DateTime DataPagamento { get; set; }

        [StringLength(25)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(255)]
        public string Descricao { get; set; }

        public bool? ActiveFlag { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string NomeBolao { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(25)]
        public string UserName { get; set; }

        public decimal? Valor { get; set; }

        [StringLength(20)]
        public string TipoPagamento { get; set; }

        public virtual Boloes Boloes { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }

        public virtual PagamentoTipo PagamentoTipo { get; set; }

        public virtual Users Users2 { get; set; }
    }
}
