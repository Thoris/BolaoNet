using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Reports.Entities
{
    public class EntityJogoUsuario
    {
        #region Properties

        public Domain.Entities.Campeonatos.Jogo Jogo { get; internal set; }
        public Domain.Entities.Boloes.JogoUsuario JogoUsuario { get; internal set; }

        #endregion

        #region Constructors/Destructors

        public EntityJogoUsuario(Domain.Entities.Campeonatos.Jogo jogo, Domain.Entities.Boloes.JogoUsuario jogoUsuario)
        {
            this.Jogo = jogo;
            this.JogoUsuario = jogoUsuario;
        }

        #endregion
    }
}
