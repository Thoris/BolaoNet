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
        public Entities.Campeonatos.Campeonato Campeonato {get;set;}
        public Entities.Campeonatos.Fase Fase{get;set;}
        public Entities.Campeonatos.Grupo Grupo{get;set;}
        public Entities.DadosBasicos.Time Time{get;set;}
        public int Posicao{get;set;}
        public int LastPosicao{get;set;}

        #endregion
    }
}
