using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Facade.Campeonatos
{
    public class StructureCopaMundoFacadeApp : Interfaces.Facade.Campeonatos.IStructureCopaMundoFacadeApp
    {
        #region Variables

        private Domain.Interfaces.Services.Facade.Campeonatos.IStructureCopaMundoFacadeService _service;

        #endregion

        #region Constructors/Destructors

        public StructureCopaMundoFacadeApp(Domain.Interfaces.Services.Facade.Campeonatos.IStructureCopaMundoFacadeService service)
        {
            _service = service;
        }

        #endregion

        #region IStructureCopaMundoFacadeApp members




        #endregion
        
        public Domain.Entities.Campeonatos.Campeonato CreateCampeonato(string nomeCampeonato, bool isTime)
        {
            throw new NotImplementedException();
        }

        public IList<Domain.Entities.Campeonatos.CampeonatoPosicao> GetCampeonatoPosicoes(string nomeFase)
        {
            throw new NotImplementedException();
        }

        public IList<Domain.Entities.Campeonatos.Jogo> GetJogosOitavas(int rodada, string nomeGrupo, string nomeFase, IList<DateTime> datas, IList<string> estadios, IList<int> ids)
        {
            throw new NotImplementedException();
        }

        public IList<Domain.Entities.Campeonatos.Jogo> GetJogosQuartas(int rodada, string nomeGrupo, string nomeFase, IList<DateTime> datas, IList<string> estadios, IList<int> ids, IList<int> idsGanhadores)
        {
            throw new NotImplementedException();
        }

        public IList<Domain.Entities.Campeonatos.Jogo> GetJogosSemi(int rodada, string nomeGrupo, string nomeFase, IList<DateTime> datas, IList<string> estadios, IList<int> ids, IList<int> idsGanhadores)
        {
            throw new NotImplementedException();
        }

        public IList<Domain.Entities.Campeonatos.Jogo> GetJogosFinal(int rodada, string nomeGrupo, string nomeFase, IList<DateTime> datas, IList<string> estadios, IList<int> ids, IList<int> idsGanhadores)
        {
            throw new NotImplementedException();
        }

        public IList<Domain.Entities.Campeonatos.Jogo> GetJogosGrupo(string nomeGrupo, string nomeFase, IList<string> times, IList<DateTime> datas, IList<string> estadios, IList<int> ids)
        {
            throw new NotImplementedException();
        }

        public bool InsertResult(int jogoID, bool setCurrentData, Domain.Entities.Users.User validadoBy, int golsTime1, int golsTime2, int? penaltis1, int? penaltis2)
        {
            throw new NotImplementedException();
        }
    }
}
