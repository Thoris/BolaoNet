using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class JogoUsuarioController:
        GenericApiController<Entities.Boloes.JogoUsuario>, Business.Interfaces.Boloes.IJogoUsuarioBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Boloes.IJogoUsuarioBO Dao
        {
            get { return (Business.Interfaces.Boloes.IJogoUsuarioBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public JogoUsuarioController()
            : base ( new Business.FactoryBO().CreateJogoUsuarioBO())
        {

        }

        #endregion

        #region IJogoUsuarioBO members

        public bool ProcessAposta(Entities.Boloes.Bolao bolao, Entities.Users.User user, Entities.Campeonatos.Jogo jogo, int automatico, int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2, int? ganhador)
        {
            throw new NotImplementedException();
        }

        public IList<Entities.Boloes.JogoUsuario> GetJogosByUser(Entities.Boloes.Bolao bolao, Entities.Users.User user)
        {
            return Dao.GetJogosByUser(bolao, user);
        }

        [HttpGet]
        public IList<Entities.Boloes.JogoUsuario> GetJogosByUser(string nomeBolao, string userName)
        {
            return this.GetJogosByUser(new Entities.Boloes.Bolao(nomeBolao), new Entities.Users.User(userName));

        }

        #endregion
    }
}