using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Campeonatos
{
    public class CampeonatoGrupoTime : Base.AuditModel
    {
        #region Properties

        [Key, Column(Order = 2)]
        public string NomeTime { get; set; }
        [ForeignKey("NomeTime")]
        public virtual DadosBasicos.Time Time { get; set; }

        [Key, Column(Order = 0)]
        public string NomeCampeonato { get; set; }
        //[ForeignKey("NomeCampeonato")]
        //public virtual Campeonato Campeonato { get; set; }

        [Key, Column(Order = 1)]
        public string NomeGrupo { get; set; }
        //[ForeignKey("NomeGrupo")]
        //public virtual CampeonatoGrupo CampeonatoGrupo { get; set; }

        #endregion
    }
}
