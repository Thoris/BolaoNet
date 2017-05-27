using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoRequestStatusController:
        GenericApiController<Entities.Boloes.BolaoRequestStatus>, Business.Interfaces.Boloes.IBolaoRequestStatusBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Boloes.IBolaoRequestStatusBO Dao
        {
            get { return (Business.Interfaces.Boloes.IBolaoRequestStatusBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoRequestStatusController()
            : base ( new Business.FactoryBO().CreateBolaoRequestStatusBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}