using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Reports
{
    public interface IApostasUserReport
    {
        void GenerateApostas(Entities.Boloes.Bolao bolao, Entities.Campeonatos.Campeonato campeonato, Entities.Users.User user, 
            IList<Entities.Campeonatos.Jogo> jogos, IList<Entities.Boloes.Bolao> jogosUsuarios);
    }
}
