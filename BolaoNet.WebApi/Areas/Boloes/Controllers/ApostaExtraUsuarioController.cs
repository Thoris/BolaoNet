using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class ApostaExtraUsuarioController :
        GenericApiController<Domain.Entities.Boloes.ApostaExtraUsuario>,
        Domain.Interfaces.Services.Boloes.IApostaExtraUsuarioService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IApostaExtraUsuarioService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IApostaExtraUsuarioService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public ApostaExtraUsuarioController()
            : base(new Domain.Services.FactoryService().CreateApostaExtraUsuarioService())
        {

        }

        #endregion

        #region Methods


        #endregion

        #region IApostaExtraUsuarioService members

        public IList<Domain.Entities.Boloes.ApostaExtraUsuario> GetApostasUser(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            return Service.GetApostasUser(bolao, user);
        }

        #endregion
    }
}