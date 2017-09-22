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

        //public ApostaExtraUsuarioController()
        //    : base(new Domain.Services.FactoryService(null).CreateApostaExtraUsuarioService())
        //{

        //}
        public ApostaExtraUsuarioController(Domain.Interfaces.Services.Boloes.IApostaExtraUsuarioService service)
            : base(service)
        {

        }

        #endregion

        #region Methods


        #endregion

        #region IApostaExtraUsuarioService members

        [HttpPost]
        public IList<Domain.Entities.ValueObjects.ApostaExtraUsuarioVO> GetApostasUser(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            return Service.GetApostasUser(bolao, user);
        }
        [HttpPost]
        public IList<Domain.Entities.Boloes.ApostaExtraUsuario> GetApostasBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.GetApostasBolao(bolao);
        }

        [HttpPost]
        public IList<IList<Domain.Entities.Boloes.ApostaExtraUsuario>> GetApostasBolaoAgrupado(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.GetApostasBolaoAgrupado(bolao);
        }

        #endregion


    }
}