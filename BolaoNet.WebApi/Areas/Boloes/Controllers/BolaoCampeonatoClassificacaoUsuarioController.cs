using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoCampeonatoClassificacaoUsuarioController:
        GenericApiController<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>,
        Domain.Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        //public BolaoCampeonatoClassificacaoUsuarioController()
        //    : base(new Domain.Services.FactoryService(null).CreateBolaoCampeonatoClassificacaoUsuarioService())
        //{

        //}
        public BolaoCampeonatoClassificacaoUsuarioController(Domain.Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService service)
            : base(service)
        {

        }

        #endregion

        #region Methods


        #endregion


    }
}