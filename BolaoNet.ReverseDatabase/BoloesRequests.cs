namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BoloesRequests
    {
        [StringLength(25)]
        public string CreatedBy { get; set; }

        [Key]
        [Column(Order = 0)]
        public int RequestID { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(25)]
        public string ModifiedBy { get; set; }

        public DateTime? RequestedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? ActiveFlag { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string NomeBolao { get; set; }

        public DateTime? AnsweredDate { get; set; }

        [StringLength(25)]
        public string RequestedBy { get; set; }

        [StringLength(25)]
        public string Owner { get; set; }

        public int? StatusRequestID { get; set; }

        [StringLength(25)]
        public string AnsweredBy { get; set; }

        [StringLength(255)]
        public string Descricao { get; set; }
    }
}
