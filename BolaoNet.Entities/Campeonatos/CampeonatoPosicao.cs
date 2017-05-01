using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Campeonatos
{
    public class CampeonatoPosicao
    {       
        #region Properties
     
        public Campeonatos.Campeonato Campeonato {get;set;}
        public Campeonatos.Fase Fase{get;set;}
        public Campeonatos.Grupo Grupo{get;set;}

        #endregion
    }
}
