using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoRegraController:
        GenericApiController<Entities.Boloes.BolaoRegra>, Business.Interfaces.Boloes.IBolaoRegraBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Boloes.IBolaoRegraBO Dao
        {
            get { return (Business.Interfaces.Boloes.IBolaoRegraBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoRegraController()
            : base ( new Business.FactoryBO().CreateBolaoRegraBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}