using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Facade.Campeonatos
{
    public class StructureCopaMundoFacadeIntegration: Base.JsonManagement,
        Domain.Interfaces.Services.Facade.Campeonatos.IStructureCopaMundoFacadeService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "StructureCopaMundoFacade";

        #endregion
        
        #region Constructors/Destructors

        public StructureCopaMundoFacadeIntegration(string url)
            : base(url, ModuleName)
        {

        }

        #endregion


        #region IStructureCopaMundoFacadeService members

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
        public bool RestartCampeonato(string nomeCampeonato)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
