using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Campeonatos
{
    public class CampeonatoTime : Base.AuditModel
    {
        #region Properties

        [Key, Column(Order = 1)]
        [ForeignKey("NomeTime")]
        public virtual DadosBasicos.Time Time { get; set; }
        public string NomeTime { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("NomeCampeonato")]
        public virtual Campeonato Campeonato { get; set; }
        public string NomeCampeonato { get; set; }

        #endregion
    }
}
