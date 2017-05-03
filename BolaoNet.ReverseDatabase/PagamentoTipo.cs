namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PagamentoTipo")]
    public partial class PagamentoTipo
    {
        public PagamentoTipo()
        {
            Pagamentos = new HashSet<Pagamentos>();
        }

        [Key]
        [StringLength(20)]
        public string TipoPagamento { get; set; }

        [StringLength(255)]
        public string Descricao { get; set; }

        public virtual ICollection<Pagamentos> Pagamentos { get; set; }
    }
}
