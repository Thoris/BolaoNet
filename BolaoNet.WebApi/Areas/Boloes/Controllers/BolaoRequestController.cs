using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoRequestController:
        GenericApiController<Domain.Entities.Boloes.BolaoRequest>, 
        Domain.Interfaces.Services.Boloes.IBolaoRequestService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IBolaoRequestService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoRequestService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        //public BolaoRequestController()
        //    : base(new Domain.Services.FactoryService(null).CreateBolaoRequestService())
        //{

        //}
        public BolaoRequestController(Domain.Interfaces.Services.Boloes.IBolaoRequestService service)
            : base(service)
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}