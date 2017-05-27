using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.DadosBasicos.Controllers
{
    public class CriterioFixoController :
        GenericApiController<Entities.DadosBasicos.CriterioFixo>, Business.Interfaces.DadosBasicos.ICriterioFixoBO 
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.DadosBasicos.ICriterioFixoBO Dao
        {
            get { return (Business.Interfaces.DadosBasicos.ICriterioFixoBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public CriterioFixoController()
            : base ( new Business.FactoryBO().CreateCriterioFixoBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}