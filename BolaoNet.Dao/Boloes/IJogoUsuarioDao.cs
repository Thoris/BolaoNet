using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.Boloes
{
    public interface IJogoUsuarioDao
    {
        
        //bool AddAposta(string currentUserName, Entities.Boloes.Bolao bolao, Entities.Users.User user, Entities.Campeonatos.Jogo jogo, 
        //    int automatico, int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2, int? ganhador);

        //bool UpdateAposta(string currentUserName, Entities.Boloes.Bolao bolao, Entities.Users.User user, Entities.Campeonatos.Jogo jogo, 
        //    int automatico, int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2, int? ganhador);

        bool AddAposta(string currentUserName, Entities.Boloes.JogoUsuario jogoUsuario);

        bool UpdateAposta(string currentUserName, Entities.Boloes.JogoUsuario jogoUsuario);


        bool CalculeTime(string currentUserName, Entities.Boloes.Bolao bolao, Entities.Users.User user, Entities.DadosBasicos.Time time, 
            Entities.Campeonatos.CampeonatoFase fase, Entities.Campeonatos.CampeonatoGrupo grupo);

        bool CalculeDependencia(string currentUserName, Entities.Boloes.Bolao bolao, Entities.Users.User user, Entities.Campeonatos.Jogo jogo,
            Entities.Campeonatos.CampeonatoFase fase, Entities.Campeonatos.CampeonatoGrupo grupo);

        bool CalculeFinal(string currentUserName, Entities.Boloes.Bolao bolao, Entities.Users.User user, Entities.Campeonatos.Jogo jogo,
            Entities.Campeonatos.CampeonatoFase fase, Entities.Campeonatos.CampeonatoGrupo grupo);

        bool CalculeGrupo(string currentUserName, Entities.Boloes.Bolao bolao, Entities.Users.User user, Entities.Campeonatos.Campeonato campeonato, 
            Entities.Campeonatos.CampeonatoFase fase, Entities.Campeonatos.CampeonatoGrupo grupo);

    }
}
