using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoController : GenericApiController<Entities.Boloes.Bolao>
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Boloes.IBolaoBO Dao
        {
            get { return (Business.Interfaces.Boloes.IBolaoBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoController()
            : base ( new Business.FactoryBO().CreateBolaoBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}