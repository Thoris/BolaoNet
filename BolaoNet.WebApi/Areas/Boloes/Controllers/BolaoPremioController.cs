using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoPremioController:
        GenericApiController<Domain.Entities.Boloes.BolaoPremio>, 
        Domain.Interfaces.Services.Boloes.IBolaoPremioService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IBolaoPremioService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoPremioService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoPremioController()
            : base(new Domain.Services.FactoryService().CreateBolaoPremioService())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}