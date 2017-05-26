using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Interfaces.Campeonatos
{
    public interface IJogoBO : Base.IGenericBusiness<Entities.Campeonatos.Jogo>
    {
        bool InsertResult(Entities.Campeonatos.Jogo jogo, int gols1, int? penaltis1, int gols2, int? penaltis2, 
            bool setCurrentData, Entities.Users.User validadoBy);

        IList<Entities.Campeonatos.Jogo> GetJogosByCampeonato(Entities.Campeonatos.Campeonato campeonato);
        
    }
}
