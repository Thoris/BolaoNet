using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Campeonatos
{
    public class CampeonatoClassificacao : Pontuacao
    {
        #region Properties
        public virtual Entities.Campeonatos.Campeonato Campeonato { get; set; }
        public virtual Entities.Campeonatos.Fase Fase { get; set; }
        public virtual Entities.Campeonatos.Grupo Grupo { get; set; }
        public virtual Entities.DadosBasicos.Time Time { get; set; }
        public int Posicao { get; set; }
        public int LastPosicao { get; set; }

        #endregion

        #region Constructors/Destructors

        public CampeonatoClassificacao()
        {

        }

        #endregion
    }
}
