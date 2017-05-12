using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Interfaces.Facade
{
    public interface IBolaoFacadeBO
    {
        
        IList<Entities.Boloes.JogoUsuario> InsertJogoUsuario(Entities.Boloes.JogoUsuario jogo); 
    }
}
