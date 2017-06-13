using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoPontoRodadaController :
        GenericApiController<Domain.Entities.Boloes.BolaoPontoRodada>, 
        Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoPontoRodadaController()
            : base(new Domain.Services.FactoryService(null).CreateBolaoPontoRodadaService())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}