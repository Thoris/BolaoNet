using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BolaoNet.Services.Areas.Campeonatos.Controllers
{
    public class JogoController:
        GenericApiController<Entities.Campeonatos.Jogo>, Business.Interfaces.Campeonatos.IJogoBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Campeonatos.IJogoBO Dao
        {
            get { return (Business.Interfaces.Campeonatos.IJogoBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public JogoController()
            : base ( new Business.FactoryBO().CreateJogoBO())
        {

        }

        #endregion

        #region IJogoBO members

        public bool InsertResult(Entities.Campeonatos.Jogo jogo, int gols1, int? penaltis1, int gols2, int? penaltis2, bool setCurrentData, Entities.Users.User validadoBy)
        {
            return Dao.InsertResult(jogo, gols1, penaltis1, gols2, penaltis2, setCurrentData, validadoBy);
        }

        [HttpPost]
        public bool InsertResult(string nomeCampeonato, int jogoId, int gols1, int? penaltis1, int gols2, int? penaltis2, bool setCurrentData, string validadoBy)
        {
            return this.InsertResult(new Entities.Campeonatos.Jogo(nomeCampeonato, jogoId),
                gols1, penaltis1, gols2, penaltis2, setCurrentData, new Entities.Users.User(validadoBy));
        }

        public IList<Entities.Campeonatos.Jogo> GetJogosByCampeonato(Entities.Campeonatos.Campeonato campeonato)
        {
            return Dao.GetJogosByCampeonato(campeonato);
        }
        [HttpGet]
        public IList<Entities.Campeonatos.Jogo> GetJogosByCampeonato(string nomeCampeonato)
        {
            return this.GetJogosByCampeonato(new Entities.Campeonatos.Campeonato(nomeCampeonato));
        }
        
        #endregion
    }
}