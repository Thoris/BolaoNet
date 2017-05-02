using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Campeonatos
{
    public class CampeonatoPosicao : DadosBasicos.HighLightItem
    {       
        #region Properties
     
        public virtual Campeonatos.Campeonato Campeonato {get;set;}
        public virtual Campeonatos.Fase Fase { get; set; }
        public virtual Campeonatos.Grupo Grupo { get; set; }

        #endregion
        
        #region Constructors/Destructors

        public CampeonatoPosicao()
        {

        }

        #endregion
    }
}
