namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CampeonatosHistorico")]
    public partial class CampeonatosHistorico
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Ano { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(25)]
        public string Sede { get; set; }

        [StringLength(25)]
        public string NomeTimeCampeao { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(25)]
        public string NomeTimeVice { get; set; }

        public bool? ActiveFlag { get; set; }

        [StringLength(25)]
        public string NomeTimeTerceiro { get; set; }

        [StringLength(25)]
        public string CreatedBy { get; set; }

        [StringLength(25)]
        public string ModifiedBy { get; set; }

        public short? FinalTime1 { get; set; }

        public short? FinalPenaltis1 { get; set; }

        public short? FinalTime2 { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Nome { get; set; }

        public int? FinalPenaltis2 { get; set; }

        public virtual Campeonatos Campeonatos { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }
    }
}
