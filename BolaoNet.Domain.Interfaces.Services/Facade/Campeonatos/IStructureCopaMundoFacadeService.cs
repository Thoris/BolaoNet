using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Facade.Campeonatos
{
    public interface IStructureCopaMundoFacadeService
    {
        Entities.Campeonatos.Campeonato Campeonato { get; }

        Entities.Campeonatos.Campeonato CreateCampeonato(string nomeCampeonato, bool isTime);

        IList<Entities.Campeonatos.CampeonatoPosicao> GetCampeonatoPosicoes(string nomeFase);

        IList<Entities.Campeonatos.Jogo> GetJogosOitavas(int rodada, string nomeGrupo, string nomeFase, IList<DateTime> datas,
            IList<string> estadios, IList<int> ids);

        IList<Entities.Campeonatos.Jogo> GetJogosQuartas(int rodada, string nomeGrupo, string nomeFase, IList<DateTime> datas, IList<string> estadios, 
            IList<int> ids, IList<int> idsGanhadores);
        
        IList<Entities.Campeonatos.Jogo> GetJogosSemi(int rodada, string nomeGrupo, string nomeFase, 
            IList<DateTime> datas, IList<string> estadios, IList<int> ids, IList<int> idsGanhadores);
        
        IList<Entities.Campeonatos.Jogo> GetJogosFinal(int rodada, string nomeGrupo, string nomeFase, 
            IList<DateTime> datas, IList<string> estadios, IList<int> ids, IList<int> idsGanhadores);
        
        IList<Entities.Campeonatos.Jogo> GetJogosGrupo(string nomeGrupo, string nomeFase, IList<string> times, IList<DateTime> datas, 
            IList<string> estadios, IList<int> ids);
        
        bool InsertResult(int jogoID, bool setCurrentData, Entities.Users.User validadoBy, int golsTime1, int golsTime2, int? penaltis1, int? penaltis2);
    }
}
