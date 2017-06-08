using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Facade
{
    public interface IBolaoFacadeService
    {
        IList<Entities.Boloes.JogoUsuario> InsertJogoUsuario(Entities.Users.User user, Entities.Boloes.Bolao bolao, 
            Entities.Campeonatos.Jogo jogo, int automatico, int time1, int time2, int? penaltis1, int? penaltis2);


        //IList<Entities.Boloes.JogoUsuario> InsertJogoUsuario(Entities.Boloes.JogoUsuario jogo); 
    }
}
