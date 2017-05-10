using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Interfaces.Facade.Campeonatos
{
    public interface ICopaMundoFacadeBO
    {
        IList<Entities.Campeonatos.Jogo> GetJogosGrupo(Entities.Campeonatos.Campeonato campeonato);
    }
}
