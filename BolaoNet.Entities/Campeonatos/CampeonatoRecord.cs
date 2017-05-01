using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Campeonatos
{
    public class CampeonatoRecord : Base.AuditModel
    {

        #region Properties

        public int JogosSemMarcar {get;set;}
        public int JogosSemLevar {get;set;}
        public int Posicao {get;set;}
        public int Vitorias {get;set;}
        public int Derrotas {get;set;}
        public int Empates {get;set;}
        public int Jogos
        {
            get
            {
                if (this.Jogos == 0)
                    return this.Vitorias + this.Derrotas + this.Empates;
                else
                    return this.Jogos;
            }
            set;
        }
        public DadosBasicos.Time Time {get;set;}

        #endregion

    }
}
