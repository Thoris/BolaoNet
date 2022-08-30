using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Campeonatos
{
    public interface IJogoService
        : Base.IGenericService<Entities.Campeonatos.Jogo>
    {
        bool InsertResult(Entities.Campeonatos.Jogo jogo, int gols1, int? penaltis1, int gols2, int? penaltis2, 
            bool setCurrentData, Entities.Users.User validadoBy);

        IList<Entities.Campeonatos.Jogo> GetJogosByCampeonato(Entities.Campeonatos.Campeonato campeonato);

        IList<Entities.Campeonatos.Jogo> LoadJogos(int rodada, DateTime dataInicial, DateTime dataFinal, 
            Entities.Campeonatos.CampeonatoFase fase,  Entities.Campeonatos.Campeonato campeonato, 
            Entities.Campeonatos.CampeonatoGrupo grupo, string condition);

        IList<Entities.Campeonatos.Jogo> LoadFinishedJogos(Entities.Campeonatos.Campeonato campeonato, int totalJogos);

        IList<Entities.Campeonatos.Jogo> LoadNextJogos(Entities.Campeonatos.Campeonato campeonato, int totalJogos);

        IList<Entities.Campeonatos.Jogo> GetJogos(Entities.Campeonatos.Campeonato campeonato, Entities.ValueObjects.FilterJogosVO filter);

        IList<Entities.Campeonatos.Jogo> SelectGoleadas(Entities.Campeonatos.Campeonato campeonato, int maxGols);

        IList<Domain.Entities.Campeonatos.Jogo> GetJogosTimesPossibilidades(Domain.Entities.Campeonatos.Campeonato campeonato);
        
        Entities.Campeonatos.Jogo GetLastValidJogo(Entities.Campeonatos.Campeonato campeonato);
    }
}
