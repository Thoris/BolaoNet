using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Reports.Interfaces
{
    public interface IApostasUserReport
    {
        Stream CreatePageUserApostas(Entities.Boloes.Bolao bolao, Entities.Campeonatos.Campeonato campeonato, Entities.Users.User user, 
            IList<Entities.Campeonatos.Jogo> jogos, IList<Entities.Boloes.JogoUsuario> jogosUsuarios, 
            IList<Entities.Boloes.ApostaExtra> apostasExtras, IList<Entities.Boloes.ApostaExtraUsuario> apostasUsuarios);
    }
}
