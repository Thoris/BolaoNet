namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mensagens
    {
        [StringLength(25)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime CreationDate { get; set; }

        [StringLength(25)]
        public string ModifiedBy { get; set; }

        public bool? Private { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? ActiveFlag { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string NomeBolao { get; set; }

        public int? TotalRead { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public int? AnsweredMessageID { get; set; }

        [StringLength(25)]
        public string ToUser { get; set; }

        [StringLength(4000)]
        public string Message { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(25)]
        public string FromUser { get; set; }

        [Key]
        [Column(Order = 2)]
        public int MessageID { get; set; }
    }
}
