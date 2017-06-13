using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.DadosBasicos.Controllers
{
    public class CriterioFixoController :
        GenericApiController<Domain.Entities.DadosBasicos.CriterioFixo>, Domain.Interfaces.Services.DadosBasicos.ICriterioFixoService 
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.DadosBasicos.ICriterioFixoService Service
        {
            get { return (Domain.Interfaces.Services.DadosBasicos.ICriterioFixoService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public CriterioFixoController()
            : base(new Domain.Services.FactoryService(null).CreateCriterioFixoService())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}