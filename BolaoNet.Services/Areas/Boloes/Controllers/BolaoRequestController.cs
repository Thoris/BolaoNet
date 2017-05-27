using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoRequestController:
        GenericApiController<Entities.Boloes.BolaoRequest>, Business.Interfaces.Boloes.IBolaoRequestBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Boloes.IBolaoRequestBO Dao
        {
            get { return (Business.Interfaces.Boloes.IBolaoRequestBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoRequestController()
            : base ( new Business.FactoryBO().CreateBolaoRequestBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}