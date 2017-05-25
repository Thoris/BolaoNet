using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Reports
{
    public class EntityJogoUsuario
    {
        #region Properties

        public Entities.Campeonatos.Jogo Jogo { get; internal set; }
        public Entities.Boloes.JogoUsuario JogoUsuario { get; internal set; }

        #endregion

        #region Constructors/Destructors

        public EntityJogoUsuario(Entities.Campeonatos.Jogo jogo, Entities.Boloes.JogoUsuario jogoUsuario)
        {
            this.Jogo = jogo;
            this.JogoUsuario = jogoUsuario;
        }

        #endregion
    }
}
