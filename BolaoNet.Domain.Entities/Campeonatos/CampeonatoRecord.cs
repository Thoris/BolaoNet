using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Campeonatos
{
    public class CampeonatoRecord : Base.AuditModel
    {
        #region Variables

        private int _jogos;

        #endregion

        #region Properties

        public int JogosSemMarcar { get; set; }
        public int JogosSemLevar { get; set; }
        public int Posicao { get; set; }
        public int Vitorias { get; set; }
        public int Derrotas { get; set; }
        public int Empates { get; set; }
        public int Jogos
        {
            get
            {
                if (_jogos == 0)
                    return this.Vitorias + this.Derrotas + this.Empates;
                else
                    return _jogos;
            }
            set { _jogos = value; }
        }
        public virtual DadosBasicos.Time Time { get; set; }

        #endregion

        #region Constructors/Destructors

        public CampeonatoRecord()
        {

        }

        #endregion

    }
}
