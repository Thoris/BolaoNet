using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.WebApi.Areas.Facade.Controllers
{
    public class StructureCopaMundoFacadeController : AuthorizationController,
        Domain.Interfaces.Services.Facade.Campeonatos.IStructureCopaMundoFacadeService
    {

        #region Constructors/Destructors

        public StructureCopaMundoFacadeController()
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

        #endregion
    }
}