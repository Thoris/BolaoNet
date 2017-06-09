using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BolaoNet.Services.Areas.Campeonatos.Controllers
{
    public class JogoController:
        GenericApiController<Domain.Entities.Campeonatos.Jogo>,
        Domain.Interfaces.Services.Campeonatos.IJogoService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Campeonatos.IJogoService Dao
        {
            get { return (Domain.Interfaces.Services.Campeonatos.IJogoService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public JogoController()
            : base(new Domain.Services.FactoryService().CreateJogoService())
        {

        }

        #endregion

        #region IJogoBO members

        public bool InsertResult(Domain.Entities.Campeonatos.Jogo jogo, int gols1, int? penaltis1, int gols2, int? penaltis2, bool setCurrentData, Domain.Entities.Users.User validadoBy)
        {
            return Dao.InsertResult(jogo, gols1, penaltis1, gols2, penaltis2, setCurrentData, validadoBy);
        }

        public bool InsertResult(string nomeCampeonato, int jogoId, int gols1, int? penaltis1, int gols2, int? penaltis2, bool setCurrentData, string validadoBy)
        {
            return this.InsertResult(new Domain.Entities.Campeonatos.Jogo(nomeCampeonato, jogoId),
                gols1, penaltis1, gols2, penaltis2, setCurrentData, new Domain.Entities.Users.User(validadoBy));
        }

        public IList<Domain.Entities.Campeonatos.Jogo> GetJogosByCampeonato(Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            return Dao.GetJogosByCampeonato(campeonato);
        }
        
        public IList<Domain.Entities.Campeonatos.Jogo> GetJogosByCampeonato(string nomeCampeonato)
        {
            return this.GetJogosByCampeonato(new Domain.Entities.Campeonatos.Campeonato(nomeCampeonato));
        }

        public IList<Domain.Entities.Campeonatos.Jogo> LoadJogos(int rodada, DateTime dataInicial, DateTime dataFinal, Domain.Entities.Campeonatos.CampeonatoFase fase, Domain.Entities.Campeonatos.Campeonato campeonato, Domain.Entities.Campeonatos.CampeonatoGrupo grupo, string condition)
        {
            throw new NotImplementedException();
        }

        public IList<Domain.Entities.Campeonatos.Jogo> LoadFinishedJogos(Domain.Entities.Campeonatos.Campeonato campeonato, int totalJogos)
        {
            throw new NotImplementedException();
        }

        public IList<Domain.Entities.Campeonatos.Jogo> LoadNextJogos(Domain.Entities.Campeonatos.Campeonato campeonato, int totalJogos)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}