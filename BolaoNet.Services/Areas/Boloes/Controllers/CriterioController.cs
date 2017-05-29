using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class CriterioController:
        GenericApiController<Entities.Boloes.Criterio>, Business.Interfaces.Boloes.ICriterioBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Boloes.ICriterioBO Dao
        {
            get { return (Business.Interfaces.Boloes.ICriterioBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public CriterioController()
            : base ( new Business.FactoryBO().CreateCriterioBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}