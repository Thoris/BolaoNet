using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Campeonatos
{
    public class CampeonatoHistorico : Base.AuditModel
    {
        [Key, Column(Order = 0)]
        public int Ano { get; set; }

        [Key, Column(Order = 1)]
        [StringLength(50)]
        public string NomeCampeonato { get; set; }
        [ForeignKey("NomeCampeonato")]
        public virtual Campeonato Campeonato { get; set; }

        [StringLength(25)]
        public string Sede { get; set; }

        [StringLength(25)]
        public string NomeTimeCampeao { get; set; }

        [StringLength(25)]
        public string NomeTimeVice { get; set; }

        [StringLength(25)]
        public string NomeTimeTerceiro { get; set; }

        public short? FinalTime1 { get; set; }

        public short? FinalPenaltis1 { get; set; }

        public short? FinalTime2 { get; set; }

        public int? FinalPenaltis2 { get; set; }
    }
}
