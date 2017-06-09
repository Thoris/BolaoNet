using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoRegraController:
        GenericApiController<Domain.Entities.Boloes.BolaoRegra>,
        Domain.Interfaces.Services.Boloes.IBolaoRegraService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IBolaoRegraService Dao
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoRegraService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoRegraController()
            : base(new Domain.Services.FactoryService().CreateBolaoRegraService())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}