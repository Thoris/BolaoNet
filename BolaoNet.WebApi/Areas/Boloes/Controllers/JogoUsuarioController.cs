using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class JogoUsuarioController:
        GenericApiController<Domain.Entities.Boloes.JogoUsuario>, 
        Domain.Interfaces.Services.Boloes.IJogoUsuarioService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IJogoUsuarioService Dao
        {
            get { return (Domain.Interfaces.Services.Boloes.IJogoUsuarioService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public JogoUsuarioController()
            : base(new Domain.Services.FactoryService().CreateJogoUsuarioService())
        {

        }

        #endregion

        #region IJogoUsuarioBO members

        public bool ProcessAposta(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user, Domain.Entities.Campeonatos.Jogo jogo, int automatico, int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2, int? ganhador)
        {
            throw new NotImplementedException();
        }

        public IList<Domain.Entities.Boloes.JogoUsuario> GetJogosByUser(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            return Dao.GetJogosByUser(bolao, user);
        }

        [HttpGet]
        public IList<Domain.Entities.Boloes.JogoUsuario> GetJogosByUser(string nomeBolao, string userName)
        {
            return this.GetJogosByUser(new Domain.Entities.Boloes.Bolao(nomeBolao), new Domain.Entities.Users.User(userName));

        }

        #endregion
    }
}