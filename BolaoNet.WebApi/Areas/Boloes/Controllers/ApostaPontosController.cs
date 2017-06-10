using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class ApostaPontosController:
        GenericApiController<Domain.Entities.Boloes.ApostaPontos>, 
        Domain.Interfaces.Services.Boloes.IApostaPontosService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IApostaPontosService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IApostaPontosService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public ApostaPontosController()
            : base(new Domain.Services.FactoryService().CreateApostaPontosService())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}