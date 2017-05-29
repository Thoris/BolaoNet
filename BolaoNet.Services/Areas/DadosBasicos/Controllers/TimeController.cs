using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.DadosBasicos.Controllers
{
    public class TimeController:
        GenericApiController<Entities.DadosBasicos.Time>, Business.Interfaces.DadosBasicos.ITimeBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.DadosBasicos.ITimeBO Dao
        {
            get { return (Business.Interfaces.DadosBasicos.ITimeBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public TimeController()
            : base ( new Business.FactoryBO().CreateTimeBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}