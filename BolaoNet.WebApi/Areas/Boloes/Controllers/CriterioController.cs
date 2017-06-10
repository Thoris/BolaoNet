using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class CriterioController:
        GenericApiController<Domain.Entities.Boloes.Criterio>,
        Domain.Interfaces.Services.Boloes.ICriterioService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.ICriterioService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.ICriterioService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public CriterioController()
            : base(new Domain.Services.FactoryService().CreateCriterioService())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}