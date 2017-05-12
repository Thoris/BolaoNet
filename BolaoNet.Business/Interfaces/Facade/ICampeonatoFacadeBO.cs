using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Interfaces.Facade
{
    public interface ICampeonatoFacadeBO
    {
        IList<Entities.Campeonatos.Jogo> InsertJogo(Entities.Campeonatos.Jogo jogo); 
    }
}
