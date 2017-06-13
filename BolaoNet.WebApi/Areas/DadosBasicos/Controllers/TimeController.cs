using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.DadosBasicos.Controllers
{
    public class TimeController:
        GenericApiController<Domain.Entities.DadosBasicos.Time>, Domain.Interfaces.Services.DadosBasicos.ITimeService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.DadosBasicos.ITimeService Service
        {
            get { return (Domain.Interfaces.Services.DadosBasicos.ITimeService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public TimeController()
            : base(new Domain.Services.FactoryService(null).CreateTimeService())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}