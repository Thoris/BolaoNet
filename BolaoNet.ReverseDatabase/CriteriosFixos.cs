namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CriteriosFixos
    {
        public CriteriosFixos()
        {
            BoloesCriteriosPontos = new HashSet<BoloesCriteriosPontos>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CriterioID { get; set; }

        [StringLength(255)]
        public string Descricao { get; set; }

        public virtual ICollection<BoloesCriteriosPontos> BoloesCriteriosPontos { get; set; }
    }
}
