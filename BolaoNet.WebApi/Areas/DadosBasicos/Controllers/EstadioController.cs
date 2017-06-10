using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.DadosBasicos.Controllers
{
    public class EstadioController:
        GenericApiController<Domain.Entities.DadosBasicos.Estadio>, Domain.Interfaces.Services.DadosBasicos.IEstadioService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.DadosBasicos.IEstadioService Service
        {
            get { return (Domain.Interfaces.Services.DadosBasicos.IEstadioService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public EstadioController()
            : base(new Domain.Services.FactoryService().CreateEstadioService())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}