using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Campeonatos
{
    public class CampeonatoPosicao : DadosBasicos.HighLightItem
    {       
        #region Properties

        [Key, Column(Order = 0)]
        public string NomeCampeonato { get; set; }
        [ForeignKey("NomeCampeonato")]
        public virtual Campeonatos.Campeonato Campeonato {get;set;}

        [Key, Column(Order = 1)]
        public string NomeFase { get; set; }
        [ForeignKey("NomeFase")]
        public virtual Campeonatos.Fase Fase { get; set; }

        [Key, Column(Order = 2)]
        public string NomeGrupo { get; set; }
        [ForeignKey("NomeGrupo")]
        public virtual Campeonatos.Grupo Grupo { get; set; }

        #endregion
        
        #region Constructors/Destructors

        public CampeonatoPosicao()
        {

        }

        #endregion
    }
}
