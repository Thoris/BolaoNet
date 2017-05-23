using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.Campeonatos
{
    public interface IJogoDao : IGenericDao<Entities.Campeonatos.Jogo>
    {

        bool CalculeGrupo(string currentUserName, DateTime currentDateTime, Entities.Campeonatos.Jogo jogo,
            Entities.Campeonatos.CampeonatoFase fase, Entities.Campeonatos.CampeonatoGrupo grupo);


        //bool InsertResult(string currentUserName, int gols1, int gols2, int ? penaltis1, int ? penaltis2, Entities.Campeonatos.Jogo entry);
        //bool RemoveResult(string currentUserName, Entities.Campeonatos.Jogo entry);

        //IList<Entities.Campeonatos.Jogo> SelectAllByPeriod(string currentUser, int rodada, Entities.Campeonatos.Campeonato campeonato, DateTime dataInicial, DateTime dataFinal, string time, string fase, string grupo);
        //IList<Entities.Campeonatos.Jogo> SelectJogosByTime(string currentUser, Entities.Campeonatos.Campeonato campeonato, Entities.DadosBasicos.Time time);
        //IList<Entities.Campeonatos.Jogo> SelectGoleadas(string currentUser, Entities.Campeonatos.Campeonato campeonato, int maxGols);
        //IList<Entities.Campeonatos.Jogo> LoadNextJogos(string currentUser, Entities.Campeonatos.Campeonato campeonato, int totalJogos);
        //IList<Entities.Campeonatos.Jogo> LoadFinishedJogos(string currentUser, Entities.Campeonatos.Campeonato campeonato, int totalJogos);

        //int NextJogo(string currentUser, Entities.Campeonatos.Campeonato campeonato);
    
    }
}
