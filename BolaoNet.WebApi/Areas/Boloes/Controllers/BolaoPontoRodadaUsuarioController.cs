using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoPontoRodadaUsuarioController:
        GenericApiController<Domain.Entities.Boloes.BolaoPontoRodadaUsuario>, 
        Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaUsuarioService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaUsuarioService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaUsuarioService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        //public BolaoPontoRodadaUsuarioController()
        //    : base(new Domain.Services.FactoryService(null).CreateBolaoPontoRodadaUsuarioService())
        //{

        //}
        public BolaoPontoRodadaUsuarioController(Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaUsuarioService service)
            : base(service)
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}