using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoRequestStatusController:
        GenericApiController<Domain.Entities.Boloes.BolaoRequestStatus>, 
        Domain.Interfaces.Services.Boloes.IBolaoRequestStatusService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IBolaoRequestStatusService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoRequestStatusService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoRequestStatusController()
            : base(new Domain.Services.FactoryService().CreateBolaoRequestStatusService())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}