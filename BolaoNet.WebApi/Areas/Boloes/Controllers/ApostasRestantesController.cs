using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class ApostasRestantesController:
        GenericApiController<Domain.Entities.Boloes.ApostasRestantesUser>,
        Domain.Interfaces.Services.Boloes.IApostasRestantesService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IApostasRestantesService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IApostasRestantesService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        //public ApostasRestantesController()
        //    : base(new Domain.Services.FactoryService(null).CreateApostasRestantesService())
        //{

        //}
        public ApostasRestantesController(Domain.Interfaces.Services.Boloes.IApostasRestantesService service)
            : base(service)
        {

        }

        #endregion

        #region Methods


        #endregion


    }
}